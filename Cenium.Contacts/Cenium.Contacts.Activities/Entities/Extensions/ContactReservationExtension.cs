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
 * Thilini.Y   12/17/2021    Created
 */


using Cenium.Framework.ComponentModel;
using Cenium.Framework.Data;
using System;

namespace Cenium.Contacts.Activities.Entities.Extensions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public class ContactReservationExtension
    {

        /// <summary>
        /// Initializes a new instance of the ContactReservationExtension class
        /// </summary>
        public ContactReservationExtension()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 0)]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 1)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public DateTime DOB { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 2)]
        public string IdNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 3)]
        public string Address { get; set; }


    }

}
