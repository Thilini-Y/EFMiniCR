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
 * Thilini.Y   11/24/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;
using Cenium.Reservations.Activities.Helpers.RoomType;
using Cenium.Reservations.Activities.Helpers.Room;

namespace Cenium.Reservations.Activities.Helpers.RoomType
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomTypeProxy : ProxyWrapperBase
    {

        public RoomTypeProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public RoomTypeProxy()
        {
            base.EntityProxy = RoomTypeHelper.CreateRoomTypeProxy();
        }

       


        public string Code
        {
            get { return GetValue<string>("Code"); }
            set { SetValue("Code", value); }
        }



    }

}
