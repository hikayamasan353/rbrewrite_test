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

        /// <summary>
        /// Processes a string by replacing some characters with directives
        /// </summary>
        /// <param name="s">String to be processed</param>
        public string ProcessString(string s)
        {
            string s1;


            /*
 * placeholders for parentheses
 * "\u0024Chr(40)" - left
 * "\u0024Chr(41)" - right
 */
            if (s.Contains('('))
            {
                s = s.Replace('('.ToString(), "_leftparenthesis_");
            }
            if (s.Contains(')'))
            {
                s = s.Replace(')'.ToString(), "_rightparenthesis_");
            }




            if (s.Contains(','))
            {
                s = s.Replace(','.ToString(), "\u0024Chr(44)");
            }



            if (s.Contains(';'))
            {
                s = s.Replace(';'.ToString(), "\u0024Chr(59)");
            }
            if (s.Contains("\r\n"))
            {
                s = s.Replace("\r\n", "\u0024Chr(13)\u0024Chr(10)");
            }

            //processing placeholders
            if (s.Contains("_leftparenthesis_"))
            {
                s = s.Replace("_leftparenthesis_", "\u0024Chr(40)");
            }
            if (s.Contains("_rightparenthesis_"))
            {
                s = s.Replace("_rightparenthesis_", "\u0024Chr(41)");
            }
            s1 = s;
            return s1;

        }



        private void button2_Click(object sender, EventArgs e)
        {
             Object_Library_Form fol=new Object_Library_Form();
             fol.Show();
        }

        private void WRAMM_Click(object sender, EventArgs e)
        {

            ///TEMPORARY EXPORT
            ///

            //Creating a new export interface string list
            exportinterface = new List<string>();
            //Header
            exportinterface.Add("With Route");
            //Comment with processed string
            exportinterface.Add(".Comment "+ProcessString(active_project.description));
            //Change
            exportinterface.Add(".Change " + active_project.change.ToString());
            //Gauge
            exportinterface.Add(".Gauge "+active_project.gauge.ToString());


            if ((active_project.image != "") || (active_project.image != null))
            {
                exportinterface.Add(".Image " + active_project.image);
            }



            //Run interval
            //decraring a string for run intervals
            string runinterval = "";
            for(int i=0;i<active_project.intervals.Count;i++)
            {
                runinterval += active_project.intervals[i].ToString() + ";";
            }
            exportinterface.Add(".RunInterval " + runinterval);

            //Height
            exportinterface.Add(".Height " + active_project.height);

            //Light direction
            exportinterface.Add(".LightDirection " + active_project.lightdir_pitch.ToString() + ";" + active_project.lightdir_yaw.ToString());





            //TODO: Structure export
            //At this time, just a header...
            exportinterface.Add("With Structure");




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
    }
}
