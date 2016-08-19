namespace metadata01
{
    partial class OptionsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_BVEDirectory = new System.Windows.Forms.GroupBox();
            this.label_BVEDirectoryString = new System.Windows.Forms.Label();
            this.buttonBrowseBVEDirectory = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BVEFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lab_objlibfoldername = new System.Windows.Forms.Label();
            this.textbox_objlibfoldername = new System.Windows.Forms.TextBox();
            this.btn_optionsOK = new System.Windows.Forms.Button();
            this.btn_optionsCancel = new System.Windows.Forms.Button();
            this.lab_BVEDirPath = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_BVEDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 223);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textbox_objlibfoldername);
            this.tabPage1.Controls.Add(this.lab_objlibfoldername);
            this.tabPage1.Controls.Add(this.groupBox_BVEDirectory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(312, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox_BVEDirectory
            // 
            this.groupBox_BVEDirectory.Controls.Add(this.lab_BVEDirPath);
            this.groupBox_BVEDirectory.Controls.Add(this.label_BVEDirectoryString);
            this.groupBox_BVEDirectory.Controls.Add(this.buttonBrowseBVEDirectory);
            this.groupBox_BVEDirectory.Location = new System.Drawing.Point(6, 6);
            this.groupBox_BVEDirectory.Name = "groupBox_BVEDirectory";
            this.groupBox_BVEDirectory.Size = new System.Drawing.Size(300, 47);
            this.groupBox_BVEDirectory.TabIndex = 3;
            this.groupBox_BVEDirectory.TabStop = false;
            this.groupBox_BVEDirectory.Text = "BVE Directory";
            // 
            // label_BVEDirectoryString
            // 
            this.label_BVEDirectoryString.AutoSize = true;
            this.label_BVEDirectoryString.Location = new System.Drawing.Point(6, 16);
            this.label_BVEDirectoryString.Name = "label_BVEDirectoryString";
            this.label_BVEDirectoryString.Size = new System.Drawing.Size(0, 13);
            this.label_BVEDirectoryString.TabIndex = 2;
            // 
            // buttonBrowseBVEDirectory
            // 
            this.buttonBrowseBVEDirectory.Location = new System.Drawing.Point(219, 16);
            this.buttonBrowseBVEDirectory.Name = "buttonBrowseBVEDirectory";
            this.buttonBrowseBVEDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseBVEDirectory.TabIndex = 1;
            this.buttonBrowseBVEDirectory.Text = "Browse";
            this.buttonBrowseBVEDirectory.UseVisualStyleBackColor = true;
            this.buttonBrowseBVEDirectory.Click += new System.EventHandler(this.buttonBrowseBVEDirectory_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(312, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BVEFolderBrowserDialog
            // 
            this.BVEFolderBrowserDialog.HelpRequest += new System.EventHandler(this.BVEFolderBrowserDialog_HelpRequest);
            // 
            // lab_objlibfoldername
            // 
            this.lab_objlibfoldername.AutoSize = true;
            this.lab_objlibfoldername.Location = new System.Drawing.Point(6, 60);
            this.lab_objlibfoldername.Name = "lab_objlibfoldername";
            this.lab_objlibfoldername.Size = new System.Drawing.Size(126, 13);
            this.lab_objlibfoldername.TabIndex = 4;
            this.lab_objlibfoldername.Text = "Object library folder name";
            // 
            // textbox_objlibfoldername
            // 
            this.textbox_objlibfoldername.Location = new System.Drawing.Point(139, 60);
            this.textbox_objlibfoldername.Name = "textbox_objlibfoldername";
            this.textbox_objlibfoldername.Size = new System.Drawing.Size(167, 20);
            this.textbox_objlibfoldername.TabIndex = 5;
            this.textbox_objlibfoldername.TextChanged += new System.EventHandler(this.textbox_objlibfoldername_TextChanged);
            // 
            // btn_optionsOK
            // 
            this.btn_optionsOK.Location = new System.Drawing.Point(13, 243);
            this.btn_optionsOK.Name = "btn_optionsOK";
            this.btn_optionsOK.Size = new System.Drawing.Size(75, 23);
            this.btn_optionsOK.TabIndex = 1;
            this.btn_optionsOK.Text = "OK";
            this.btn_optionsOK.UseVisualStyleBackColor = true;
            this.btn_optionsOK.Click += new System.EventHandler(this.btn_optionsOK_Click);
            // 
            // btn_optionsCancel
            // 
            this.btn_optionsCancel.Location = new System.Drawing.Point(95, 243);
            this.btn_optionsCancel.Name = "btn_optionsCancel";
            this.btn_optionsCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_optionsCancel.TabIndex = 2;
            this.btn_optionsCancel.Text = "Cancel";
            this.btn_optionsCancel.UseVisualStyleBackColor = true;
            // 
            // lab_BVEDirPath
            // 
            this.lab_BVEDirPath.AutoSize = true;
            this.lab_BVEDirPath.Location = new System.Drawing.Point(12, 21);
            this.lab_BVEDirPath.Name = "lab_BVEDirPath";
            this.lab_BVEDirPath.Size = new System.Drawing.Size(0, 13);
            this.lab_BVEDirPath.TabIndex = 3;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 280);
            this.Controls.Add(this.btn_optionsCancel);
            this.Controls.Add(this.btn_optionsOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox_BVEDirectory.ResumeLayout(false);
            this.groupBox_BVEDirectory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox_BVEDirectory;
        private System.Windows.Forms.Label label_BVEDirectoryString;
        private System.Windows.Forms.Button buttonBrowseBVEDirectory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog BVEFolderBrowserDialog;
        private System.Windows.Forms.TextBox textbox_objlibfoldername;
        private System.Windows.Forms.Label lab_objlibfoldername;
        private System.Windows.Forms.Label lab_BVEDirPath;
        private System.Windows.Forms.Button btn_optionsOK;
        private System.Windows.Forms.Button btn_optionsCancel;
    }
}