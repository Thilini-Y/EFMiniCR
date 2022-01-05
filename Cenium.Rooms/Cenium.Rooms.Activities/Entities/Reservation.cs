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

namespace Cenium.Rooms.Activities
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class Reservation
    {

        /// <summary>
        /// Initializes a new instance of the ReservationResult class
        /// </summary>
        public Reservation()
        {

        }

        /// <summary>
        /// Date filter
        /// </summary>
        [EntityMember(Order = 0)]
        public string RoomNumber { get; set; }

        /// <summary>
        /// Date filter
        /// </summary>
        [EntityMember(Order = 1)]
        public string RoomTypeName { get; set; }

        /// <summary>
        /// Date filter
        /// </summary>
        [EntityMember(Order = 2)]
        public string Status { get; set; }
    }

}
