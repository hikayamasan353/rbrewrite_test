﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tao.Sdl;
using Tao.OpenGl;

namespace metadata01
{
    public partial class Object_Library_Form : Form
    {

        public List<string> libinterface=new List<string>();


        /// <summary>
        /// Library writer stream
        /// </summary>
        public StreamWriter libwrite;
        /// <summary>
        /// Library reader stream
        /// </summary>
        public StreamReader libread;

        /// <summary>
        /// Object library that is being processed
        /// </summary>
        public ObjectLibrary objectlibrary;


        public Object_Library_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroundOpenFileDialog.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //gndlistbox.Items.Add(GroundOpenFileDialog.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //gndlistbox.Items.RemoveAt(gndlistbox.SelectedIndex);
        }


        /// <summary>
        /// TWEAK LIBRARY FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Object_Library_Form_Load(object sender, EventArgs e)
        {
            //Create a new library
            objectlibrary = new ObjectLibrary();


            //Clearing all items list view
            walllistview.Items.Clear();
            dikelistview.Items.Clear();
            formlistview.Items.Clear();
            rooflistview.Items.Clear();
            cracklistview.Items.Clear();
        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating a new library
            objectlibrary = new metadata01.ObjectLibrary();

            //Clearing all items list view
            walllistview.Items.Clear();
            dikelistview.Items.Clear();
            formlistview.Items.Clear();
            rooflistview.Items.Clear();
            cracklistview.Items.Clear();
        }

        private void btn_addwall_Click(object sender, EventArgs e)
        {

            //objectlibrary.lib_walls.Add(new ObjectLibrary.Wall());

            ListViewItem item = new ListViewItem();
            
            //item.Selected = true;

            
            walllistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White,new Font(walllistview.Font,FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(walllistview.Font, FontStyle.Bold));
            item.Selected = true;

            //Adding the blank wall entry
            objectlibrary.lib_walls.Insert(item.Index, new ObjectLibrary.Wall("Undefined", "Undefined"));

            UpdateIDs();
        }

        private void bckaddbutton_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_deletewall_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < walllistview.SelectedIndices.Count; i++)
            {
                
                int index = walllistview.SelectedIndices[i];
                objectlibrary.lib_walls.RemoveAt(index);
                walllistview.Items.RemoveAt(index);


            }
            UpdateIDs();
        }

        private void btn_addcrack_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            cracklistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(cracklistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(cracklistview.Font, FontStyle.Bold));

            //Adding the blank dike entry
            objectlibrary.lib_cracks.Insert(item.Index, new ObjectLibrary.Crack("Undefined", "Undefined"));
            UpdateIDs();
        }

        private void btn_adddike_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            dikelistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(dikelistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(dikelistview.Font, FontStyle.Bold));

            //Adding the blank dike entry
            objectlibrary.lib_dikes.Insert(item.Index, new ObjectLibrary.Dike("Undefined", "Undefined"));
            UpdateIDs();
        }

        private void btn_deletedike_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dikelistview.SelectedIndices.Count; i++)
            {
                int index = dikelistview.SelectedIndices[i];
                objectlibrary.lib_dikes.RemoveAt(index);
                dikelistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_formadd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            formlistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(formlistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(formlistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(formlistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(formlistview.Font, FontStyle.Bold));


            //Adding the blank platform entry
            objectlibrary.lib_platforms.Insert(item.Index, new ObjectLibrary.Platform("Undefined", "Undefined", "Undefined", "Undefined"));
            UpdateIDs();
        }

        /// <summary>
        /// Update ID's of the items
        /// </summary>
        public void UpdateIDs()
        {
            //Check wall list IDs
            for(int i=0;i<walllistview.Items.Count;i++)
            {
                walllistview.Items[i].Text = walllistview.Items.IndexOf(walllistview.Items[i]).ToString();
            }
            //Check dike list IDs
            for (int i = 0; i < dikelistview.Items.Count; i++)
            {
                dikelistview.Items[i].Text = dikelistview.Items.IndexOf(dikelistview.Items[i]).ToString();
            }

            //Check ground list IDs
            for (int i = 0; i < gndlistview.Items.Count; i++)
            {
                gndlistview.Items[i].Text = gndlistview.Items.IndexOf(gndlistview.Items[i]).ToString();
            }

            //Check rail list IDs
            for (int i = 0; i < raillistview.Items.Count; i++)
            {
                raillistview.Items[i].Text = raillistview.Items.IndexOf(raillistview.Items[i]).ToString();
            }

            //Check form list IDs
            for (int i = 0; i < formlistview.Items.Count; i++)
            {
                formlistview.Items[i].Text = formlistview.Items.IndexOf(formlistview.Items[i]).ToString();
            }
            //Check roof list IDs
            for (int i = 0; i < rooflistview.Items.Count; i++)
            {
                rooflistview.Items[i].Text = rooflistview.Items.IndexOf(rooflistview.Items[i]).ToString();
            }

            //Check crack list IDs
            for (int i=0;i<cracklistview.Items.Count;i++)
            {
                cracklistview.Items[i].Text = cracklistview.Items.IndexOf(cracklistview.Items[i]).ToString();
            }

            //Check Freeobj list IDs
            for (int i = 0; i < freeobjlistview.Items.Count; i++)
            {
                freeobjlistview.Items[i].Text = freeobjlistview.Items.IndexOf(freeobjlistview.Items[i]).ToString();
            }

            //Check pole list IDs
            for (int i = 0; i < polelistview.Items.Count; i++)
            {
                polelistview.Items[i].Text = polelistview.Items.IndexOf(polelistview.Items[i]).ToString();
            }

            //Check beacon list IDs
            for (int i = 0; i < beaconlistview.Items.Count; i++)
            {
                beaconlistview.Items[i].Text = beaconlistview.Items.IndexOf(beaconlistview.Items[i]).ToString();
            }




        }

        private void walllistview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_deletecrack_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cracklistview.SelectedIndices.Count; i++)
            {
                int index = cracklistview.SelectedIndices[i];
                objectlibrary.lib_cracks.RemoveAt(index);
                cracklistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_roofadd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            rooflistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));


            //Adding the blank roof entry
            objectlibrary.lib_roofs.Insert(item.Index, new ObjectLibrary.Roof("Undefined", "Undefined", "Undefined", "Undefined"));
            UpdateIDs();
        }

        private void btn_formdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < formlistview.SelectedIndices.Count; i++)
            {
                int index = formlistview.SelectedIndices[i];
                objectlibrary.lib_platforms.RemoveAt(index);
                formlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_roofdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rooflistview.SelectedIndices.Count; i++)
            {
                int index = rooflistview.SelectedIndices[i];
                objectlibrary.lib_roofs.RemoveAt(index);
                rooflistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_freeobjadd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            freeobjlistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));


            //Adding the blank roof entry
            objectlibrary.lib_freeobjs.Insert(item.Index, new ObjectLibrary.FreeObj("Undefined"));
            UpdateIDs();
        }

        private void btn_freeobjdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < freeobjlistview.SelectedIndices.Count; i++)
            {
                int index = freeobjlistview.SelectedIndices[i];
                objectlibrary.lib_freeobjs.RemoveAt(index);
                freeobjlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_poleadd_Click(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem();


            polelistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add(numericUpDown1.Value.ToString(), Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));


            //Adding the blank roof entry
            objectlibrary.lib_poles.Insert(item.Index, new ObjectLibrary.Pole("Undefined", (int)numericUpDown1.Value));
            UpdateIDs();

        }

        private void btn_poledelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < polelistview.SelectedIndices.Count; i++)
            {
                int index = polelistview.SelectedIndices[i];
                objectlibrary.lib_poles.RemoveAt(index);
                polelistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_beaconadd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            beaconlistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));


            //Adding the blank roof entry
            objectlibrary.lib_beacons.Insert(item.Index, new ObjectLibrary.Beacon("Undefined"));
            UpdateIDs();
        }

        private void btn_beacondelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < beaconlistview.SelectedIndices.Count; i++)
            {
                int index = beaconlistview.SelectedIndices[i];
                objectlibrary.lib_beacons.RemoveAt(index);
                beaconlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_gndadd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();


            gndlistview.Items.Add(item); //Adding the item
            item.Text = item.Index.ToString(); //Making the item's index as the item's number
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));


            //Adding the blank roof entry
            objectlibrary.lib_grounds.Insert(item.Index, new ObjectLibrary.Ground("Undefined"));
            UpdateIDs();
        }

        private void btn_gnddelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gndlistview.SelectedIndices.Count; i++)
            {
                int index = gndlistview.SelectedIndices[i];
                objectlibrary.lib_grounds.RemoveAt(index);
                gndlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_formchooseleft_Click(object sender, EventArgs e)
        {

        }


        //
        //Temporary code: Export the object library as CSV code
        private void button3_Click(object sender, EventArgs e)
        {
            //String list for exporting
            List<string> exportinterface = new List<string>();

            //Adding grounds
            for (int i = 0; i < objectlibrary.lib_grounds.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_grounds[i].CSVParsed(i));
            }
            //Adding rails
            for (int i = 0; i < objectlibrary.lib_rails.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_rails[i].CSVParsed(i));
            }
            //Adding walls and dikes
            for (int i = 0; i < objectlibrary.lib_walls.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_walls[i].CSVParsed(i));
            }
            for (int i = 0; i < objectlibrary.lib_dikes.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_dikes[i].CSVParsed(i));
            }
            //Adding roofs
            for (int i = 0; i < objectlibrary.lib_platforms.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_platforms[i].CSVParsed(i));
            }
            for (int i = 0; i < objectlibrary.lib_roofs.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_roofs[i].CSVParsed(i));
            }
            //Adding poles
            for(int i=0;i<objectlibrary.lib_poles.Count;i++)
            {
                exportinterface.Add(objectlibrary.lib_poles[i].CSVParsed(i));
            }
            //Adding cracks
            for(int i=0;i<objectlibrary.lib_cracks.Count;i++)
            {
                exportinterface.Add(objectlibrary.lib_cracks[i].CSVParsed(i));
            }
            //Adding freeobjs
            for(int i=0;i<objectlibrary.lib_freeobjs.Count;i++)
            {
                exportinterface.Add(objectlibrary.lib_freeobjs[i].CSVParsed(i));
            }
            //Adding beacons
            for (int i = 0; i < objectlibrary.lib_beacons.Count; i++)
            {
                exportinterface.Add(objectlibrary.lib_beacons[i].CSVParsed(i));
            }

            StreamWriter exportstream = new StreamWriter(Application.StartupPath + "\\dna.txt");
            for (int i = 0; i < exportinterface.Count; i++)
            {
                exportstream.WriteLine(exportinterface[i]);
            }
            exportstream.Close();



        }

        private void btn_RailAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            raillistview.Items.Add(item);
            item.Text = item.Index.ToString();
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));

            objectlibrary.lib_rails.Insert(item.Index, new ObjectLibrary.Rail("Undefined"));
            UpdateIDs();



        }

        private void btn_RailDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < raillistview.SelectedIndices.Count; i++)
            {
                int index = raillistview.SelectedIndices[i];
                objectlibrary.lib_rails.RemoveAt(index);
                raillistview.Items.RemoveAt(index);
            }
            UpdateIDs();

        }
    }
}
