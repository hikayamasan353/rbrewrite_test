using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metadata01
{
    public partial class OptionsForm : Form
    {
        /// <summary>
        /// Options being processed
        /// </summary>
        public Options options;


        public OptionsForm()
        {
            InitializeComponent();
            options = new Options();
            BVEFolderBrowserDialog.SelectedPath = options.BVEDirectory;
            lab_BVEDirPath.Text = options.BVEDirectory;
            textbox_objlibfoldername.Text = options.ObjectLibDir;
        }

        private void buttonBrowseBVEDirectory_Click(object sender, EventArgs e)
        {
            BVEFolderBrowserDialog.ShowDialog();
            options.BVEDirectory = BVEFolderBrowserDialog.SelectedPath;
            lab_BVEDirPath.Text = options.BVEDirectory;
        }

        private void BVEFolderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textbox_objlibfoldername_TextChanged(object sender, EventArgs e)
        {
            options.ObjectLibDir = textbox_objlibfoldername.Text;
        }

        private void btn_optionsOK_Click(object sender, EventArgs e)
        {
            options.SaveToFile();
            this.Close();
            this.Dispose();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            options.ReadFromFile();

        }
    }
}
