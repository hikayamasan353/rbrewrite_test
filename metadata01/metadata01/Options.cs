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

namespace metadata01
{

    /// <summary>
    /// Software options.
    /// </summary>
    public class Options
    {

        /// <summary>
        /// options.ini file path
        /// </summary>
        public static string OptionsFile = Application.StartupPath + "\\options.ini";


        /// <summary>
        /// BVE/OpenBVE/HmmSim directory
        /// </summary>
        public string BVEDirectory;



        /// <summary>
        /// Ini file parser
        /// </summary>
        static FileIniDataParser parser = new FileIniDataParser();
        IniData data = parser.ReadFile(OptionsFile);



         /// <summary>
         /// Loads from options.ini file
         /// </summary>
        public void LoadFromIni()
        {
            

            //read BVE directory

            



        }


        /// <summary>
        /// Saves to options.ini file
        /// </summary>
        public void SaveToIni()
        {


            //save to BVE directory

            

        }






    }
}
