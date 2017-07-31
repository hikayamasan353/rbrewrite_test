using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metadata01
{


    /// <summary>
    /// RouteBuilder in-software project. Contains all attributes that can be
    /// converted into .CSV and .RW files in future.
    /// </summary>
    public class Project
    {
                      /// <summary>
                      /// Route safety system settings (Route.Change)
                      /// </summary>
        public int change;


        /// <summary>
        /// Project description (will be in Route.Comment)
        /// </summary>
        public string description;
        /// <summary>
        /// Project gauge (will be in Route.Gauge)
        /// </summary>
        public int gauge;

        /// <summary>
        /// Project image path (will be in Route.Image)
        /// </summary>
        public string image;

        /// <summary>
        /// Project elevation above sea level (Route.Height)
        /// </summary>
        public double height;

        /// <summary>
        /// Project interval list of trains.
        /// Positive means before the player, negative means after the player.
        /// Represented in Route.RunInterval.
        /// </summary>
        public List<int> intervals;

                                /// <summary>
                                /// Light direction pitch (aka Theta)
                                /// 
                                /// </summary>
        public int lightdir_pitch;

        /// <summary>
        /// Light direction yaw (aka Phi)
        /// </summary>
        public int lightdir_yaw;


        /// <summary>
        /// Object library used by project
        /// </summary>
        public ObjectLibrary library;



        public Project()
        {
            //by default, set the most popular settings:
            //safety system on, emergency brakes.
            change = 0;
            //set an empty string as a description
            description = "";
            //standard gauge
            gauge = 1435;
            //it's up to a user to set an image
            image = "";
            //consider it runs on a flat surface
            height = 0.0;





            //by default, the player on a route is alone
            intervals = new List<int>();

            //by default, let's set all values to 0
            lightdir_pitch = 0;
            lightdir_yaw = 0;

        }



    }
}
