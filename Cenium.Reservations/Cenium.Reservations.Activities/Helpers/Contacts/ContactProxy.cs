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
 * Thilini.Y   11/23/2021    Created
 */


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Contacts
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class ContactProxy : ProxyWrapperBase
    {
        public ContactProxy(IEntityProxy proxy) : base(proxy) { }

        /// <summary>
        /// Initializes a new instance of the ContactProxy class
        /// </summary>
        public ContactProxy()
        {
            base.EntityProxy = ContactHelper.CreateContactProxy();
        }

        public string Name
        {
            get { return GetValue<string>("Name"); }
        }

        public string IdNumber
        {
            get { return GetValue<string>("IdNumber"); }
        }


    }

}
