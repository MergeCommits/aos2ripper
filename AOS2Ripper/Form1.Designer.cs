namespace AOS2Ripper
{
    partial class SuGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuGUI));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.lblOutputDir = new System.Windows.Forms.Label();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSavePak = new System.Windows.Forms.Label();
            this.txtSavePak = new System.Windows.Forms.TextBox();
            this.btnSavePak = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnPAK_2_FOLDER = new System.Windows.Forms.Button();
            this.btn_FOLDER_2_PAK = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.inputPakDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.savePakFile = new System.Windows.Forms.SaveFileDialog();
            this.inputDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bgParser = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.btnOutputDir, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnInputFile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOutputDir, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtInputFile, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOutputDir, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblInputFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSavePak, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSavePak, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSavePak, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnPAK_2_FOLDER, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_FOLDER_2_PAK, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConsole, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(355, 69);
            this.btnOutputDir.Margin = new System.Windows.Forms.Padding(10, 2, 3, 3);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(27, 23);
            this.btnOutputDir.TabIndex = 3;
            this.btnOutputDir.Text = "...";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.outputDirBtn_Click);
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(355, 37);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(10, 5, 3, 3);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(27, 23);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "...";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.inputFileBtn_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.Location = new System.Drawing.Point(103, 70);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(239, 20);
            this.txtOutputDir.TabIndex = 2;
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(103, 38);
            this.txtInputFile.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(239, 20);
            this.txtInputFile.TabIndex = 0;
            // 
            // lblOutputDir
            // 
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new System.Drawing.Point(3, 70);
            this.lblOutputDir.Margin = new System.Windows.Forms.Padding(3);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Size = new System.Drawing.Size(87, 13);
            this.lblOutputDir.TabIndex = 4;
            this.lblOutputDir.Text = "Output Directory:";
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(3, 38);
            this.lblInputFile.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(53, 13);
            this.lblInputFile.TabIndex = 1;
            this.lblInputFile.Text = "Input File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Convert AOS2 Texture Data to PNG";
            // 
            // lblSavePak
            // 
            this.lblSavePak.AutoSize = true;
            this.lblSavePak.Location = new System.Drawing.Point(423, 38);
            this.lblSavePak.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblSavePak.Name = "lblSavePak";
            this.lblSavePak.Size = new System.Drawing.Size(52, 13);
            this.lblSavePak.TabIndex = 8;
            this.lblSavePak.Text = "Directory:";
            // 
            // txtSavePak
            // 
            this.txtSavePak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePak.Location = new System.Drawing.Point(523, 38);
            this.txtSavePak.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtSavePak.Name = "txtSavePak";
            this.txtSavePak.Size = new System.Drawing.Size(239, 20);
            this.txtSavePak.TabIndex = 5;
            // 
            // btnSavePak
            // 
            this.btnSavePak.Location = new System.Drawing.Point(775, 37);
            this.btnSavePak.Margin = new System.Windows.Forms.Padding(10, 5, 3, 3);
            this.btnSavePak.Name = "btnSavePak";
            this.btnSavePak.Size = new System.Drawing.Size(27, 23);
            this.btnSavePak.TabIndex = 6;
            this.btnSavePak.Text = "...";
            this.btnSavePak.UseVisualStyleBackColor = true;
            this.btnSavePak.Click += new System.EventHandler(this.btnSavePak_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Location = new System.Drawing.Point(423, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Convert Directory to AOS2 Texture Data";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar, 6);
            this.progressBar.Location = new System.Drawing.Point(3, 346);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(835, 23);
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // btnPAK_2_FOLDER
            // 
            this.btnPAK_2_FOLDER.Location = new System.Drawing.Point(3, 105);
            this.btnPAK_2_FOLDER.Name = "btnPAK_2_FOLDER";
            this.btnPAK_2_FOLDER.Size = new System.Drawing.Size(75, 23);
            this.btnPAK_2_FOLDER.TabIndex = 4;
            this.btnPAK_2_FOLDER.Text = "Parse Data";
            this.btnPAK_2_FOLDER.UseVisualStyleBackColor = true;
            this.btnPAK_2_FOLDER.Click += new System.EventHandler(this.btnPak2Dir_Click);
            // 
            // btn_FOLDER_2_PAK
            // 
            this.btn_FOLDER_2_PAK.Location = new System.Drawing.Point(423, 105);
            this.btn_FOLDER_2_PAK.Name = "btn_FOLDER_2_PAK";
            this.btn_FOLDER_2_PAK.Size = new System.Drawing.Size(87, 23);
            this.btn_FOLDER_2_PAK.TabIndex = 7;
            this.btn_FOLDER_2_PAK.Text = "Package Data";
            this.btn_FOLDER_2_PAK.UseVisualStyleBackColor = true;
            this.btn_FOLDER_2_PAK.Click += new System.EventHandler(this.btnDir2Pak_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtConsole, 6);
            this.txtConsole.Location = new System.Drawing.Point(3, 140);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtConsole.Size = new System.Drawing.Size(835, 200);
            this.txtConsole.TabIndex = 18;
            this.txtConsole.TabStop = false;
            this.txtConsole.Text = "";
            // 
            // inputPakDialog
            // 
            this.inputPakDialog.Filter = "AOS2 Data File (*.PAK)|*.PAK";
            this.inputPakDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.inputPakFileDialogue_FileOk);
            // 
            // outputDirDialog
            // 
            this.outputDirDialog.Description = "Choose a directory to save the .pak to";
            // 
            // savePakFile
            // 
            this.savePakFile.Filter = "AOS2 Data File (*.pak)|*.pak";
            // 
            // bgParser
            // 
            this.bgParser.WorkerReportsProgress = true;
            this.bgParser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgParser_DoWork);
            // 
            // SuGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuGUI";
            this.Text = "Acceleration of SuGUI 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.OpenFileDialog inputPakDialog;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label lblOutputDir;
        private System.Windows.Forms.FolderBrowserDialog outputDirDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSavePak;
        private System.Windows.Forms.TextBox txtSavePak;
        private System.Windows.Forms.Button btnSavePak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnPAK_2_FOLDER;
        private System.Windows.Forms.Button btn_FOLDER_2_PAK;
        private System.Windows.Forms.SaveFileDialog savePakFile;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.FolderBrowserDialog inputDirDialog;
        private System.ComponentModel.BackgroundWorker bgParser;
    }
}

