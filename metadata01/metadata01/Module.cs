using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata01
{

    /// <summary>
    /// A code snippet that represents the "block" for route building. Similar to a Connection in old RouteBuilder.
    /// Unlike RouteBuilder Connections, it actually is not a single connection, but a full-coded part of the route.
    /// Is also used like include files in manual coding.
    /// </summary>
    public class Module
    {


        /// <summary>
        /// Object library used by module
        /// </summary>
        public ObjectLibrary used_library;



        /// <summary>
        /// Distance of the module.
        /// Used to make modules previewable in RouteViewer
        /// </summary>
        public uint distance;




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> CSVParsed()
        {
            return null; ;
        }






    }
}
