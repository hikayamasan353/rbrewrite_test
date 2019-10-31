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
        public ObjectLibrary active_objectlibrary;


        public Object_Library_Form()
        {
            InitializeComponent();

            active_objectlibrary = MainForm.active_project.library;

            //Fetch items according to the active project's data

            //Backgrounds
            for(int i=0;i<active_objectlibrary.lib_backgrounds.Count;i++)
            {
                BckListBox.Items.Add(active_objectlibrary.lib_backgrounds[i].filename);
            }






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

            //Fetch the object library of the active project
            active_objectlibrary = MainForm.active_project.library;
            //Update the menu contents
            UpdateMenus();

            
        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating a new library
            active_objectlibrary = new ObjectLibrary();

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
            active_objectlibrary.lib_walls.Insert(item.Index, new ObjectLibrary.Wall("Undefined", "Undefined"));

            UpdateIDs();
        }

        private void bckaddbutton_Click(object sender, EventArgs e)
        {
            BackgroundOpenFileDialog.ShowDialog();
            active_objectlibrary.lib_backgrounds.Add(new ObjectLibrary.Background(BackgroundOpenFileDialog.FileName));
            BckListBox.Items.Add(BackgroundOpenFileDialog.FileName);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = BckListBox.SelectedIndex;
            bckpreviewpicbox.ImageLocation = active_objectlibrary.lib_backgrounds[index].filename;
        }

        private void btn_deletewall_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < walllistview.SelectedIndices.Count; i++)
            {
                
                int index = walllistview.SelectedIndices[i];
                active_objectlibrary.lib_walls.RemoveAt(index);
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
            active_objectlibrary.lib_cracks.Insert(item.Index, new ObjectLibrary.Crack("Undefined", "Undefined"));
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
            active_objectlibrary.lib_dikes.Insert(item.Index, new ObjectLibrary.Dike("Undefined", "Undefined"));
            UpdateIDs();
        }

        private void btn_deletedike_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dikelistview.SelectedIndices.Count; i++)
            {
                int index = dikelistview.SelectedIndices[i];
                active_objectlibrary.lib_dikes.RemoveAt(index);
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
            active_objectlibrary.lib_platforms.Insert(item.Index, new ObjectLibrary.Platform("Undefined", "Undefined", "Undefined", "Undefined"));
            UpdateIDs();
        }

        /// <summary>
        /// Update menu contents
        /// </summary>
        public void UpdateMenus()
        {
            //Clearing all items list view
            gndlistview.Items.Clear(); //Grounds
            walllistview.Items.Clear(); //Walls
            dikelistview.Items.Clear(); //Dikes
            formlistview.Items.Clear(); //Platforms
            rooflistview.Items.Clear(); //Roofs
            cracklistview.Items.Clear(); //Cracks
            polelistview.Items.Clear(); //Poles

            //Todo: Add the menu items which correspond with the project's worked object library items

            //Backgrounds
            for (int i = 0; i < active_objectlibrary.lib_backgrounds.Count; i++)
            {

            }
            //Grounds
            for (int i = 0; i < active_objectlibrary.lib_grounds.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();

                ListViewItem item2 = new ListViewItem();
                item2.Text = i.ToString();

                gndlistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_grounds[i].filename);
                gndlistview2.Items.Insert(i, item2);
                item2.SubItems.Add(active_objectlibrary.lib_grounds[i].filename);

            }
            //Rails
            for (int i = 0; i < active_objectlibrary.lib_rails.Count; i++)
            {
                //For main rail menu
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                //For cycle rail menu
                ListViewItem item2 = new ListViewItem();
                item2.Text = i.ToString();


                raillistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_rails[i].filename);
                raillistview2.Items.Insert(i, item2);
                item2.SubItems.Add(active_objectlibrary.lib_rails[i].filename);

            }
            //Walls
            for (int i = 0; i < active_objectlibrary.lib_walls.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();

                walllistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_walls[i].filename_L);
                item.SubItems.Add(active_objectlibrary.lib_walls[i].filename_R);

            }
            //Dikes
            for (int i = 0; i < active_objectlibrary.lib_dikes.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();

                dikelistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_dikes[i].filename_L);
                item.SubItems.Add(active_objectlibrary.lib_dikes[i].filename_R);

            }
            //Platforms
            for (int i = 0; i < active_objectlibrary.lib_platforms.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                formlistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_platforms[i].filenameL);
                item.SubItems.Add(active_objectlibrary.lib_platforms[i].filenameCL);
                item.SubItems.Add(active_objectlibrary.lib_platforms[i].filenameCR);
                item.SubItems.Add(active_objectlibrary.lib_platforms[i].filenameR);

            }
            //Roofs
            for (int i = 0; i < active_objectlibrary.lib_roofs.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                rooflistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_roofs[i].filenameL);
                item.SubItems.Add(active_objectlibrary.lib_roofs[i].filenameCL);
                item.SubItems.Add(active_objectlibrary.lib_roofs[i].filenameCR);
                item.SubItems.Add(active_objectlibrary.lib_roofs[i].filenameR);

            }
            //Cracks
            for (int i = 0; i < active_objectlibrary.lib_cracks.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                cracklistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_cracks[i].filename_L);
                item.SubItems.Add(active_objectlibrary.lib_cracks[i].filename_R);
            }
            //Freeobjs
            for (int i = 0; i < active_objectlibrary.lib_freeobjs.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                freeobjlistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_freeobjs[i].filename);

            }
            //Beacons
            for (int i = 0; i < active_objectlibrary.lib_beacons.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                beaconlistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_beacons[i].filename);
            }
            //Poles
            for (int i = 0; i < active_objectlibrary.lib_poles.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                polelistview.Items.Insert(i, item);
                item.SubItems.Add(active_objectlibrary.lib_poles[i].filename);
                item.SubItems.Add(active_objectlibrary.lib_poles[i].additional_rail_number.ToString());
            }

            //Todo: Cycles


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
                int pid = gndlistview.Items.IndexOf(gndlistview.Items[i]);
                ObjectLibrary.Ground pground = active_objectlibrary.lib_grounds[i];
                gndlistview.Items[i].Text = pid.ToString();
                pground.id = (uint)pid;
                active_objectlibrary.lib_grounds[i] = pground;
                
                
            }
            for(int i=0;i<gndlistview2.Items.Count;i++)
            {
                gndlistview2.Items[i].Text = gndlistview2.Items.IndexOf(gndlistview2.Items[i]).ToString();

            }
            //Check ground cycle list IDs
            for(int i=0;i<GndCycleListView.Items.Count;i++)
            {
                GndCycleListView.Items[i].Text = GndCycleListView.Items.IndexOf(GndCycleListView.Items[i]).ToString();

            }

            //Check rail list IDs
            for (int i = 0; i < raillistview.Items.Count; i++)
            {
                int pid = raillistview.Items.IndexOf(raillistview.Items[i]);
                ObjectLibrary.Rail prail = active_objectlibrary.lib_rails[i];
                raillistview.Items[i].Text = pid.ToString();
                prail.id = (uint)pid;
                active_objectlibrary.lib_rails[i] = prail;

                
            }
            for (int i = 0; i < raillistview2.Items.Count; i++)
            {
                raillistview2.Items[i].Text = raillistview2.Items.IndexOf(raillistview2.Items[i]).ToString();
            }
            //Check rail cycle list IDs
            for (int i = 0; i < RailCycleListView.Items.Count; i++)
            {
                RailCycleListView.Items[i].Text = RailCycleListView.Items.IndexOf(RailCycleListView.Items[i]).ToString();
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
                active_objectlibrary.lib_cracks.RemoveAt(index);
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
            active_objectlibrary.lib_roofs.Insert(item.Index, new ObjectLibrary.Roof("Undefined", "Undefined", "Undefined", "Undefined"));
            UpdateIDs();
        }

        private void btn_formdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < formlistview.SelectedIndices.Count; i++)
            {
                int index = formlistview.SelectedIndices[i];
                active_objectlibrary.lib_platforms.RemoveAt(index);
                formlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_roofdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rooflistview.SelectedIndices.Count; i++)
            {
                int index = rooflistview.SelectedIndices[i];
                active_objectlibrary.lib_roofs.RemoveAt(index);
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
            active_objectlibrary.lib_freeobjs.Insert(item.Index, new ObjectLibrary.FreeObj("Undefined"));
            UpdateIDs();
        }

        private void btn_freeobjdelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < freeobjlistview.SelectedIndices.Count; i++)
            {
                int index = freeobjlistview.SelectedIndices[i];
                active_objectlibrary.lib_freeobjs.RemoveAt(index);
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
            active_objectlibrary.lib_poles.Insert(item.Index, new ObjectLibrary.Pole("Undefined", (int)numericUpDown1.Value));
            UpdateIDs();

        }

        private void btn_poledelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < polelistview.SelectedIndices.Count; i++)
            {
                int index = polelistview.SelectedIndices[i];
                active_objectlibrary.lib_poles.RemoveAt(index);
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
            active_objectlibrary.lib_beacons.Insert(item.Index, new ObjectLibrary.Beacon("Undefined"));
            UpdateIDs();
        }

        private void btn_beacondelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < beaconlistview.SelectedIndices.Count; i++)
            {
                int index = beaconlistview.SelectedIndices[i];
                active_objectlibrary.lib_beacons.RemoveAt(index);
                beaconlistview.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_gndadd_Click(object sender, EventArgs e)
        {

            //Items to be added
            ListViewItem item = new ListViewItem(); //For grounds menu
            ListViewItem item2 = new ListViewItem(); //For cycle grounds menu
            //Making the item's index as the item's number (for ID)
            item.Text = item.Index.ToString(); 
            item2.Text = item2.Index.ToString();



            //Updating the grounds list on Grounds tab
            gndlistview.Items.Add(item); //Adding the item
            
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));

            //Updating the grounds list on Cycles tab
            gndlistview2.Items.Add(item2);
            
            item2.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));
            //Adding blank ground entry
            active_objectlibrary.lib_grounds.Insert(item.Index, new ObjectLibrary.Ground("Undefined", (uint)item.Index));


            UpdateIDs();
            active_objectlibrary.UpdateIDs();
        }

        private void btn_gnddelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gndlistview.SelectedIndices.Count; i++)
            {
                int index = gndlistview.SelectedIndices[i];
                active_objectlibrary.lib_grounds.RemoveAt(index);
                gndlistview.Items.RemoveAt(index);
                gndlistview2.Items.RemoveAt(index);
            }

            UpdateIDs();
            active_objectlibrary.UpdateIDs();
        }

        private void btn_formchooseleft_Click(object sender, EventArgs e)
        {
            FormL_OpenFileDialog.ShowDialog();
            int index = formlistview.Items.IndexOf(formlistview.SelectedItems[0]);
            ObjectLibrary.Platform pform = active_objectlibrary.lib_platforms[index];
            pform.filenameL = FormL_OpenFileDialog.FileName;
            active_objectlibrary.lib_platforms[index] = pform;

            ListViewItem item = formlistview.Items[index];
            item.SubItems[1].Text = active_objectlibrary.lib_platforms[index].filenameL;
            UpdateIDs();

        }

        /*
        //
        //Temporary code: Export the object library as CSV code
        private void button3_Click(object sender, EventArgs e)
        {
            //String list for exporting
            List<string> exportinterface = new List<string>();
            exportinterface = active_objectlibrary.CSVParsed();

            StreamWriter exportstream = new StreamWriter(Application.StartupPath + "\\dna.txt");
            for (int i = 0; i < exportinterface.Count; i++)
            {
                exportstream.WriteLine(exportinterface[i]);
            }
            exportstream.Close();



        }
        */

        private void btn_RailAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            ListViewItem item2 = new ListViewItem();
            raillistview.Items.Add(item);
            item.Text = item.Index.ToString();
            item.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));

            raillistview2.Items.Add(item2);
            item2.Text = item.Index.ToString();
            item2.SubItems.Add("Undefined", Color.Red, Color.White, new Font(rooflistview.Font, FontStyle.Bold));





            active_objectlibrary.lib_rails.Insert(item.Index, new ObjectLibrary.Rail("Undefined",(uint)item.Index));
            UpdateIDs();
            active_objectlibrary.UpdateIDs();



        }

        private void btn_RailDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < raillistview.SelectedIndices.Count; i++)
            {
                int index = raillistview.SelectedIndices[i];
                active_objectlibrary.lib_rails.RemoveAt(index);
                raillistview.Items.RemoveAt(index);
                raillistview2.Items.RemoveAt(index);
            }
            UpdateIDs();

        }



        private void btn_GndCycleAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            GndCycleListView.Items.Add(item);
            item.Text = item.Index.ToString();

            active_objectlibrary.lib_cyclegrounds.Insert(item.Index, new ObjectLibrary.CycleGround(new List<metadata01.ObjectLibrary.Ground>()));
            item.SubItems.Add(active_objectlibrary.lib_cyclegrounds[item.Index].CycledGrounds);

        }

        private void btn_RailCycleAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            RailCycleListView.Items.Add(item);
            item.Text = item.Index.ToString();

            active_objectlibrary.lib_cyclerails.Insert(item.Index, new ObjectLibrary.CycleRail(new List<metadata01.ObjectLibrary.Rail>()));
            item.SubItems.Add(active_objectlibrary.lib_cyclerails[item.Index].CycledRails);

        }

        private void btn_GndCycleAddGround_Left_Click(object sender, EventArgs e)
        {

            //objectlibrary.lib_cyclegrounds[GndCycleListView.SelectedItems.IndexOf(GndCycleListView.SelectedItems[i])].grounds.Add(objectlibrary.lib_grounds[gndlistview2.SelectedItems.IndexOf(gndlistview2.SelectedItems[i])]);


            //GndCycleListView.Items[i].SubItems[1].Text = objectlibrary.lib_cyclegrounds[i].CycledGrounds;

            int i = Convert.ToInt32(GndCycleListView.SelectedItems[0].Text);
            int j = Convert.ToInt32(gndlistview2.SelectedItems[0].Text);
            active_objectlibrary.lib_cyclegrounds[i].grounds.Add(active_objectlibrary.lib_grounds[j]);
            GndCycleListView.Items[i].SubItems[1].Text = active_objectlibrary.lib_cyclegrounds[i].CycledGrounds;




        }

        private void btn_GndCycleDeleteGround_Right_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(GndCycleListView.SelectedItems[0].Text);
            active_objectlibrary.lib_cyclegrounds[i].grounds.RemoveAt(active_objectlibrary.lib_cyclegrounds[i].grounds.Count - 1);
            GndCycleListView.Items[i].SubItems[1].Text = active_objectlibrary.lib_cyclegrounds[i].CycledGrounds;


        }

        private void btn_GndCycleDelete_Click(object sender, EventArgs e)
        {
            for(int i=0;i<GndCycleListView.SelectedIndices.Count;i++)
            {
                int index = GndCycleListView.SelectedIndices[i];
                active_objectlibrary.lib_cyclegrounds.RemoveAt(index);
                GndCycleListView.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_RailCycleDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RailCycleListView.SelectedIndices.Count; i++)
            {
                int index = RailCycleListView.SelectedIndices[i];
                active_objectlibrary.lib_cyclerails.RemoveAt(index);
                RailCycleListView.Items.RemoveAt(index);
            }
            UpdateIDs();
        }

        private void btn_RailCycleAddRail_Left_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(RailCycleListView.SelectedItems[0].Text);
            int j = Convert.ToInt32(raillistview2.SelectedItems[0].Text);
            active_objectlibrary.lib_cyclerails[i].rails.Add(active_objectlibrary.lib_rails[j]);
            RailCycleListView.Items[i].SubItems[1].Text = active_objectlibrary.lib_cyclerails[i].CycledRails;
        }

        private void btn_RailCycleDeleteRail_Right_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(RailCycleListView.SelectedItems[0].Text);
            active_objectlibrary.lib_cyclerails[i].rails.RemoveAt(active_objectlibrary.lib_cyclerails[i].rails.Count - 1);
            RailCycleListView.Items[i].SubItems[1].Text = active_objectlibrary.lib_cyclerails[i].CycledRails;
        }

        private void btn_wallchooseleft_Click(object sender, EventArgs e)
        {
            WallL_OpenFileDialog.ShowDialog();
            int index = walllistview.Items.IndexOf(walllistview.SelectedItems[0]);
            ObjectLibrary.Wall pwall = active_objectlibrary.lib_walls[index];
            pwall.filename_L = WallL_OpenFileDialog.FileName;
            active_objectlibrary.lib_walls[index] = pwall;

            ListViewItem item = walllistview.Items[index];
            item.SubItems[1].Text = pwall.filename_L;
            UpdateIDs();

        }

        private void btn_wallchooseright_Click(object sender, EventArgs e)
        {
            WallR_OpenFileDialog.ShowDialog();
            int index = walllistview.Items.IndexOf(walllistview.SelectedItems[0]);
            ObjectLibrary.Wall pwall = active_objectlibrary.lib_walls[index];
            pwall.filename_R = WallR_OpenFileDialog.FileName;
            active_objectlibrary.lib_walls[index] = pwall;

            ListViewItem item = walllistview.Items[index];
            item.SubItems[2].Text = pwall.filename_R;
            UpdateIDs();
        }

        private void btn_dikechooseleft_Click(object sender, EventArgs e)
        {
            DikeL_OpenFileDialog.ShowDialog();
            int index = dikelistview.Items.IndexOf(dikelistview.SelectedItems[0]);
            ObjectLibrary.Dike pdike = active_objectlibrary.lib_dikes[index];
            pdike.filename_L = DikeL_OpenFileDialog.FileName;
            active_objectlibrary.lib_dikes[index] = pdike;

            ListViewItem item = dikelistview.Items[index];
            item.SubItems[1].Text = pdike.filename_L;
            UpdateIDs();
        }

        private void btn_dikechooseright_Click(object sender, EventArgs e)
        {
            DikeR_OpenFileDialog.ShowDialog();
            int index = dikelistview.Items.IndexOf(dikelistview.SelectedItems[0]);
            ObjectLibrary.Dike pdike = active_objectlibrary.lib_dikes[index];
            pdike.filename_R = DikeR_OpenFileDialog.FileName;
            active_objectlibrary.lib_dikes[index] = pdike;

            ListViewItem item = dikelistview.Items[index];
            item.SubItems[2].Text = pdike.filename_L;
            UpdateIDs();
        }

        private void btn_crackchooseleft_Click(object sender, EventArgs e)
        {
            CrackL_OpenFileDialog.ShowDialog();
            int index = cracklistview.Items.IndexOf(cracklistview.SelectedItems[0]);
            ObjectLibrary.Crack pcrack = active_objectlibrary.lib_cracks[index];
            pcrack.filename_L = CrackL_OpenFileDialog.FileName;
            active_objectlibrary.lib_cracks[index] = pcrack;
        }

        private void btn_crackchooseright_Click(object sender, EventArgs e)
        {
            CrackR_OpenFileDialog.ShowDialog();
            int index = cracklistview.Items.IndexOf(cracklistview.SelectedItems[0]);
            ObjectLibrary.Crack pcrack = active_objectlibrary.lib_cracks[index];
            pcrack.filename_R = CrackR_OpenFileDialog.FileName;
            active_objectlibrary.lib_cracks[index] = pcrack;
        }

        private void btn_formchoosecleft_Click(object sender, EventArgs e)
        {
            FormCL_OpenFileDialog.ShowDialog();
            int index = formlistview.Items.IndexOf(formlistview.SelectedItems[0]);
            ObjectLibrary.Platform pform = active_objectlibrary.lib_platforms[index];
            pform.filenameCL = FormCL_OpenFileDialog.FileName;
            active_objectlibrary.lib_platforms[index] = pform;

            ListViewItem item = formlistview.Items[index];
            item.SubItems[2].Text = active_objectlibrary.lib_platforms[index].filenameCL;
            UpdateIDs();
        }

        private void btn_formchoosecright_Click(object sender, EventArgs e)
        {
            FormCR_OpenFileDialog.ShowDialog();
            int index = formlistview.Items.IndexOf(formlistview.SelectedItems[0]);
            ObjectLibrary.Platform pform = active_objectlibrary.lib_platforms[index];
            pform.filenameCR = FormCR_OpenFileDialog.FileName;
            active_objectlibrary.lib_platforms[index] = pform;

            ListViewItem item = formlistview.Items[index];
            item.SubItems[3].Text = active_objectlibrary.lib_platforms[index].filenameCR;
            UpdateIDs();
        }

        private void btn_formchooseright_Click(object sender, EventArgs e)
        {
            FormR_OpenFileDialog.ShowDialog();
            int index = formlistview.Items.IndexOf(formlistview.SelectedItems[0]);
            ObjectLibrary.Platform pform = active_objectlibrary.lib_platforms[index];
            pform.filenameR = FormR_OpenFileDialog.FileName;
            active_objectlibrary.lib_platforms[index] = pform;

            ListViewItem item = formlistview.Items[index];
            item.SubItems[4].Text = active_objectlibrary.lib_platforms[index].filenameR;
            UpdateIDs();
        }

        private void btn_roofchooseleft_Click(object sender, EventArgs e)
        {
            RoofL_OpenFileDialog.ShowDialog();
            int index = rooflistview.Items.IndexOf(rooflistview.SelectedItems[0]);
            ObjectLibrary.Roof proof = active_objectlibrary.lib_roofs[index];
            proof.filenameL = RoofL_OpenFileDialog.FileName;
            active_objectlibrary.lib_roofs[index] = proof;

            ListViewItem item = rooflistview.Items[index];
            item.SubItems[1].Text = active_objectlibrary.lib_roofs[index].filenameL;
            UpdateIDs();
        }

        private void btn_roofchoosecleft_Click(object sender, EventArgs e)
        {
            RoofCL_OpenFileDialog.ShowDialog();
            int index = rooflistview.Items.IndexOf(rooflistview.SelectedItems[0]);
            ObjectLibrary.Roof proof = active_objectlibrary.lib_roofs[index];
            proof.filenameCL = RoofCL_OpenFileDialog.FileName;
            active_objectlibrary.lib_roofs[index] = proof;

            ListViewItem item = rooflistview.Items[index];
            item.SubItems[2].Text = active_objectlibrary.lib_roofs[index].filenameCL;
            UpdateIDs();
        }

        private void btn_roofchoosecright_Click(object sender, EventArgs e)
        {
            RoofCR_OpenFileDialog.ShowDialog();
            int index = rooflistview.Items.IndexOf(rooflistview.SelectedItems[0]);
            ObjectLibrary.Roof proof = active_objectlibrary.lib_roofs[index];
            proof.filenameCR = RoofCR_OpenFileDialog.FileName;
            active_objectlibrary.lib_roofs[index] = proof;

            ListViewItem item = rooflistview.Items[index];
            item.SubItems[3].Text = active_objectlibrary.lib_roofs[index].filenameCR;
            UpdateIDs();
        }

        private void btn_roofchooseright_Click(object sender, EventArgs e)
        {
            RoofR_OpenFileDialog.ShowDialog();
            int index = rooflistview.Items.IndexOf(rooflistview.SelectedItems[0]);
            ObjectLibrary.Roof proof = active_objectlibrary.lib_roofs[index];
            proof.filenameR = RoofR_OpenFileDialog.FileName;
            active_objectlibrary.lib_roofs[index] = proof;

            ListViewItem item = rooflistview.Items[index];
            item.SubItems[4].Text = active_objectlibrary.lib_roofs[index].filenameR;
            UpdateIDs();
        }

        private void bckdelbutton_Click(object sender, EventArgs e)
        {
            int index = BckListBox.SelectedIndex;
            BckListBox.Items.RemoveAt(index);
            active_objectlibrary.lib_backgrounds.RemoveAt(index);
        }

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjLibrary_SaveFileDialog.ShowDialog();
            active_objectlibrary.SaveToFile(ObjLibrary_SaveFileDialog.FileName);
        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjLibrary_OpenFileDialog.ShowDialog();
            active_objectlibrary.LoadFromFile(ObjLibrary_OpenFileDialog.FileName);
            //Update menu items
            UpdateMenus();

        }

        private void btn_ApplyLibrary_Click(object sender, EventArgs e)
        {
            //Apply object library and close

            MainForm.active_project.library = active_objectlibrary;
            this.Close();
        }

        private void btn_CancelLibrary_Click(object sender, EventArgs e)
        {
            //Discard and close
            this.Close();
        }

        private void ObjLibrary_OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_gndchoose_Click(object sender, EventArgs e)
        {
            //Prompting the user to choose the ground file name
            GroundOpenFileDialog.ShowDialog();
            string gnd_fname = GroundOpenFileDialog.FileName;

            //ListViewItem item = gndlistview.SelectedItems[0];

            //Due to multiselect enabled, replace multiple grounds selected.
            for (int i = 0; i < gndlistview.SelectedItems.Count; i++)
            {
                ListViewItem item = gndlistview.SelectedItems[i];

                item.SubItems[1].Text = gnd_fname;
                int i1 = gndlistview.SelectedIndices[i];


                ObjectLibrary.Ground pgnd = active_objectlibrary.lib_grounds[i1];
                pgnd.filename = gnd_fname;
                active_objectlibrary.lib_grounds[i1] = pgnd;

                //Do the same on the cycles panel
                ListViewItem item2 = gndlistview2.Items[i1];
                item2.SubItems[1].Text = gnd_fname;


            }


            //Update
            UpdateIDs();
            active_objectlibrary.UpdateIDs();

        }
    }
}
