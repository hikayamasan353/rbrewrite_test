using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata01
{

    /// <summary>
    /// RouteBuilder editor track grid. Like in old RouteBuilder.
    /// </summary>
    public class RBGrid
    {
        /// <summary>
        /// Horizontal size
        /// </summary>
        public int H;
        /// <summary>
        /// Vertical size
        /// </summary>
        public int V;

        /// <summary>
        /// Tracks that belong to the grid. [Horizontal, Vertical]
        /// </summary>
        public RBGridTrack[,] tracks;

        /// <summary>
        /// Grid curve radius
        /// To distinguish .Curve from .Turn
        /// </summary>
        public int curve=0;

        /// <summary>
        /// Grid rotation in workspace. Not for export. Used to calculate.
        /// </summary>
        public int rotation=0;

        /// <summary>
        /// Creates an 1x1 grid for tracks
        /// </summary>
        public RBGrid()
        {
            this.H = 1;
            this.V = 1;
            tracks = new RBGridTrack[1, 1];

        }

        public RBGrid(int h, int v)
        {
            this.H = h;
            this.V = v;
            tracks = new RBGridTrack[h, v];
        }

        /// <summary>
        /// Adds horizontal row
        /// </summary>
        public void AddH()
        {
            this.H += 1;
        }

        public void AddV()
        {
            this.V += 1;
        }



    }

    public enum RBGridTrackType
    {
        Straight,
        TurnL,
        TurnR,
        SwitchLL,
        SwitchLR,
        SwitchRL,
        SwitchRR,
        SwitchYL,
        SwitchYR
    }


    /// <summary>
    /// A track that belongs to a grid. 25 m long. Can be parsed if belongs to the RouteDefinition.
    /// </summary>
    public class RBGridTrack
    {

        public RBGridTrackType TrackType;

        /// <summary>
        /// Creates a default straight track
        /// </summary>
        public RBGridTrack()
        {
            this.TrackType = RBGridTrackType.Straight;
        }

        public RBGridTrack(RBGridTrackType tracktype)
        {
            this.TrackType = tracktype;
        }


        //ObjectLibrary that it uses
        RBObjectLibrary library;



        //Length of a track
        public int length;

        //Pitch height difference
        public int pitch_difference;

        //Pitch rate. Will be used in code.
        public int pitch_rate
        {
            get
            {
                return 1000 * (pitch_difference / length);
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

        //Forms and roofs go together.
        public int form_index;
        public int roof_index;
        public Position pos_form;


        /// <summary>
        /// CSV parsed code piece for use in the complete route code.
        /// </summary>
        /// <returns>A piece of code</returns>
        public List<string> CSVParsed()
        {
            //TODO: Multiple rails

            //Track geometry
            List<string> list = new List<string>();

            list.Add(".Pitch " + pitch_rate.ToString() + "\n");
            list.Add(".Curve " + curve.ToString() + ";0\n");
            list.Add(".Height " + height.ToString() + "\n");


            //Wall used by track
            switch (pos_wall)
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
            //Forms with roofs
            //ToDo: Forms are strictly 25 m. Do some interpolation.
            switch (pos_form)
            {
                case Position.Left:
                    {
                        list.Add(".Form 0;L;" + roof_index.ToString() + ";" + form_index.ToString());
                        break;

                    }
                case Position.Right:
                    {
                        list.Add(".Form 0;R;" + roof_index.ToString() + ";" + form_index.ToString());
                        break;
                    }
                case Position.Both:
                    {
                        list.Add(".Form 0;B;" + roof_index.ToString() + ";" + form_index.ToString());
                        break;
                    }
                case Position.None:
                    break;

            }






            return list;
        }








    }



}
