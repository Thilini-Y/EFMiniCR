﻿/*
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


using Cenium.Framework.Data;
using System;
using System.Collections.Generic;

namespace Cenium.Reservations.Activities.Entity.Extensions
{
   
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [Entity]
    public class ReservationContactExtension
    {

        /// <summary>
        /// Initializes a new instance of the OrderContactExtension class
        /// </summary>
        public ReservationContactExtension()
        {

        }

        /// <summary>
        ///
        /// </summary>
        [EntityMember(Order = 0)]
        public ICollection<ReservationContactExtensionItem> Items { get; set; }


    }

}
