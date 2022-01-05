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
 * Thilini.Y   11/29/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Rooms.Activities.Helpers.Reservations
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class ReservationProxy : ProxyWrapperBase
    {

        public ReservationProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public ReservationProxy()
        {
            base.EntityProxy = ReservationHelper.CreateReservationProxy();
        }

        public Int64 ReservationId
        {
            get { return GetValue<Int64>("ReservationId"); }
            set { SetValue("ReservationId", value); }

        }

        public Int64 RoomId
        {
            get { return GetValue<Int64>("RoomId"); }
            set { SetValue("RoomId", value); }

        }

        public string RoomNumber
        {
            get { return GetValue<string>("RoomNumber"); }
            set { SetValue("RoomNumber", value); }

        }

        public string ReservationNumber
        {
            get { return GetValue<string>("ReservationNumber"); }
            set { SetValue("ReservationNumber", value); }

        }


        public DateTime CheckInDate
        {
            get { return GetValue<DateTime>("CheckInDate"); }
            set { SetValue("CheckInDate", value); }

        }

        public DateTime CheckOutDate
        {
            get { return GetValue<DateTime>("CheckOutDate"); }
            set { SetValue("CheckOutDate", value); }

        }

        public string RoomTypeName
        {
            get { return GetValue<string>("RoomTypeName"); }
            set { SetValue("RoomTypeName", value); }

        }

        public string Status
        {
            get { return GetValue<string>("Status"); }
            set { SetValue("Status", value); }

        }


    }

}
