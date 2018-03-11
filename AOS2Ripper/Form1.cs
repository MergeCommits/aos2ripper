using AOS2Ripper.Parsers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AOS2Ripper
{
    public partial class SuGUI : Form
    {
        private bool processInProgress = false;

        struct ConsoleMessage
        {
            public string Text;
            public Color Color;

            public ConsoleMessage(string text, Color color)
            {
                Text = text; Color = color;
            }
        }
        private List<ConsoleMessage> queuedMessages;
        private Thread consoleUpdateThread;

        public SuGUI()
        {
            InitializeComponent();

            queuedMessages = new List<ConsoleMessage>();
            consoleUpdateThread = null;

            tableLayoutPanel1.CellPaint += tableLayoutPanel1_CellPaint;
            txtConsole.TextChanged += txtConsole_TextChanged;
            
            bgParser.ProgressChanged += bgParser_ProgressChanged;
            bgParser.RunWorkerCompleted += bgParser_RunWorkerCompleted;
        }

        private void ResetForm()
        {
            txtConsole.Invoke(new Action(() => txtConsole.Text = string.Empty));
            progressBar.Invoke(new Action(() => progressBar.Value = 0));
            if (!progressBar.Visible)
            {
                progressBar.Invoke(new Action(() => progressBar.Visible = true));
            }
        }

        public void AppendConsoleText(string text, Color color)
        {
            lock (queuedMessages)
            {
                queuedMessages.Add(new ConsoleMessage(text, color));
            }
            InitConsoleUpdateThread();
        }

        public void AppendConsoleText(string text)
        {
            lock (queuedMessages)
            {
                queuedMessages.Add(new ConsoleMessage(text, Color.Black));
            }
            InitConsoleUpdateThread();
        }

        private void InitConsoleUpdateThread()
        {
            if (consoleUpdateThread == null || consoleUpdateThread.ThreadState==ThreadState.Stopped)
            {
                consoleUpdateThread = new Thread(ConsoleUpdate);
                consoleUpdateThread.Start();
            }
        }

        private void ConsoleUpdate()
        {
            List<ConsoleMessage> cConsoleMessages;
            lock (queuedMessages)
            {
                cConsoleMessages = new List<ConsoleMessage>(queuedMessages);
            }

            while (cConsoleMessages.Count > 0)
            {
                Thread.Sleep(100);

                int count = cConsoleMessages.Count;
                for (int i=0;i<count;i++)
                {
                    string text = cConsoleMessages[i].Text+"\n";
                    Color selectionColor = cConsoleMessages[i].Color;
                    while (i<count-1 && cConsoleMessages[i+1].Color==selectionColor)
                    {
                        text += cConsoleMessages[i + 1].Text+"\n";
                        i++;
                    }
                    txtConsole.Invoke(new Action(() =>
                    {
                        txtConsole.SelectionStart = txtConsole.TextLength;
                        txtConsole.SelectionLength = 0;

                        txtConsole.SelectionColor = cConsoleMessages[i].Color;
                        txtConsole.Invoke(new Action(() => txtConsole.AppendText(text)));
                        txtConsole.SelectionColor = txtConsole.ForeColor;
                    }));
                }
                
                cConsoleMessages.Clear();

                lock (queuedMessages)
                {
                    queuedMessages.RemoveRange(0, count);
                    if (queuedMessages.Count>0)
                    {
                        cConsoleMessages.AddRange(queuedMessages);
                    }
                }
            }
        }

        public void StepProgress(int percentage)
        {
            bgParser.ReportProgress(percentage);
        }

        #region Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.DrawLine(Pens.Black, new Point(e.CellBounds.Right, e.CellBounds.Bottom), new Point(e.CellBounds.Left, e.CellBounds.Bottom));
            }

            if (e.Column == 2 && e.Row < 4)
            {
                e.Graphics.DrawLine(Pens.Black, new Point(e.CellBounds.Right, e.CellBounds.Top), new Point(e.CellBounds.Right, e.CellBounds.Bottom));
            }
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            txtConsole.SelectionStart = txtConsole.Text.Length;
            // scroll to it automatically
            txtConsole.ScrollToCaret();
        }

        /// <summary>
        /// Opens the file dialog for choosing a .PAK file.
        /// </summary>
        private void inputFileBtn_Click(object sender, EventArgs e)
        {
            inputPakDialog.ShowDialog();
        }

        /// <summary>
        /// Sets the text box after choosing a .PAK file.
        /// </summary>
        private void inputPakFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            txtInputFile.Text = inputPakDialog.FileName;
        }

        /// <summary>
        /// Opens an output directory for the folder.
        /// </summary>
        private void outputDirBtn_Click(object sender, EventArgs e)
        {
            if (outputDirDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = outputDirDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Parses .PAK to folder.
        /// </summary>
        private void btnPak2Dir_Click(object sender, EventArgs e)
        {
            if (processInProgress) { return; }
            processInProgress = true;

            bgParser.RunWorkerAsync("PAK_2_FOLDER");
        }

        /// <summary>
        /// Opens a directory to package.
        /// </summary>
        private void btnSavePak_Click(object sender, EventArgs e)
        {
            if (inputDirDialog.ShowDialog() == DialogResult.OK)
            {
                txtSavePak.Text = inputDirDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Parses folder to .PAK.
        /// </summary>
        private void btnDir2Pak_Click(object sender, EventArgs e)
        {
            if (processInProgress) { return; }

            if (string.IsNullOrWhiteSpace(txtSavePak.Text))
            {
                MessageBox.Show("Directory field is empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (savePakFile.ShowDialog() == DialogResult.OK)
            {
                processInProgress = true;
                bgParser.RunWorkerAsync("FOLDER_2_PAK");
            }
        }

        private void bgParser_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }
            string task = (string) e.Argument;

            ResetForm();
            string errorMsg = "Unknown Error";
            if (task == "PAK_2_FOLDER")
            {
                PakManager parser = new PakManager(txtInputFile.Text, txtOutputDir.Text);
                errorMsg = parser.Pak2Folder();
            }
            else if (task == "FOLDER_2_PAK")
            {
                PakManager parser = new PakManager(savePakFile.FileName, txtSavePak.Text);
                errorMsg = parser.Folder2Pak();
            }

            if (errorMsg != null)
            {
                MessageBox.Show(errorMsg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void bgParser_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgParser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processInProgress = false;
        }

        #endregion Event Handlers
    }
}
