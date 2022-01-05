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
* User Date Comment
* ----------- ------------- --------------------------------------------------------------------------------------------
* evjem 11/02/2015 Created
*/




using Cenium.Framework.Data;
using Cenium.Reservations.Data;
using System.Collections.Generic;



namespace Cenium.Reservations.Activities.Entity
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [Entity]
    public class ReservationResults
    {
        public ReservationResults()
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

