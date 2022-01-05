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
 * Thilini.Y   12/01/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cenium.Rooms.Activities.Helpers.Reservations
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class ReservationResultProxy : ProxyWrapperBase
    {

        public ReservationResultProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public ReservationResultProxy()
        {
            base.EntityProxy = ReservationHelper.CreateReservationResultsProxy();
        }

        public IEnumerable<ReservationProxy> Items
        {
            get
            {
                var items = GetValue<ICollection<IEntityProxy>>("Items");
                if (items != null)
                    return items.Select(p => new ReservationProxy(p)).ToList();



                return new List<ReservationProxy>();
            }
        }



    }

}
