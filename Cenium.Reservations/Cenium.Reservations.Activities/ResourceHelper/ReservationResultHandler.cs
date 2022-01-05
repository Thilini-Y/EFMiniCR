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


using Cenium.Framework.Activities;
using Cenium.Reservations.Data;
using System;

namespace Cenium.Reservations.Activities.ResourceHelper
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal abstract class ReservationResultHandler : AbstractContextActivityResultHandler<ReservationsEntitiesContext>
    {

        /// <summary>
        /// Initializes a new instance of the ReservationResultHandler class
        /// </summary>
        protected override ReservationsEntitiesContext CreateContext()
        {
            return new ReservationsEntitiesContext();
        }


    }



}
