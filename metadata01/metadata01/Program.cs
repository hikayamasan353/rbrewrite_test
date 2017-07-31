using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metadata01
{
    static class Program
    {



        /// <summary>
        /// Program options
        /// </summary>
        //Options options;




        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            


            //If there are no options,

            //We configure it for the first time.
            //By opening the BVE Directory dialog.
            //And then record them in the options.ini file.

            //Else,
            //We open already existing options.ini file.







        }
    }
}
