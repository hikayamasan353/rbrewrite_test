using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using IniParser;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Parser;

namespace metadata01
{
    /// <summary>
    /// RouteBuilder in-software object library.
    /// </summary>
    public class ObjectLibrary
    {
        /*
         * When we code a BVE route, for proper depiction in BVE we must
         * write the Structure namespace. Here is how the actual CSV
         * route code looks like:
         * --------------------------------------------------------------
         * With Structure
         * .Ground(0) routename\ground0.b3d
         * .Rail(0) routename\rail0.b3d
         * .WallL(0) routename\wall_L.b3d
         * .WallR(0) routename\wall_R.b3d
         * .DikeL(0) routename\dike_L.b3d
         * .DikeR(0) routename\dike_R.b3d
         * .CrackL(0) routename\crack_L.b3d
         * .CrackR(0) routename\crack_R.b3d
         * .FormCL(0) routename\form_CL.b3d
         * .FormCR(0) routename\form_CR.b3d
         * .FormL(0) routename\form_L.b3d
         * .FormR(0) routename\form_R.b3d
         * .RoofCL(0) routename\roof_CL.b3d
         * .RoofCR(0) routename\roof_CR.b3d
         * .RoofL(0) routename\roof_L.b3d
         * .RoofR(0) routename\roof_R.b3d
         * .FreeObj(0) routename\freeobj.b3d
         * .Beacon(0) routename\beacon.b3d
         * With Texture
         * .Background(0) routename\background.bmp
         * ---------------------------------------------------------------
         * Usually while manually coding, writing all these fields and referencing
         * them is very straining and confusing. Unfortunately, Uwe Post's original RouteBuilder
         * uses only FreeObj command for generating scenery objects.
         * For reducing these needs, we build an object library class.
         * It must be used for every route project.
         */

        
        
        
        //====================================================================
        /// <summary>
        /// List of ground cycles used in the route project
        /// Code:
        /// With Cycle
        /// .Ground(0) 0;1;2,
        /// </summary>
        public List<Cycle> lib_cycles;
        //======================================================================

        public List<Beacon> lib_beacons;

        public List<Ground> lib_grounds;


        public List<Background> lib_backgrounds;

        /// <summary>
        /// List of walls used in the route project
        /// </summary>
        public List<Wall> lib_walls;

        public List<Dike> lib_dikes;

        public List<Platform> lib_platforms;

        public List<Roof> lib_roofs;

        public List<Crack> lib_cracks;

        public List<FreeObj> lib_freeobjs;

        public List<Pole> lib_poles;



        
        /// <summary>
        /// Background texture.
        /// </summary>
        public struct Background
        {
            public string filename;
            
            public Background(string filename)
            {
                this.filename = filename;
            }

            public string CSVParsed(int index)
            {
                return ".Background(" + index.ToString() + ") " + this.filename + ", \n";
            }

        }


        /// <summary>
        /// Ground object cycle. While cycle is called, BVE renders the objects sequentially.
        /// --------------------------------------------------------------------------
        /// Code:
        /// With Cycle
        /// .Ground (0) 0;1;2,
        /// --------------------------------------------------------------------------
        /// </summary>
        public struct Cycle
        {

            /// <summary>
            /// Grounds that are in cycle
            /// </summary>
            public List<Ground> grounds;

            /// <summary>
            /// Creates a cycle out of the specific ground list
            /// </summary>
            /// <param name="g">A ground list</param>
            public Cycle(List<Ground> g)
            {
                this.grounds = g;
                for (int i = 0; i < this.grounds.Count; i++)
                {
                    //If a ground is not considered in cycle?
                    if (this.grounds[i].in_cycle == false)
                    {
                        //Replace the in_cycle with true
                        Ground gr1 = this.grounds[i];
                        gr1.in_cycle = true;
                        this.grounds[i] = gr1;
                    }

                }
            }



            /// <summary>
            /// CSV parsed declaration of a cycle
            /// </summary>
            /// <param name="index">Index in .Ground(index)</param>
            /// <returns>CSV parsed string value, i.e. .Ground(0) 0;1;2;3,</returns>
            public string CSVParsed(int index)
            {
                //CSV parsed values of grounds in cycle
                //i.e.: .Ground(0) 0;1;2;3,
                string s1 = "";
                for (int i1 = 0; i1 < this.grounds.Count; i1++)
                {
                    s1 += i1.ToString() + ";";
                }
                return ".Ground(" + index.ToString() + ") " + s1 + ", \n";
            }


        }


        /// <summary>
        /// A ground object. Supports .B3D, .CSV, .X and .animated.
        /// ---------------------------------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .Ground(0) example.b3d
        /// ---------------------------------------------------------------------------
        /// </summary>
        public struct Ground
        {
            /// <summary>
            /// Ground object filename.
            /// </summary>
            public string filename;


            /// <summary>
            /// Is it in cycle?
            /// </summary>
            public bool in_cycle;


            /// <summary>
            /// Creates a new ground object
            /// </summary>
            /// <param name="fname">Ground object filename</param>
            public Ground(string fname)
            {
                this.filename = fname;
                this.in_cycle = false;
                
            }

            public string CSVParsed(int index)
            {
                return ".Ground(" + index + ") " + filename + ", \n";
            }

        }




        /// <summary>
        /// A rail object. Supports .b3d, .csv, .x and .animated.
        /// -----------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .Rail(0) example.b3d
        /// -----------------------------------------------------
        /// </summary>
        public struct Rail
        {

            /// <summary>
            /// Object file name
            /// </summary>
            public string filename;


        }


        /// <summary>
        /// A wall object. Supports .b3d, .csv, .x and .animated.
        /// -----------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .WallL(0) example_L.b3d
        /// .WallR(0) example_R.b3d
        /// </summary>
        public struct Wall
        {



            /// <summary>
            /// Left wall object file name
            /// </summary>
            public string filename_L;
            /// <summary>
            /// Right wall object file name
            /// </summary>
            public string filename_R;




            /// <summary>
            /// Creates a new wall object with specified left and right file names
            /// </summary>
            /// <param name="fnameL">Left wall file name</param>
            /// <param name="fnameR">Right wall file name</param>

            public Wall(string fnameL, string fnameR)
            {
                this.filename_L = fnameL;
                this.filename_R = fnameR;

            }



            /// <summary>
            /// Parsed CSV code for an exported route
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns></returns>
            public string CSVParsed(int index)
            {

                return
                    ".WallL(" + index.ToString() + ") " + this.filename_L + ", \n"
                    + ".WallR(" + index.ToString() + ") " + this.filename_R + ", ";
            }




        }


        /// <summary>
        /// A dike object. Supports .b3d, .csv, .x and .animated objects.
        /// In Uwe Post's Route Builder used to be known as "TSO".
        /// -------------------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .DikeL(0) example_L.b3d
        /// .DikeR(0) example_R.b3d
        /// </summary>
        public struct Dike
        {

            /// <summary>
            /// Left object file name
            /// </summary>
            public string filename_L;
            /// <summary>
            /// Right object file name
            /// </summary>
            public string filename_R;



            /// <summary>
            /// Creates a new dike object with specified left and right file names
            /// </summary>
            /// <param name="fname_L">Left dike file name</param>
            /// <param name="fname_R">Right dike file name</param>
            public Dike(string fname_L, string fname_R)
            {

                this.filename_L = fname_L;
                this.filename_R = fname_R;
            }



            /// <summary>
            /// Parsed CSV code for an exported route
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns></returns>
            public string CSVParsed(int index)
            {
                return
                 ".DikeL(" + index.ToString() + ") " + this.filename_L + ", \n"
                 + ".DikeR(" + index.ToString() + ") " + this.filename_R + ", ";
            }




        }




        /// <summary>
        /// Platform object.
        /// Edges (L and R) support .b3d, .csv, .x and .animated.
        /// Center (CL and CR) are stretchy and support same, except .animated.
        /// -------------------------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .FormCL(0) exampleCL.b3d
        /// .FormCR(0) exampleCR.b3d
        /// .FormL(0) exampleL.b3d
        /// .FormR(0) exampleR.b3d
        /// </summary>
        public struct Platform
        {

            /// <summary>
            /// Center left object filename
            /// </summary>
            public string filenameCL;
            /// <summary>
            /// Center right object filename
            /// </summary>
            public string filenameCR;
            /// <summary>
            /// Edge left object filename
            /// </summary>
            public string filenameL;
            /// <summary>
            /// Edge right object filename
            /// </summary>
            public string filenameR;


            /// <summary>
            /// Creates a new platform object with specified object file names
            /// </summary>
            /// <param name="nameCL">Center left object file name</param>
            /// <param name="nameCR">Center right object file name</param>
            /// <param name="nameL">Edge left object file name</param>
            /// <param name="nameR">Edge right object file name</param>
            public Platform(string nameCL, string nameCR, string nameL, string nameR)
            {
                this.filenameCL = nameCL;
                this.filenameCR = nameCR;
                this.filenameL = nameL;
                this.filenameR = nameR;
            }


            /// <summary>
            /// CSV parsed code for a platform object
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns>Parsed CSV code</returns>
            public string CSVParsed(int index)
            {
                return
                    ".FormCL(" + index.ToString() + ") " + this.filenameCL + ", \n" +
                    ".FormCR(" + index.ToString() + ") " + this.filenameCR + ", \n" +
                    ".FormL(" + index.ToString() + ") " + this.filenameL + ", \n" +
                    ".FormR(" + index.ToString() + ") " + this.filenameR + ",";
            }




        }


        /// <summary>
        /// Roof object.
        /// Edges (L and R) support .b3d, .csv, .x and .animated.
        /// Center (CL and CR) are stretchy and support same, except .animated.
        /// -------------------------------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .RoofCL(0) exampleCL.b3d
        /// .RoofCR(0) exampleCR.b3d
        /// .RoofL(0) exampleL.b3d
        /// .RoofR(0) exampleR.b3d
        /// </summary>
        public struct Roof
        {

            /// <summary>
            /// Center left object filename
            /// </summary>
            public string filenameCL;
            /// <summary>
            /// Center right object filename
            /// </summary>
            public string filenameCR;
            /// <summary>
            /// Edge left object filename
            /// </summary>
            public string filenameL;
            /// <summary>
            /// Edge right object filename
            /// </summary>
            public string filenameR;


            /// <summary>
            /// Creates a new platform object with specified object file names
            /// </summary>
            /// <param name="nameCL">Center left object file name</param>
            /// <param name="nameCR">Center right object file name</param>
            /// <param name="nameL">Edge left object file name</param>
            /// <param name="nameR">Edge right object file name</param>
            public Roof(string nameCL, string nameCR, string nameL, string nameR)
            {
                this.filenameCL = nameCL;
                this.filenameCR = nameCR;
                this.filenameL = nameL;
                this.filenameR = nameR;
            }


            /// <summary>
            /// CSV parsed code for a platform object
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns>Parsed CSV code</returns>
            public string CSVParsed(int index)
            {
                return
                    ".RoofCL(" + index.ToString() + ") " + this.filenameCL + ", \n" +
                    ".RoofCR(" + index.ToString() + ") " + this.filenameCR + ", \n" +
                    ".RoofL(" + index.ToString() + ") " + this.filenameL + ", \n" +
                    ".RoofR(" + index.ToString() + ") " + this.filenameR + ",";
            }




        }


        /// <summary>
        /// Crack object. Is stretchy.
        /// Supports .csv, .b3d and .x files.
        /// ---------------------------------
        /// CSV Code:
        /// With Structure
        /// .CrackL(0) exampleL.b3d
        /// .CrackR(0) exampleR.b3d
        /// </summary>
        public struct Crack
        {
            /// <summary>
            /// Left object file name
            /// </summary>
            public string filename_L;
            /// <summary>
            /// Right object file name
            /// </summary>
            public string filename_R;

            /// <summary>
            /// Creates a new crack object with specified left and right object file names
            /// </summary>
            /// <param name="name_L">Left object file name</param>
            /// <param name="name_R">Right object file name</param>
            public Crack(string name_L, string name_R)
            {
                this.filename_L = name_L;
                this.filename_R = name_R;
            }


            /// <summary>
            /// CSV parsed code for a crack object
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns>Parsed CSV code</returns>
            public string CSVParsed(int index)
            {
                return
                    ".CrackL(" + index.ToString() + ") " + this.filename_L + ", \n" +
                    ".CrackR(" + index.ToString() + ") " + this.filename_R + ",";
            }



        }


        
        /// <summary>
        /// Free object.
        /// Supports .csv, .b3d, .x and .animated files.
        /// --------------------------------------------
        /// CSV Code:
        /// With Structure
        /// .FreeObj(0) example.b3d
        /// </summary>
        public struct FreeObj
        {

            /// <summary>
            /// Object filename
            /// </summary>
            public string filename;

            /// <summary>
            /// Creates a new free object with specified file name
            /// </summary>
            /// <param name="name">Object file name</param>
            public FreeObj(string name)
            {
                this.filename = name;
            }

            /// <summary>
            /// Parsed CSV code for a free object
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns>Parsed CSV code</returns>
            public string CSVParsed(int index)
            {
                return
                    ".FreeObj(" + index.ToString() + ") " + this.filename + ", ";
            }

        }


        /// <summary>
        /// Catenary pole.
        /// </summary>
        public struct Pole
        {
            /// <summary>
            /// Pole object file name
            /// </summary>
            public string filename;
            /// <summary>
            /// Number of rails covered by the pole. 0 means just for the rail it is applied to.
            /// </summary>
            public int additional_rail_number;

            /// <summary>
            /// Creates a new catenary pole with specified name and number of rails covered by pole.
            /// </summary>
            /// <param name="fname">Object file name</param>
            /// <param name="addrailnumber">Number of rails covered by the pole.</param>
            public Pole(string fname, int addrailnumber)
            {
                this.filename = fname;
                this.additional_rail_number = addrailnumber;
            }


            /// <summary>
            /// CSV parsed code of a pole object
            /// </summary>
            /// <param name="index">Object index</param>
            /// <returns>Parsed CSV code</returns>
            public string CSVParsed(int index)
            {
                return
                    ".Pole(" + this.additional_rail_number + "; " + index + ") " + this.filename + ", \n";
            }




        }



          /// <summary>
          /// Beacon object (for safety systems) 
          /// </summary>
        public struct Beacon
        {
            public string filename;

            public Beacon(string fname)
            {
                this.filename = fname;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public string CSVParsed(int index)
            {
                return
                    ".Beacon(" + index.ToString() + ") " + this.filename + ", ";
            }

        }



        public FileIniDataParser libdataparser;
        public IniData libdata;

        

        /// <summary>
        /// Creates a blank new object library
        /// </summary>
        public ObjectLibrary()
        {
            //Create all lists blank
            this.lib_backgrounds = new List<metadata01.ObjectLibrary.Background>();
            this.lib_grounds = new List<Ground>();
            this.lib_walls = new List<metadata01.ObjectLibrary.Wall>();
            this.lib_dikes = new List<metadata01.ObjectLibrary.Dike>();
            this.lib_platforms = new List<metadata01.ObjectLibrary.Platform>();
            this.lib_roofs = new List<metadata01.ObjectLibrary.Roof>();
            this.lib_cracks = new List<metadata01.ObjectLibrary.Crack>();
            this.lib_freeobjs = new List<metadata01.ObjectLibrary.FreeObj>();
            this.lib_poles = new List<Pole>();
            this.lib_beacons = new List<Beacon>();

        }



        /// <summary>
        /// Loads a library from file
        /// </summary>
        /// <param name="filename"></param>
        public void LoadFromFile(string filename)
        {
            



            //Load grounds



            //Load walls and dikes


        }

        /// <summary>
        /// Saves a library to file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveToFile(string filename)
        {
            

            //Save grounds

            //Save walls and dikes


        }



        /// <summary>
        /// Object library parsed to CSV in With Structure namespace
        /// --------------------------------------------------------
        /// Code snippet:
        /// With Structure
        /// (parsed data)
        /// </summary>
        /// <returns></returns>
        public List<string> CSVParsed()
        {
            List<string> parsed_interface = new List<string>();
            //Adding header
            parsed_interface.Add("With Structure\n");
            //Parsing walls
            for (int i = 0; i < lib_walls.Count; i++)
            {
                parsed_interface.Add(lib_walls[i].CSVParsed(i));
            }
            //Parsing dikes
            for(int i=0;i<lib_dikes.Count;i++)
            {
                parsed_interface.Add(lib_dikes[i].CSVParsed(i));
            }
            //Parsing platforms
            for(int i=0;i<lib_platforms.Count;i++)
            {
                parsed_interface.Add(lib_platforms[i].CSVParsed(i));
            }
            //Parsing roofs
            for(int i=0;i<lib_roofs.Count;i++)
            {
                parsed_interface.Add(lib_roofs[i].CSVParsed(i));
            }
            //Parsing cracks
            for(int i=0;i<lib_cracks.Count;i++)
            {
                parsed_interface.Add(lib_cracks[i].CSVParsed(i));
            }
            //Parsing freeobjs
            for (int i = 0; i < lib_freeobjs.Count; i++)
            {
                parsed_interface.Add(lib_freeobjs[i].CSVParsed(i));
            }

            parsed_interface.Add("With Texture\n");
            for(int i=0;i<lib_backgrounds.Count;i++)
            {
                parsed_interface.Add(lib_backgrounds[i].CSVParsed(i));
            }




            return parsed_interface;
        }



    }
}
