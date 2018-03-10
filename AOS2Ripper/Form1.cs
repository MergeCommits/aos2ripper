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
        }

        public void AppendConsoleText(string text, Color color)
        {
            txtConsole.Invoke(new Action(() => AppendConsoleWithColor(text, color)));
        }

        private void AppendConsoleWithColor(string text, Color color)
        {
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.SelectionLength = 0;

            txtConsole.SelectionColor = color;
            txtConsole.AppendText(text + "\n");
            txtConsole.SelectionColor = txtConsole.ForeColor;
        }

        public void AppendConsoleText(string text)
        {
            txtConsole.Invoke(new Action(() => txtConsole.AppendText(text + "\n")));
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
            txtConsole.Clear();

            Thread th = new Thread(PAK_2_DIR);
            th.Name = "PAK2DIR";
            th.Start();
        }

        private void PAK_2_DIR()
        {
            PakManager parser = new PakManager(txtInputFile.Text, txtOutputDir.Text);

            string uh = parser.Pak2Folder();
            if (uh != null)
            {
                MessageBox.Show(uh, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            processInProgress = false;
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
        /// Parses folder tp .PAK.
        /// </summary>
        private void btnDir2Pak_Click(object sender, EventArgs e)
        {
            if (processInProgress) { return; }
            processInProgress = true;
            txtConsole.Clear();

            if (savePakFile.ShowDialog() == DialogResult.OK)
            {
                Thread th = new Thread(DIR_2_PAK);
                th.Name = "DIR2PAK";
                th.Start();
            }
        }

        private void DIR_2_PAK()
        {
            PakManager parser = new PakManager(savePakFile.FileName, txtSavePak.Text);

            string uh = parser.Folder2Pak();
            if (uh != null)
            {
                MessageBox.Show(uh, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            processInProgress = false;
        }

        #endregion Event Handlers
    }
}
