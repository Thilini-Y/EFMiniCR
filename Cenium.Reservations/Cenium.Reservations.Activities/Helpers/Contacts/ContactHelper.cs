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
 * Thilini.Y   11/24/2021    Created
 */


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Contacts
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class ContactHelper
    {

        private static IActivityFactory _contactActivityFactory = ComponentManager.IsComponentInstalled("Contacts") ? ActivityManager.GetActivityFactory("Contacts") : null;
        private static IEntityFactory _contactEntityFactory = ComponentManager.IsComponentInstalled("Contacts") ? EntityManager.GetEntityFactory("Contacts") : null;

        private static bool _isContactAvailable = ((_contactEntityFactory == null) || (_contactActivityFactory == null)) ? false : _contactActivityFactory.IsActivityAvailable("Contact");

        /// <summary>
        /// Initializes a new instance of the ContactHelper class
        /// </summary>
        public static ContactProxy GetContactDetailsById(Int64 contactId)
        {
            if (!_isContactAvailable)
                return null;

            var activity = _contactActivityFactory.Create("Contact");
            var result = ((activity == null) || (!activity.IsMethodAvailable("Get"))) ? null : activity.Get("Get", contactId);

            var proxy = (result == null) ? null : new ContactProxy(result);
            return proxy == null ? null : proxy;
        }

        public static IEntityProxy CreateContactProxy()
        {
            return _isContactAvailable ? _contactEntityFactory.Create("Contact") : null;
        }


    }

}
