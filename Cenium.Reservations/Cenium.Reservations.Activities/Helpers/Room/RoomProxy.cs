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

namespace Cenium.Reservations.Activities.Helpers.Room
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomProxy : ProxyWrapperBase
    {

        public RoomProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public RoomProxy()
        {
            base.EntityProxy = RoomHelper.CreateRoomProxy();
        }

        public Int64 RoomId
        {
            get { return GetValue<Int64>("RoomId"); }
            set { SetValue("RoomId",value); }

        }


        public string RoomStatus
        {
            get { return GetValue<string>("RoomStatus"); }
            set { SetValue("RoomStatus", value); }
        }



    }

}
