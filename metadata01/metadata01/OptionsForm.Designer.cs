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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BVEFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseBVEDirectory = new System.Windows.Forms.Button();
            this.label_BVEDirectoryString = new System.Windows.Forms.Label();
            this.groupBox_BVEDirectory = new System.Windows.Forms.GroupBox();
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
            this.tabPage1.Controls.Add(this.groupBox_BVEDirectory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(312, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseBVEDirectory
            // 
            this.buttonBrowseBVEDirectory.Location = new System.Drawing.Point(219, 16);
            this.buttonBrowseBVEDirectory.Name = "buttonBrowseBVEDirectory";
            this.buttonBrowseBVEDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseBVEDirectory.TabIndex = 1;
            this.buttonBrowseBVEDirectory.Text = "Browse";
            this.buttonBrowseBVEDirectory.UseVisualStyleBackColor = true;
            // 
            // label_BVEDirectoryString
            // 
            this.label_BVEDirectoryString.AutoSize = true;
            this.label_BVEDirectoryString.Location = new System.Drawing.Point(6, 16);
            this.label_BVEDirectoryString.Name = "label_BVEDirectoryString";
            this.label_BVEDirectoryString.Size = new System.Drawing.Size(0, 13);
            this.label_BVEDirectoryString.TabIndex = 2;
            // 
            // groupBox_BVEDirectory
            // 
            this.groupBox_BVEDirectory.Controls.Add(this.label_BVEDirectoryString);
            this.groupBox_BVEDirectory.Controls.Add(this.buttonBrowseBVEDirectory);
            this.groupBox_BVEDirectory.Location = new System.Drawing.Point(6, 6);
            this.groupBox_BVEDirectory.Name = "groupBox_BVEDirectory";
            this.groupBox_BVEDirectory.Size = new System.Drawing.Size(300, 47);
            this.groupBox_BVEDirectory.TabIndex = 3;
            this.groupBox_BVEDirectory.TabStop = false;
            this.groupBox_BVEDirectory.Text = "BVE Directory";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 248);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
    }
}