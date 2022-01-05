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
 * Thilini.Y   11/16/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Prices.Data;
using Cenium.Framework.Security;

namespace Cenium.Prices.Activities
{

    /// <summary>
    /// The PriceActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Prices.Data.Price"/>
    /// <seealso cref="Cenium.Prices.Data.PricesEntitiesContext"/>
    [Activity("Price")]
    public class PriceActivity : IDisposable
    {

        private PricesEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the PriceActivity class
        /// </summary>
        public PriceActivity()
        {
            _ctx = new PricesEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the PriceActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal PriceActivity(PricesEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Price&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Price> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Prices.ReadOnlyQuery().OrderBy(p => p.PriceId);

            return Logger.TraceMethodExit(result) as IEnumerable<Price>;
        }


        /// <summary>
        /// Gets a Price instance from the datastore based on Price keys.
        /// </summary>
        /// <param name="priceId">The key for Price</param>
        /// <returns>A Price instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Read)]
        public Price Get(long priceId)
        {
            Logger.TraceMethodEnter(priceId);

            var result = _ctx.Prices.FindByKeys(priceId);

            return Logger.TraceMethodExit(result) as Price;
        }

        /// <summary>
        /// Gets a Price instance from the datastore based on Price keys.
        /// </summary>
        /// <param name="priceCode">The key for Price</param>
        /// <returns>A Price instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("GetByCode", MethodType.Get, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Read)]
        public Price GetByCode(string priceCode)
        {
            Logger.TraceMethodEnter(priceCode);

            var result = _ctx.Prices.ReadOnlyQuery().Where(x => x.Code == priceCode).FirstOrDefault();

            return Logger.TraceMethodExit(result) as Price;
        }


        /// <summary>
        /// Adds a new instance of Price to the data store
        /// </summary>
        /// <param name="price">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Prices.Data.Price Create(Price price)
        {
            Logger.TraceMethodEnter(price);

            price = _ctx.Prices.Add(price);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(price.PriceId)) as Price;
        }


        /// <summary>
        /// Updates a Price instance in the data store
        /// </summary>
        /// <param name="price">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Prices.Data.Price Update(Price price)
        {
            Logger.TraceMethodEnter(price);

            price = _ctx.Prices.Modify(price);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(price.PriceId)) as Price;
        }


        /// <summary>
        /// Deletes a Price instance from the data store
        /// </summary>
        /// <param name="price">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("price.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Price price)
        {
            Logger.TraceMethodEnter(price);

            _ctx.Prices.Remove(price);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="priceId">The key for Price</param>
        /// <returns>A single Price instance, or null if the instance doesn't exist</returns>
        protected Price GetFromDatastore(long priceId)
        {
            return _ctx.Prices.ReadOnlyQuery().Where(p => p.PriceId == priceId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this PriceActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
