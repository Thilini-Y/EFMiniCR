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
 * Thilini.Y   11/15/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Contacts.Data;
using Cenium.Framework.Security;
using Cenium.Framework.Data;

namespace Cenium.Contacts.Activities
{

    /// <summary>
    /// The ContactActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Contacts.Data.Contact"/>
    /// <seealso cref="Cenium.Contacts.Data.ContactsEntitiesContext"/>
    [Activity("Contact")]
    public class ContactActivity : IDisposable
    {

        private ContactsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the ContactActivity class
        /// </summary>
        public ContactActivity()
        {
            _ctx = new ContactsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the ContactActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal ContactActivity(ContactsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Contact&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("Emails")]
        [ActivityResult("PhoneNumbers")]
        [SecureResource("contact.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Contact> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Contacts.ReadOnlyQuery().OrderBy(p => p.ContactId);

            return Logger.TraceMethodExit(result) as IEnumerable<Contact>;
        }


        /// <summary>
        /// Gets a Contact instance from the datastore based on Contact keys.
        /// </summary>
        /// <param name="contactId">The key for Contact</param>
        /// <returns>A Contact instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [ActivityResult("Emails")]
        [ActivityResult("PhoneNumbers")]
        [SecureResource("contact.administration", SecureResourcePermissionLevel.Read)]
        public Contact Get(long contactId)
        {
            Logger.TraceMethodEnter(contactId);

            var result = _ctx.Contacts.FindByKeys(contactId);

            return Logger.TraceMethodExit(result) as Contact;
        }


        /// <summary>
        /// Adds a new instance of Contact to the data store
        /// </summary>
        /// <param name="contact">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [ActivityResult("Emails")]
        [ActivityResult("PhoneNumbers")]
        [SecureResource("contact.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Contact Create(Contact contact)
        {
            Logger.TraceMethodEnter(contact);

            //generate reservation number
            var items = _ctx.Contacts.ReadOnlyQuery().OrderByDescending(p => p.ContactNumber);

            if (items != null)
            {
                IEnumerable<Contact> contactNumberList = items.ToList();

                string maxContactNumber = contactNumberList.FirstOrDefault().ContactNumber;

                maxContactNumber = maxContactNumber.Remove(0, 2);

                string newContactNumber = string.Format("CN{0:000000}", long.Parse(maxContactNumber) + 1);

                contact.ContactNumber = newContactNumber;


            }

            else
            {
                string newContactNumber = string.Format("CN{0:000000}", 1);

                contact.ContactNumber = newContactNumber;
            }


            _ctx.Contacts.AttachChildCollection<Email>(contact, "Emails");
            _ctx.Contacts.AttachChildCollection<PhoneNumber>(contact, "PhoneNumbers");


            if (contact.ProfileImage == null || contact.ProfileImage == Guid.Empty)
            {
                contact.ProfileImage = Guid.NewGuid();
            }
      

            contact = _ctx.Contacts.Add(contact);
            _ctx.SaveChanges();


            ImageStorageManager.Claim(contact.ProfileImage.Value);



            return Logger.TraceMethodExit(GetFromDatastore(contact.ContactId)) as Contact;
        }


        /// <summary>
        /// Updates a Contact instance in the data store
        /// </summary>
        /// <param name="contact">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [ActivityResult("Emails")]
        [ActivityResult("PhoneNumbers")]
        [SecureResource("contact.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Contacts.Data.Contact Update(Contact contact)
        {
            Logger.TraceMethodEnter(contact);

            if (contact.ProfileImage == null || contact.ProfileImage == Guid.Empty)
            {
                contact.ProfileImage = Guid.NewGuid();
            }

            _ctx.Contacts.AttachChildCollection<Email>(contact, "Emails");
            _ctx.Contacts.AttachChildCollection<PhoneNumber>(contact, "PhoneNumbers");
            contact = _ctx.Contacts.Modify(contact);
            _ctx.SaveChanges();

            ImageStorageManager.Claim(contact.ProfileImage.Value);


            return Logger.TraceMethodExit(GetFromDatastore(contact.ContactId)) as Contact;
        }


        /// <summary>
        /// Deletes a Contact instance from the data store
        /// </summary>
        /// <param name="contact">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [ActivityResult("Emails")]
        [ActivityResult("PhoneNumbers")]
        [SecureResource("contact.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Contact contact)
        {
            Logger.TraceMethodEnter(contact);

            _ctx.Contacts.AttachChildCollection<Email>(contact, "Emails");
            _ctx.Contacts.AttachChildCollection<PhoneNumber>(contact, "PhoneNumbers");
            _ctx.Contacts.Remove(contact);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="contactId">The key for Contact</param>
        /// <returns>A single Contact instance, or null if the instance doesn't exist</returns>
        protected Contact GetFromDatastore(long contactId)
        {
            return _ctx.Contacts.ReadOnlyQuery().Where(p => p.ContactId == contactId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this ContactActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
