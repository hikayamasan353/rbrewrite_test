using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata01
{

    /// <summary>
    /// Common code tools
    /// </summary>
    public static class Common
    {


        /// <summary>
        /// Processes a string in CSV by replacing some characters with directives
        /// </summary>
        /// <param name="s">String to be processed</param>
        public static string ProcessString(string s)
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



            //comma
            if (s.Contains(','))
            {
                s = s.Replace(','.ToString(), "\u0024Chr(44)");
            }


            //colon
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
    }
}
