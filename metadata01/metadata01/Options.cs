using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using IniParser;
using IniParser.Model;
using IniParser.Exceptions;
using IniParser.Parser;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Xml;


namespace metadata01
{

    /// <summary>
    /// Software options.
    /// </summary>
    public class Options
    {

        /// <summary>
        /// options.xml file path
        /// </summary>
        public static string OptionsFile = Application.StartupPath + "\\options.xml";


        /// <summary>
        /// BVE/OpenBVE/HmmSim directory
        /// </summary>
        public string BVEDirectory;

        /// <summary>
        /// Object Libraries directory name
        /// </summary>
        public string ObjectLibDir;

        /// <summary>
        /// Object libraries path
        /// </summary>
        public string ObjectLibPath
        {
            get
            {
                return Application.StartupPath + "\\" + ObjectLibDir;
            }
        }

        /// <summary>
        /// Read options from file
        /// </summary>
        public void ReadFromFile()
        {
            //Creating a reader stream

            XmlReader reader = XmlReader.Create(OptionsFile);


                reader.ReadStartElement("Options");//<Options>

                reader.ReadStartElement("BVEPath");

            this.BVEDirectory = reader.ReadContentAsString();
                reader.ReadEndElement();

                reader.ReadStartElement("ObjectLibDir");
                this.ObjectLibDir = reader.ReadContentAsString();
                reader.ReadEndElement();
                //reader.ReadElementContentAsString("BVEPath", this.BVEDirectory);
                //reader.ReadElementContentAsString("ObjectLibDir", this.ObjectLibDir);

                reader.ReadEndElement();//</Options>
                reader.Close();
            

        }

        /// <summary>
        /// Write options to file
        /// </summary>
        public void SaveToFile()
        {
            //Creating a writer stream
            XmlWriter writer = XmlWriter.Create(OptionsFile);
            
            writer.WriteStartElement("Options"); //<Options>
            //BVE Directory
            writer.WriteStartElement("BVEPath");
            writer.WriteString(this.BVEDirectory);
            writer.WriteEndElement();

            writer.WriteStartElement("ObjectLibDir");
            writer.WriteString(this.ObjectLibDir);
            writer.WriteEndElement();

            //writer.WriteElementString("ObjectLibDir", this.ObjectLibDir);
            writer.WriteEndElement();//</Options>
            writer.Close();



        }

        /// <summary>
        /// Creates default options
        /// </summary>
        public Options()
        {
            this.BVEDirectory = "none";
            this.ObjectLibDir = "lib";
        }


    }









}

