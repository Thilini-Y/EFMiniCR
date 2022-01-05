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
 * Thilini.Y   12/30/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Price
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class PriceProxy : ProxyWrapperBase
    {

        public PriceProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public PriceProxy()
        {
            base.EntityProxy = PriceHelper.CreateContactProxy();
        }

        public string Code
        {
            get { return GetValue<string>("Code"); }
        }

        public decimal ChargingPrice
        {
            get { return GetValue<decimal>("ChargingPrice"); }
        }

        public long HotelId
        {
            get { return GetValue<long>("HotelId"); }
        }

    }

}
