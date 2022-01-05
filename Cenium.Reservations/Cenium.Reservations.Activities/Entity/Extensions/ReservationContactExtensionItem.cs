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
 * Thilini.Y   12/20/2021    Created
 */


using Cenium.Framework.ComponentModel;
using Cenium.Framework.Context;
using Cenium.Framework.Data;
using System;

namespace Cenium.Reservations.Activities.Entity.Extensions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [Entity]
    [PropertyContextEntity("PropertyContextId")]
    [EntityReference("PropertyContext", "PropertyContext", "PropertyContextId")]
    public class ReservationContactExtensionItem
    {

        /// <summary>
        /// Initializes a new instance of the ReservationContactExtension class
        /// </summary>
        public ReservationContactExtensionItem()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 0)]
        public string ReservationNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 1)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public DateTime CheckInDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 2)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 3)]
        public string Status { get; set; }


        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 4)]
        public long PropertyContextId { get; set; }


    }

}
