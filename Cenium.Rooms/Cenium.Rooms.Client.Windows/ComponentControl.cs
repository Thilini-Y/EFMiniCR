/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * Change History:
 * 
 * User        Date          Comment
 * ----------- ------------- --------------------------------------------------------------------------------------------
 * Thilini.Y   01/03/2022    Created
 */


using Cenium.Framework.Client;
using Cenium.Framework.Client.Windows.Media;
using System;

namespace Cenium.Rooms.Client.Windows
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    public class ComponentControl : IInitializer
    {

        private const string ICON_PATH = "D:/ceniumMiniproject/Cenium.Rooms/Cenium.Rooms.Client.Windows/Resources/Icons/{0}.png";
        // private const string COMPONENT = "orderprocessing";

        /// <summary>
        /// Initializes a new instance of the ComponentControl class
        /// </summary>
        public ComponentControl()
        {

        }

        void IInitializer.Initialize()
        {
            IconManager.Register("backoffice.icon.action.room.clean", string.Format(ICON_PATH, "Actions/TapeChartCleanAndOccupied32"));
            IconManager.Register("backoffice.icon.action.roomtype.managefeatures", string.Format(ICON_PATH, "Actions/ManageCategories"));
            

        }


    }

}
