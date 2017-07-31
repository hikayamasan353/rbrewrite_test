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
    public partial class Metadata_Form : Form
    {

        public MainForm mf;

        public Metadata_Form()
        {
            InitializeComponent();



            


        }

        private void routeimagebrowsebutton_Click(object sender, EventArgs e)
        {

            //
        }

        




        /// <summary>
        /// Returns route change by clicked radio buttons.
        /// -1 - safety on, service brakes
        /// 0 - safety on, emergency brakes
        /// 1 - safety off, emergency brakes
        /// </summary>
        public int RouteChange
        {
            get
            {
                if (change_radio_minus1.Checked)
                    return -1;
                if (change_radio_0.Checked)
                    return 0;
                if (change_radio_1.Checked)
                    return 1;
                return 0;
            }
            set
            {
                if (value == 0)
                    change_radio_0.Checked = true;
                if (value == 1)
                    change_radio_1.Checked = true;
                if (value == -1)
                    change_radio_minus1.Checked = true;
                else
                    value = 0;
            }
        }


        /// <summary>
        /// Represents route comment setting
        /// </summary>
        public string RouteComment
        {
            get
            {
                return routecommenttextbox.Text;
            }
            set
            {
                routecommenttextbox.Text = value;
            }
        }
        /// <summary>
        /// Represents route gauge setting
        /// </summary>
        public int RouteGauge
        {
            get
            {
                return (int)numgauge.Value;
            }
            set
            {
                numgauge.Value = value;
            }
        }



        

        private void routeimagebrowsebutton_Click_1(object sender, EventArgs e)
        {
            routeimageopendialog.ShowDialog();
            pictureBox1.ImageLocation = routeimageopendialog.FileName;
            labelRouteImage.Text = Path.GetFileName(pictureBox1.ImageLocation);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nexttraincheckbox.Checked)
                IntervalList.Items.Add("-" + numinterval.Value.ToString());
            else
            IntervalList.Items.Add(numinterval.Value.ToString());
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            IntervalList.Items.RemoveAt(IntervalList.SelectedIndex);
        }


        /// <summary>
        /// Okay, let's set it!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.active_project.change = RouteChange;
            MainForm.active_project.description = routecommenttextbox.Text;
            MainForm.active_project.height = (double)elev.Value;

            if (pictureBox1.ImageLocation != "")
            {
                MainForm.active_project.image = pictureBox1.ImageLocation;
            }

            MainForm.active_project.gauge = (int)numgauge.Value;
            MainForm.active_project.lightdir_pitch = (int)ldir1.Value;
            MainForm.active_project.lightdir_yaw = (int)ldir2.Value;

            MainForm.active_project.intervals.Clear();
            for (int i = 0; i < IntervalList.Items.Count; i++)
            {
                MainForm.active_project.intervals.Add(Convert.ToInt32(IntervalList.Items[i].ToString()));
            }


            this.Close();

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// When loading a form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Metadata_Form_Load(object sender, EventArgs e)
        {
            //Assigning settings
            RouteChange = MainForm.active_project.change;
            routecommenttextbox.Text = MainForm.active_project.description;
            numgauge.Value = (decimal)MainForm.active_project.gauge;
            elev.Value = (decimal)MainForm.active_project.height;

            if(MainForm.active_project.image!="")
            {
                pictureBox1.ImageLocation = MainForm.active_project.image;

            }


            ldir1.Value = (decimal)MainForm.active_project.lightdir_pitch;
            ldir2.Value = (decimal)MainForm.active_project.lightdir_yaw;

            IntervalList.Items.Clear();
            for(int i=0;i<MainForm.active_project.intervals.Count;i++)
            {
                IntervalList.Items.Add(MainForm.active_project.intervals[i].ToString());
            }

        }
    }
}
