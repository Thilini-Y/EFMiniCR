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


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Price
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class PriceHelper
    {
        private static IActivityFactory _priceActivityFactory = ComponentManager.IsComponentInstalled("Prices") ? ActivityManager.GetActivityFactory("Prices") : null;
        private static IEntityFactory _priceEntityFactory = ComponentManager.IsComponentInstalled("Prices") ? EntityManager.GetEntityFactory("Prices") : null;

        private static bool _isPriceAvailable = ((_priceEntityFactory == null) || (_priceActivityFactory == null)) ? false : _priceActivityFactory.IsActivityAvailable("Price");

        /// <summary>
        /// Initializes a new instance of the ContactHelper class
        /// </summary>
        public static PriceProxy GetPriceDetailsByCode(string code)
        {
            if (!_isPriceAvailable)
                return null;

            var activity = _priceActivityFactory.Create("Price");
            var result = ((activity == null) || (!activity.IsMethodAvailable("GetByCode"))) ? null : activity.Get("GetByCode", code);

            var proxy = (result == null) ? null : new PriceProxy(result);
            return proxy == null ? null : proxy;
        }

        public static IEntityProxy CreateContactProxy()
        {
            return _isPriceAvailable ? _priceEntityFactory.Create("Price") : null;
        }


    }

}
