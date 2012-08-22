namespace FilesConcentrator
{
    partial class FrmMain
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
            this.BtnCopyStart = new System.Windows.Forms.Button();
            this.folderBrowserMaster = new System.Windows.Forms.FolderBrowserDialog();
            this.btnMasterSelect = new System.Windows.Forms.Button();
            this.btnSourcesAdd = new System.Windows.Forms.Button();
            this.txtMasterDirectory = new System.Windows.Forms.TextBox();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserSource = new System.Windows.Forms.FolderBrowserDialog();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnCopyUsingFileDatabaseStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSimpleCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCopyStart
            // 
            this.BtnCopyStart.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopyStart.Location = new System.Drawing.Point(404, 145);
            this.BtnCopyStart.Name = "BtnCopyStart";
            this.BtnCopyStart.Size = new System.Drawing.Size(235, 23);
            this.BtnCopyStart.TabIndex = 0;
            this.BtnCopyStart.Text = "Copy (NO DOUBLES)";
            this.BtnCopyStart.UseVisualStyleBackColor = true;
            this.BtnCopyStart.Click += new System.EventHandler(this.BtnCopyStart_Click);
            // 
            // folderBrowserMaster
            // 
            this.folderBrowserMaster.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnMasterSelect
            // 
            this.btnMasterSelect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterSelect.Location = new System.Drawing.Point(404, 25);
            this.btnMasterSelect.Name = "btnMasterSelect";
            this.btnMasterSelect.Size = new System.Drawing.Size(235, 23);
            this.btnMasterSelect.TabIndex = 1;
            this.btnMasterSelect.Text = "Set output directory";
            this.btnMasterSelect.UseVisualStyleBackColor = true;
            this.btnMasterSelect.Click += new System.EventHandler(this.btnMasterSelect_Click);
            // 
            // btnSourcesAdd
            // 
            this.btnSourcesAdd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourcesAdd.Location = new System.Drawing.Point(404, 54);
            this.btnSourcesAdd.Name = "btnSourcesAdd";
            this.btnSourcesAdd.Size = new System.Drawing.Size(235, 23);
            this.btnSourcesAdd.TabIndex = 2;
            this.btnSourcesAdd.Text = "Add source directory";
            this.btnSourcesAdd.UseVisualStyleBackColor = true;
            this.btnSourcesAdd.Click += new System.EventHandler(this.btnSourceSelect_Click);
            // 
            // txtMasterDirectory
            // 
            this.txtMasterDirectory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterDirectory.Location = new System.Drawing.Point(12, 25);
            this.txtMasterDirectory.Name = "txtMasterDirectory";
            this.txtMasterDirectory.Size = new System.Drawing.Size(346, 23);
            this.txtMasterDirectory.TabIndex = 3;
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDirectory.Location = new System.Drawing.Point(12, 70);
            this.txtSourceDirectory.Multiline = true;
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.Size = new System.Drawing.Size(346, 98);
            this.txtSourceDirectory.TabIndex = 4;
            // 
            // folderBrowserSource
            // 
            this.folderBrowserSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // txtReport
            // 
            this.txtReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtReport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReport.Location = new System.Drawing.Point(0, 197);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ReadOnly = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReport.Size = new System.Drawing.Size(801, 315);
            this.txtReport.TabIndex = 5;
            // 
            // btnCopyUsingFileDatabaseStart
            // 
            this.btnCopyUsingFileDatabaseStart.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyUsingFileDatabaseStart.Location = new System.Drawing.Point(404, 83);
            this.btnCopyUsingFileDatabaseStart.Name = "btnCopyUsingFileDatabaseStart";
            this.btnCopyUsingFileDatabaseStart.Size = new System.Drawing.Size(235, 56);
            this.btnCopyUsingFileDatabaseStart.TabIndex = 6;
            this.btnCopyUsingFileDatabaseStart.Text = "Copy using previous MD5 file database (NO DOUBLES)";
            this.btnCopyUsingFileDatabaseStart.UseVisualStyleBackColor = true;
            this.btnCopyUsingFileDatabaseStart.Click += new System.EventHandler(this.btnCopyUsingFileDatabaseStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Output directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Source directories:";
            // 
            // btnSimpleCopy
            // 
            this.btnSimpleCopy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpleCopy.Location = new System.Drawing.Point(656, 25);
            this.btnSimpleCopy.Name = "btnSimpleCopy";
            this.btnSimpleCopy.Size = new System.Drawing.Size(133, 147);
            this.btnSimpleCopy.TabIndex = 9;
            this.btnSimpleCopy.Text = "Simple copy (Allows doubles)";
            this.btnSimpleCopy.UseVisualStyleBackColor = true;
            this.btnSimpleCopy.Click += new System.EventHandler(this.btnSimpleCopy_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 512);
            this.Controls.Add(this.btnSimpleCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyUsingFileDatabaseStart);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.txtMasterDirectory);
            this.Controls.Add(this.btnSourcesAdd);
            this.Controls.Add(this.btnMasterSelect);
            this.Controls.Add(this.BtnCopyStart);
            this.Name = "FrmMain";
            this.Text = "Files Concentrator ";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCopyStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserMaster;
        private System.Windows.Forms.Button btnMasterSelect;
        private System.Windows.Forms.Button btnSourcesAdd;
        private System.Windows.Forms.TextBox txtMasterDirectory;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserSource;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Button btnCopyUsingFileDatabaseStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSimpleCopy;
    }
}

