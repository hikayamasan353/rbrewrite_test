using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata01
{

    /// <summary>
    /// Position enum for walls, dikes, forms and roofs
    /// </summary>
    public enum Position
    {
        Left,
        Both,
        Right,
        None

    }

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
        /// Length of the module.
        /// For route editing.
        /// </summary>
        public int length;

        /// <summary>
        /// Distance of the module.
        /// Used to make modules previewable in RouteViewer
        /// </summary>
        public int distance;


        //Pitch height difference
        public int pitch_difference;

        //Pitch rate. Will be used in code.
        public int pitch_rate
        {
            get
            {
                return 1000 * (length / pitch_difference);
            }
        }

        //Curve radius. 0 for straight.
        public int curve;

        //Height above ground
        public int height;

        //Track objects
        //public ObjectLibrary.Wall wall;
        public int wall_index;
        public Position pos_wall;


        //public ObjectLibrary.Dike dike;
        public int dike_index;
        public Position pos_dike;




        /// <summary>
        /// Code of the module parsed into CSV as a route itself.
        /// Note: This is NOT a complete route, only a part of it.
        /// </summary>
        /// <returns></returns>
        public List<string> CSVParsed()
        {
            return null; ;
        }

        /// <summary>
        /// Code snippet for particular features on the certain distance of the With Track codespace.
        /// Similar to the RouteBuilder's Connection.
        /// </summary>
        public struct TrackNode
        {
            /// <summary>
            /// Code snippet for rail start. All rails are attached to the main rail which has index 0.
            /// </summary>
            /// <param name="RailIndex">Index for the rail being drawn</param>
            /// <param name="x">Horizontal offset</param>
            /// <param name="y">Vertical offset</param>
            /// <param name="RailType">Object library rail index</param>
            /// <returns></returns>
            public string TrackNode_Rail_CSVParsed(uint RailIndex,double x,double y,uint RailType)
            {
                return ".Rail " + RailIndex.ToString() + ";" + x.ToString() + ";" + y.ToString() + ";" + RailType.ToString();
            }

            public string TrackNode_RailEnd_CSVParsed(uint RailIndex, double x, double y)
            {
                return ".RailEnd " + RailIndex.ToString() + ";" + x.ToString() + ";" + y.ToString();
            }



            uint distance;

            public List<string> CSVParsed(int distance)
            {
                return null;
            }

        }




    }


}
