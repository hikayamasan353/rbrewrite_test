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
    /// A custom settable length track section
    /// In code parser it's broken down into several 25 m connections.
    /// 
    /// </summary>
    public class Track
    {
        //ObjectLibrary that it uses
        ObjectLibrary library;

        

        //Length of a track
        public int length;

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
        /// CSV parsed code piece for use in the complete route code.
        /// </summary>
        /// <returns>A piece of code</returns>
        public string CSVParsed()
        {
            //TODO: Multiple rails

            //Track geometry
            List<string> list = new List<string>();

            list.Add(".Pitch " + pitch_rate.ToString() + "\n");
            list.Add(".Curve " + curve.ToString() + ";0\n");
            list.Add(".Height " + height.ToString() + "\n");


            //Wall used by track
            switch(pos_wall)
            {
                case Position.Both:
                    {
                        list.Add(".Wall 0;0;" + wall_index.ToString());
                        break;
                    }
                case Position.Left:
                    {
                        list.Add(".Wall 0;-1;" + wall_index.ToString());
                        break;
                    }
                case Position.Right:
                    {
                        list.Add(".Wall 0;1;" + wall_index.ToString());
                        break;
                    }
                case Position.None:
                    {
                        list.Add(".WallEnd 0");
                        break;
                    }
            }
            //Dike used by track
            switch (pos_dike)
            {
                case Position.Both:
                    {
                        list.Add(".Dike 0;0;" + dike_index.ToString());
                        break;
                    }
                case Position.Left:
                    {
                        list.Add(".Dike 0;-1;" + dike_index.ToString());
                        break;
                    }
                case Position.Right:
                    {
                        list.Add(".Dike 0;1;" + dike_index.ToString());
                        break;
                    }
                case Position.None:
                    {
                        list.Add(".DikeEnd 0");
                        break;
                    }
            }




            return null;
        }


    }

    /// <summary>
    /// A 25 m track piece.
    /// The BVE Route is broken down into several of those.
    /// Unlike manual coding which omits insignificant details, the RouteBuilder tracks will generate every 25 m of the route.
    /// </summary>
    public class Track25
    {

        //ObjectLibrary that it uses
        ObjectLibrary library;

        //Parts of track piece

            //Pitch height difference
        public int pitch_difference;

        //Pitch of the track
        public int pitch_rate
        {
            get
            {
                return 1000 * (25 / pitch_difference);
            }
        }


        public string CSVParsed()
        {
            //TODO: Multiple rails

            List<string> list = new List<string>();

            list.Add(".Pitch " + pitch_rate.ToString() + "\n");


            return null;
        }
    }
}
