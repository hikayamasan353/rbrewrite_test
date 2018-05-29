using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Object libraries will be saved in XML format
using System.Xml;
using System.Xml.Linq;

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
         * With Cycle
         * .Ground(0) 0;1;2;
         * .Rail(0) 0;1;2;
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
        //public List<Cycle> lib_cycles;
        //======================================================================

        public List<Beacon> lib_beacons;

        /// <summary>
        /// List of grounds
        /// </summary>
        public List<Ground> lib_grounds;
        public List<CycleGround> lib_cyclegrounds;


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

        public List<Rail> lib_rails;
        public List<CycleRail> lib_cyclerails;



        
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

            /// <summary>
            /// CSV parsed code for route export
            /// </summary>
            /// <param name="index">Background ID</param>
            /// <returns></returns>
            public string CSVParsed(int index)
            {
                return ".Background(" + index.ToString() + ") " + this.filename + ", \n";
            }

            /// <summary>
            /// XML parsed code for object library files
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public XElement XMLParsed(int index)
            {
                return new XElement("background", new XAttribute("id", index)
                    );
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
        public struct CycleGround
        {

            /// <summary>
            /// Grounds that are in cycle
            /// </summary>
            public List<Ground> grounds;



            /// <summary>
            /// Creates a cycle out of the specific ground and rail list
            /// </summary>
            /// <param name="g">A ground list</param>
            public CycleGround(List<Ground> g)
            {
                this.grounds = g;
                
            }

            /// <summary>
            /// CSV parsed values of grounds in cycle
            /// i.e. 0;1;2;3
            /// </summary>
            public string CycledGrounds
            {
                get
                {
                    string s1 = "";
                    for (int i1 = 0; i1 < this.grounds.Count; i1++)
                    {


                        s1 += grounds[i1].id.ToString() + ";";
                    }
                    return s1;
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
                return ".Ground(" + index.ToString() + ") " + CycledGrounds + ", \n";
            }


        }

        public struct CycleRail
        {
            /// <summary>
            /// Rails that are in cycle
            /// </summary>
            public List<Rail> rails;

            public CycleRail(List<Rail>r)
            {
                rails = r;
            }

            /// <summary>
            /// CSV parsed values of rails in cycle
            /// i.e. 0;1;2;3
            /// </summary>
            public string CycledRails
            {
                get
                {
                    string s1 = "";
                    for (int i1 = 0; i1 < this.rails.Count; i1++)
                    {
                        s1 += rails[i1].id.ToString() + ";";
                    }
                    return s1;
                }
            }

            /// <summary>
            /// CSV parsed declaration of a cycle
            /// </summary>
            /// <param name="index">Index in .Ground(index)</param>
            /// <returns>CSV parsed string value, i.e. .Ground(0) 0;1;2;3,</returns>
            public string CSVParsed(int index)
            {
                //CSV parsed values of rails in cycle
                //i.e.: .Rail(0) 0;1;2;3,
                return ".Rail(" + index.ToString() + ") " + CycledRails + ", \n";
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
            /// ID of ground in cycle
            /// </summary>
            public uint id;

            /// <summary>
            /// Creates a new ground object
            /// </summary>
            /// <param name="fname">Ground object filename</param>
            public Ground(string fname)
            {
                this.filename = fname;
                this.id = 0;
            }

            public Ground(string fname,uint id)
            {
                filename = fname;
                this.id = id;
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

            /// <summary>
            /// Rail ID to be used in cycle
            /// </summary>
            public uint id;

            public Rail(string fname)
            {
                this.filename = fname;
                id = 0;
            }
            public Rail(string fname, uint id)
            {
                filename = fname;
                this.id = id;
            }


            public string CSVParsed(int index)
            {
                return ".Rail(" + index.ToString() + ") " + this.filename + ", ";
            }


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
        /// <summary>
        /// Creates a blank new object library
        /// </summary>
        public ObjectLibrary()
        {
            //Create all lists blank
            this.lib_backgrounds = new List<metadata01.ObjectLibrary.Background>();
            this.lib_grounds = new List<Ground>();
            this.lib_rails = new List<Rail>();
            this.lib_walls = new List<metadata01.ObjectLibrary.Wall>();
            this.lib_dikes = new List<metadata01.ObjectLibrary.Dike>();
            this.lib_platforms = new List<metadata01.ObjectLibrary.Platform>();
            this.lib_roofs = new List<metadata01.ObjectLibrary.Roof>();
            this.lib_cracks = new List<metadata01.ObjectLibrary.Crack>();
            this.lib_freeobjs = new List<metadata01.ObjectLibrary.FreeObj>();
            this.lib_poles = new List<Pole>();
            this.lib_beacons = new List<Beacon>();
            this.lib_cyclegrounds = new List<metadata01.ObjectLibrary.CycleGround>();
            this.lib_cyclerails = new List<metadata01.ObjectLibrary.CycleRail>();

        }



        /// <summary>
        /// Loads a library from file
        /// </summary>
        /// <param name="filename"></param>
        public void LoadFromFile(string filename)
        {
            //Clear lists to replace the library
            lib_backgrounds.Clear();
            lib_grounds.Clear();
            lib_rails.Clear();
            lib_walls.Clear();
            lib_dikes.Clear();
            lib_platforms.Clear();
            lib_roofs.Clear();
            lib_cracks.Clear();
            lib_poles.Clear();
            lib_freeobjs.Clear();
            lib_beacons.Clear();
            //Prepare to load documents
            XmlDocument library = new XmlDocument();
            library.Load(filename);
            //Commencing reader
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            

            XmlReader reader = XmlReader.Create(filename, settings);
            //Reading master node
            XmlElement master = library["ObjectLibrary"];
            reader.ReadStartElement(master.Name);
            /////////////////////////////////////////////////////////////
            //Backgrounds
            XmlElement backgrounds = master["Backgrounds"];
            reader.ReadStartElement(backgrounds.Name);
            for (int i = 0; i < backgrounds.ChildNodes.Count; i++)
            {


                reader.ReadStartElement(backgrounds.ChildNodes[i].Name);
                string pfilename = reader.ReadElementContentAsString();
                Background background = new Background(pfilename); ;
                lib_backgrounds.Add(background);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            /////////////////////////////////////////////////////////////////
            //Grounds
            XmlElement grounds = master["Grounds"];
            reader.ReadStartElement(grounds.Name);
            for (int i = 0; i < grounds.ChildNodes.Count; i++)
            {
                reader.ReadStartElement(grounds.ChildNodes[i].Name);
                string pfilename = reader.ReadElementContentAsString();
                Ground ground = new Ground(pfilename, Convert.ToUInt32(reader.GetAttribute("id")));
                lib_grounds.Add(ground);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            //////////////////////////////////////////////////////////////////
            //Rails
            XmlElement rails = master["Rails"];
            reader.ReadStartElement(rails.Name);
            for (int i = 0; i < rails.ChildNodes.Count; i++)
            {
                reader.ReadStartElement(rails.ChildNodes[i].Name);
                string pfilename = reader.ReadElementContentAsString();
                Rail rail = new Rail(pfilename, Convert.ToUInt32(reader.GetAttribute("id")));
                lib_rails.Add(rail);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            ////////////////////////////////////////////////////////////////////
            //Walls
            XmlElement walls = master["Walls"];
            reader.ReadStartElement(walls.Name);
            for (int i = 0; i < walls.ChildNodes.Count; i++)
            {
                reader.ReadStartElement(walls.ChildNodes[i].Name);
                Wall wall = new Wall(reader.GetAttribute("filename_L"), reader.GetAttribute("filename_R"));
                lib_walls.Add(wall);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            ///////////////////////////////////////////////////////////////////////
            //Dikes
            XmlElement dikes = master["Dikes"];
            reader.ReadStartElement(dikes.Name);
            for(int i=0;i<dikes.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(dikes.ChildNodes[i].Name);
                Dike dike = new Dike(reader.GetAttribute("filename_L"), reader.GetAttribute("filename_R"));
                lib_dikes.Add(dike);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            ////////////////////////////////////////////////////////////////////////
            //Platforms
            XmlElement platforms = master["Platforms"];
            reader.ReadStartElement(platforms.Name);
            for(int i=0;i<platforms.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(platforms.ChildNodes[i].Name);
                Platform form = new Platform(reader.GetAttribute("filename_CL"), reader.GetAttribute("filename_CR"), reader.GetAttribute("filename_L"), reader.GetAttribute("filename_R"));
                lib_platforms.Add(form);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            //////////////////////////////////////////////////////////////////////////
            //Roofs
            XmlElement roofs = master["Roofs"];
            reader.ReadStartElement(roofs.Name);
            for(int i=0;i<roofs.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(roofs.ChildNodes[i].Name);
                Roof roof = new Roof(reader.GetAttribute("filename_CL"), reader.GetAttribute("filename_CR"), reader.GetAttribute("filename_L"), reader.GetAttribute("filename_R"));
                lib_roofs.Add(roof);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            ////////////////////////////////////////////////////////////////////////////
            //Poles
            XmlElement poles = master["Poles"];
            reader.ReadStartElement(poles.Name);
            for(int i=0;i<poles.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(poles.ChildNodes[i].Name);
                Pole pole = new Pole(reader.GetAttribute("filename"), Convert.ToInt32(reader.GetAttribute("covers")));
                lib_poles.Add(pole);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            //////////////////////////////////////////////////////////////////////////////
            //Cracks
            XmlElement cracks = master["Cracks"];
            reader.ReadStartElement(cracks.Name);
            for (int i = 0; i < cracks.ChildNodes.Count; i++)
            {
                reader.ReadStartElement(cracks.ChildNodes[i].Name);
                Crack crack = new Crack(reader.GetAttribute("filename_L"), reader.GetAttribute("filename_R"));
                lib_cracks.Add(crack);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            ////////////////////////////////////////////////////////////////////////////////
            //FreeObjs
            XmlElement freeobjs = master["FreeObjects"];
            reader.ReadStartElement(freeobjs.Name);
            for(int i=0;i<freeobjs.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(freeobjs.ChildNodes[i].Name);
                FreeObj freeobj = new FreeObj(reader.GetAttribute("filename"));
                lib_freeobjs.Add(freeobj);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
            /////////////////////////////////////////////////////////////////////////////////
            //Beacons
            XmlElement beacons = master["Beacons"];
            reader.ReadStartElement(beacons.Name);
            for(int i=0;i<beacons.ChildNodes.Count;i++)
            {
                reader.ReadStartElement(beacons.ChildNodes[i].Name);
                Beacon beacon = new Beacon(reader.GetAttribute("filename"));
                lib_beacons.Add(beacon);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();


            //Close the stream
            reader.ReadEndElement();
            reader.Close();

        }

        /// <summary>
        /// Saves a library to file
        /// </summary>
        /// <param name="filename">File name</param>
        public void SaveToFile(string filename)
        {
            //Create an XML document for object libraries
            XDocument library = new XDocument();

            //Create a stream, Write it to file

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            XmlWriter writer = XmlWriter.Create(filename,settings);

            
            

            //Create an XML master element and commence the writer
            XElement master = new XElement("ObjectLibrary");
            library.Add(master);
            writer.WriteStartDocument();
            writer.WriteStartElement(master.Name.ToString());

            //Todo: Object library information.

            //Create XML nodes for every type of objects in the object library
            //////////////////////////////////////////////////////////////////
            //Backgrounds
            XElement backgrounds = new XElement("Backgrounds");
            master.Add(backgrounds);
            writer.WriteStartElement(backgrounds.Name.ToString());
            for (int i = 0; i < lib_backgrounds.Count; i++)
            {
                XElement background_node = new XElement("background", new XAttribute("id", i));
                backgrounds.Add(background_node);
                writer.WriteStartElement(background_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteString(lib_backgrounds[i].filename);

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            ////////////////////////////////////////////////////////////////////////////
            //Grounds
            XElement grounds = new XElement("Grounds");
            master.Add(grounds);
            writer.WriteStartElement(grounds.Name.ToString());
            for (int i = 0; i < lib_grounds.Count; i++)
            {
                XElement ground_node = new XElement("ground", new XAttribute("id", i));
                grounds.Add(ground_node);
                writer.WriteStartElement(ground_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                //writer.WriteStartAttribute("filename");
                //writer.WriteValue(lib_grounds[i].filename);
                //writer.WriteEndAttribute();

                writer.WriteString(lib_grounds[i].filename);

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            ////////////////////////////////////////////////////////////////////////////////////
            //Rails
            XElement rails = new XElement("Rails");
            master.Add(rails);
            writer.WriteStartElement(rails.Name.ToString());
            for (int i = 0; i < lib_rails.Count; i++)
            {
                XElement rail_node = new XElement("rail", new XAttribute("id", i));
                rails.Add(rail_node);
                writer.WriteStartElement(rail_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteString(lib_rails[i].filename);

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            /////////////////////////////////////////////////////////////////////////////////////
            //Walls
            XElement walls = new XElement("Walls");
            master.Add(walls);
            writer.WriteStartElement(walls.Name.ToString());
            for (int i = 0; i < lib_walls.Count; i++)
            {
                XElement wall_node = new XElement("wall", new XAttribute("id", i), new XAttribute("filename_L", lib_walls[i].filename_L), new XAttribute("filename_R", lib_walls[i].filename_R));
                walls.Add(wall_node);
                writer.WriteStartElement(wall_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_L");
                writer.WriteValue(lib_walls[i].filename_L);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_R");
                writer.WriteValue(lib_walls[i].filename_R);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            /////////////////////////////////////////////////////////////////////////////////////////
            //Dikes
            XElement dikes = new XElement("Dikes");
            master.Add(dikes);
            writer.WriteStartElement(dikes.Name.ToString());
            for (int i = 0; i < lib_dikes.Count; i++)
            {
                XElement dike_node = new XElement("dike", new XAttribute("id", i), new XAttribute("filename_L", lib_dikes[i].filename_L), new XAttribute("filename_R", lib_dikes[i].filename_R));
                writer.WriteStartElement(dike_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_L");
                writer.WriteValue(lib_dikes[i].filename_L);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_R");
                writer.WriteValue(lib_dikes[i].filename_R);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            //////////////////////////////////////////////////////////////////////////////////////////
            //Platforms
            XElement platforms = new XElement("Platforms");
            master.Add(platforms);
            writer.WriteStartElement(platforms.Name.ToString());
            for (int i = 0; i < lib_platforms.Count; i++)
            {
                XElement form_node = new XElement("platform", new XAttribute("id", i), new XAttribute("filename_L", lib_platforms[i].filenameL), new XAttribute("filename_CL", lib_platforms[i].filenameCL), new XAttribute("filename_CR", lib_platforms[i].filenameCR), new XAttribute("filename_R", lib_platforms[i].filenameR));
                platforms.Add(form_node);
                writer.WriteStartElement(form_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_L");
                writer.WriteValue(lib_platforms[i].filenameL);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_CL");
                writer.WriteValue(lib_platforms[i].filenameCL);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_CR");
                writer.WriteValue(lib_platforms[i].filenameCR);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_R");
                writer.WriteValue(lib_platforms[i].filenameR);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            //////////////////////////////////////////////////////////////////////
            //Roofs
            XElement roofs = new XElement("Roofs");
            master.Add(roofs);
            writer.WriteStartElement(roofs.Name.ToString());
            for (int i = 0; i < lib_roofs.Count; i++)
            {
                XElement roof_node = new XElement("roof", new XAttribute("id", i), new XAttribute("filename_L", lib_roofs[i].filenameL), new XAttribute("filename_CL", lib_roofs[i].filenameCL), new XAttribute("filename_CR", lib_roofs[i].filenameCR), new XAttribute("filename_R", lib_roofs[i].filenameR));
                roofs.Add(roof_node);
                writer.WriteStartElement(roof_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_L");
                writer.WriteValue(lib_roofs[i].filenameL);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_CL");
                writer.WriteValue(lib_roofs[i].filenameCL);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_CR");
                writer.WriteValue(lib_roofs[i].filenameCR);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_R");
                writer.WriteValue(lib_roofs[i].filenameR);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();
            //////////////////////////////////////////////////////////////////////
            //Poles
            XElement poles = new XElement("Poles");
            master.Add(poles);
            writer.WriteStartElement(poles.Name.ToString());
            for (int i = 0; i < lib_poles.Count; i++)
            {
                XElement poles_node = new XElement("pole", new XAttribute("id", i), new XAttribute("filename", lib_poles[i].filename), new XAttribute("covers", lib_poles[i].additional_rail_number));
                poles.Add(poles_node);
                writer.WriteStartElement(poles_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename");
                writer.WriteValue(lib_poles[i].filename);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("covers");
                writer.WriteValue(lib_poles[i].additional_rail_number);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();

            //Cracks
            XElement cracks = new XElement("Cracks");
            master.Add(cracks);
            writer.WriteStartElement(cracks.Name.ToString());
            for (int i = 0; i < lib_cracks.Count; i++)
            {
                XElement cracks_node = new XElement("crack", new XAttribute("id", i), new XAttribute("filename_L", lib_cracks[i].filename_L), new XAttribute("filename_R", lib_cracks[i].filename_R));
                cracks.Add(cracks_node);

                writer.WriteStartElement(cracks_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_L");
                writer.WriteValue(lib_cracks[i].filename_L);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename_R");
                writer.WriteValue(lib_cracks[i].filename_R);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();

            //Freeobjs
            XElement freeobjs = new XElement("FreeObjects");
            master.Add(freeobjs);
            writer.WriteStartElement(freeobjs.Name.ToString());
            for (int i = 0; i < lib_freeobjs.Count; i++)
            {
                XElement freeobj_node = new XElement("freeobj", new XAttribute("id", i), new XAttribute("filename", lib_freeobjs[i].filename));
                freeobjs.Add(freeobj_node);
                writer.WriteStartElement(freeobj_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename");
                writer.WriteValue(lib_freeobjs[i].filename);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();

            //Beacons
            XElement beacons = new XElement("Beacons");
            master.Add(beacons);
            writer.WriteStartElement(beacons.Name.ToString());
            for (int i = 0; i < lib_beacons.Count; i++)
            {
                XElement beacon_node = new XElement("beacon", new XAttribute("id", i), new XAttribute("filename", lib_beacons[i].filename));
                beacons.Add(beacon_node);
                writer.WriteStartElement(beacon_node.Name.ToString());

                writer.WriteStartAttribute("id");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                writer.WriteStartAttribute("filename");
                writer.WriteValue(lib_beacons[i].filename);
                writer.WriteEndAttribute();

                writer.WriteFullEndElement();
            }
            writer.WriteEndElement();

            
            //Cycles
            XElement cycles = new XElement("Cycles");
            master.Add(cycles);
            writer.WriteStartElement(cycles.Name.ToString());

            //Cycle grounds
            for(int i=0;i<lib_cyclegrounds.Count;i++)
            {
                XElement cycleground_node = new XElement("ground", new XAttribute("cycleid", i));
                cycles.Add(cycleground_node);
                writer.WriteStartElement(cycleground_node.Name.ToString());

                writer.WriteStartAttribute("cycleid");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                for(int i2=0;i2<lib_cyclegrounds[i].grounds.Count;i2++)
                {
                    XElement cycle_ground_id = new XElement("id");
                    cycleground_node.Add(cycle_ground_id);
                    writer.WriteStartElement(cycle_ground_id.Name.ToString());
                    writer.WriteValue(lib_cyclegrounds[i].grounds[i2].id);
                    writer.WriteEndElement();
                }

                writer.WriteFullEndElement();

            }
            //Cycle rails
            for(int i=0;i<lib_cyclerails.Count;i++)
            {
                XElement cyclerail_node = new XElement("rail", new XAttribute("cycleid", i));
                cycles.Add(cyclerail_node);
                writer.WriteStartElement(cyclerail_node.Name.ToString());

                writer.WriteStartAttribute("cycleid");
                writer.WriteValue(i);
                writer.WriteEndAttribute();

                for (int i2 = 0; i2 < lib_cyclerails[i].rails.Count; i2++)
                {
                    XElement cycle_rail_id = new XElement("id");
                    cyclerail_node.Add(cycle_rail_id);
                    writer.WriteStartElement(cycle_rail_id.Name.ToString());
                    writer.WriteValue(lib_cyclerails[i].rails[i2].id);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();



            //End writing XML file
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();












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
            //Parsing grounds
            for(int i=0;i<lib_grounds.Count;i++)
            {
                parsed_interface.Add(lib_grounds[i].CSVParsed(i));
            }
            //Parsing rails
            for(int i=0;i<lib_rails.Count;i++)
            {
                parsed_interface.Add(lib_rails[i].CSVParsed(i));
            }
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
            //Parsing poles
            for(int i=0;i<lib_poles.Count;i++)
            {
                parsed_interface.Add(lib_poles[i].CSVParsed(i));
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
            //Parsing beacons
            for(int i=0;i<lib_beacons.Count;i++)
            {
                parsed_interface.Add(lib_beacons[i].CSVParsed(i));
            }

            parsed_interface.Add("With Texture\n");
            for(int i=0;i<lib_backgrounds.Count;i++)
            {
                parsed_interface.Add(lib_backgrounds[i].CSVParsed(i));
            }

            parsed_interface.Add("With Cycle\n");
            for (int i = 0; i < lib_cyclegrounds.Count; i++)
            {
                parsed_interface.Add(lib_cyclegrounds[i].CSVParsed(i));
            }
            for (int i = 0; i < lib_cyclerails.Count; i++)
            {
                parsed_interface.Add(lib_cyclerails[i].CSVParsed(i));
            }




            return parsed_interface;
        }



    }
}
