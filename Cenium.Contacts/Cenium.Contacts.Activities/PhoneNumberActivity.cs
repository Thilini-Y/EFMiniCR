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
 * Thilini.Y   11/22/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Contacts.Data;
using Cenium.Framework.Security;

namespace Cenium.Contacts.Activities
{

    /// <summary>
    /// The PhoneNumberActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Contacts.Data.PhoneNumber"/>
    /// <seealso cref="Cenium.Contacts.Data.ContactsEntitiesContext"/>
    [Activity("PhoneNumber")]
    public class PhoneNumberActivity : IDisposable
    {

        private ContactsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the PhoneNumberActivity class
        /// </summary>
        public PhoneNumberActivity()
        {
            _ctx = new ContactsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the PhoneNumberActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal PhoneNumberActivity(ContactsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;PhoneNumber&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("phoneNumver.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<PhoneNumber> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.PhoneNumbers.ReadOnlyQuery().OrderBy(p => p.PhoneNumberId);

            return Logger.TraceMethodExit(result) as IEnumerable<PhoneNumber>;
        }


        /// <summary>
        /// Gets a PhoneNumber instance from the datastore based on PhoneNumber keys.
        /// </summary>
        /// <param name="phoneNumberId">The key for PhoneNumber</param>
        /// <returns>A PhoneNumber instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("phoneNumver.administration", SecureResourcePermissionLevel.Read)]
        public PhoneNumber Get(long phoneNumberId)
        {
            Logger.TraceMethodEnter(phoneNumberId);

            var result = _ctx.PhoneNumbers.FindByKeys(phoneNumberId);

            return Logger.TraceMethodExit(result) as PhoneNumber;
        }


        /// <summary>
        /// Adds a new instance of PhoneNumber to the data store
        /// </summary>
        /// <param name="phoneNumber">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("phoneNumver.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.PhoneNumber Create(PhoneNumber phoneNumber)
        {
            Logger.TraceMethodEnter(phoneNumber);

            phoneNumber = _ctx.PhoneNumbers.Add(phoneNumber);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(phoneNumber.PhoneNumberId)) as PhoneNumber;
        }


        /// <summary>
        /// Updates a PhoneNumber instance in the data store
        /// </summary>
        /// <param name="phoneNumber">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("phoneNumver.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.PhoneNumber Update(PhoneNumber phoneNumber)
        {
            Logger.TraceMethodEnter(phoneNumber);

            phoneNumber = _ctx.PhoneNumbers.Modify(phoneNumber);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(phoneNumber.PhoneNumberId)) as PhoneNumber;
        }


        /// <summary>
        /// Deletes a PhoneNumber instance from the data store
        /// </summary>
        /// <param name="phoneNumber">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("phoneNumver.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(PhoneNumber phoneNumber)
        {
            Logger.TraceMethodEnter(phoneNumber);

            _ctx.PhoneNumbers.Remove(phoneNumber);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="phoneNumberId">The key for PhoneNumber</param>
        /// <returns>A single PhoneNumber instance, or null if the instance doesn't exist</returns>
        protected PhoneNumber GetFromDatastore(long phoneNumberId)
        {
            return _ctx.PhoneNumbers.ReadOnlyQuery().Where(p => p.PhoneNumberId == phoneNumberId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this PhoneNumberActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
