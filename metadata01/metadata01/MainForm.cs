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
        public static RBProject active_project;


        public List<string> exportinterface;
        public StreamWriter exportstream;



        //Testing workspace code
        Graphics ws_graphics;
        Pen ws_pen;
        Brush ws_brush;
        Timer ws_timer = new Timer();

        //Mouse coordinates
        int mouse_x, mouse_y = 0;

        public MainForm()
        {
            InitializeComponent();
                                    
            //new project
            active_project = new RBProject();
            active_project.library = new RBObjectLibrary();

            //initialize workspace
            ws_graphics = Workspace.CreateGraphics();
            ws_timer.Interval = 10;


            ws_timer.Tick += new EventHandler(ws_timer_Tick); 
            ws_timer.Start();
            Workspace.MouseMove += new MouseEventHandler(ws_MouseMove);
            //Initialize coordinates status label
            statuslabel_coordinates.Text = "X="+mouse_x.ToString() + ", Y=" + mouse_y.ToString();




        }

        private void ws_MouseMove(object sender, EventArgs e)
        {
            mouse_x = Cursor.Position.X;
            mouse_y = Cursor.Position.Y;
            statuslabel_coordinates.Text = "X=" + mouse_x.ToString() + ", Y=" + mouse_y.ToString();



        }

        private void ws_timer_Tick(object sender, EventArgs e)
        {
            ws_graphics.Clear(Color.Green);
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active_project = new RBProject();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_modules_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportinterface = active_project.CSVParsed();

            //Writing all in the text file
            exportstream = new StreamWriter(Application.StartupPath + "\\rud.csv");
            for (int i = 0; i < exportinterface.Count; i++)
            {
                exportstream.WriteLine(exportinterface[i]);
            }
            exportstream.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
