using AOS2Ripper.Parsers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AOS2Ripper
{
    public partial class SuGUI : Form
    {
        private bool processInProgress = false;

        public SuGUI()
        {
            InitializeComponent();

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
            txtConsole.Invoke(new Action(() =>
            {
                txtConsole.SelectionStart = txtConsole.TextLength;
                txtConsole.SelectionLength = 0;

                txtConsole.SelectionColor = color;
                AppendConsoleText(text);
                txtConsole.SelectionColor = txtConsole.ForeColor;
            }));
        }

        public void AppendConsoleText(string text)
        {
            txtConsole.Invoke(new Action(() => txtConsole.AppendText(text + "\n")));
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
