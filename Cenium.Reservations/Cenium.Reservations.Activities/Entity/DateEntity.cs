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


using Cenium.Framework.ComponentModel;
using Cenium.Framework.Data;
using System;

namespace Cenium.Reservations.Activities.Entity
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [Entity]
	public class DateEntity
    {

        /// <summary>
        /// Initializes a new instance of the DateEntity class
        /// </summary>
        public DateEntity()
        {

        }

        /// <summary>
        /// Date filter
        /// </summary>
        [EntityMember(Order = 0)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public DateTime CheckInDate { get; set; }


        /// <summary>
        /// Date filter
        /// </summary>
        /// [EntityMember(Order = 1)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public DateTime CheckOutDate { get; set; }


    }

}
