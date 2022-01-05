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


using Cenium.Framework.Data;
using System;
using System.Collections.Generic;

namespace Cenium.Rooms.Activities.Entities
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class ReservationResult
    {

        public ReservationResult()
        {
            Items = new List<Reservation>();
        }



        /// <summary>
        /// List of items.
        /// </summary>
        [EntityMember(Order = 0)]
        public ICollection<Reservation> Items { get; set; }


    }

}
