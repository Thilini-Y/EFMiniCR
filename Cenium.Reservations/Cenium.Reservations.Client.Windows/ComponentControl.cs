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

namespace Cenium.Reservations.Client.Windows
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class ComponentControl : IInitializer
    {

        private const string ICON_PATH = "D:/ceniumMiniproject/Cenium.Reservations/Cenium.Reservations.Client.Windows/Resources/Icons/{0}.png";
       // private const string COMPONENT = "orderprocessing";

        /// <summary>
        /// Initializes a new instance of the ComponentControl class
        /// </summary>
        public ComponentControl()
        {

        }

        void IInitializer.Initialize()
        {
            IconManager.Register("frontdesk.icon.action.reservation.checkin", string.Format(ICON_PATH, "Actions/ActionCheckIn32"));
            IconManager.Register("frontdesk.icon.action.reservation.checkout", string.Format(ICON_PATH, "Actions/ActionCheckOut32"));
            IconManager.Register("frontdesk.icon.action.reservation.confirm", string.Format(ICON_PATH, "Actions/ActionConfirm32"));
            IconManager.Register("frontdesk.icon.action.reservation.cancel", string.Format(ICON_PATH, "Actions/ActionCancel32"));
            IconManager.Register("frontdesk.icon.action.reservation.payment", string.Format(ICON_PATH, "Actions/ActionPayment32"));


        }


    }

}
