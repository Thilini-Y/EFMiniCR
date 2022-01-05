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
	internal class DateEntityProxy : ProxyWrapperBase
    {

        public DateEntityProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public DateEntityProxy()
        {
            base.EntityProxy = ReservationHelper.CreateDateEntityProxy();
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

       


    }

}
