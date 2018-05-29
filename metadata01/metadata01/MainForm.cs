using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace metadata01
{
    public partial  class MainForm : Form
    {
        public static Project active_project;


        public List<string> exportinterface;
        public StreamWriter exportstream;

        public MainForm()
        {
            InitializeComponent();
                                    
                 ////new project
            active_project = new Project();




        }
        /// <summary>
        /// Metadata form
        /// </summary>
        
        
        private void button1_Click(object sender, EventArgs e)
        {

            //showing a form
            Metadata_Form fm = new Metadata_Form();
            fm.Show();
                       



        }





        private void button2_Click(object sender, EventArgs e)
        {
             Object_Library_Form fol=new Object_Library_Form();
             fol.Show();
        }

        private void WRAMM_Click(object sender, EventArgs e)
        {

            exportinterface = active_project.CSVParsed();

             //Writing all in the text file
            exportstream = new StreamWriter(Application.StartupPath + "\\rud.csv");
                    for(int i=0;i<exportinterface.Count;i++)
                    {
                        exportstream.WriteLine(exportinterface[i]);
                    }
                    exportstream.Close();



        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active_project = new Project();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_modules_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
