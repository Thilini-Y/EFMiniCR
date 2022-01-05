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
 * Thilini.Y   12/31/2021    Created
 */


using Cenium.Framework.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenium.Contacts.Data
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [EntityInfo(ValueListProperties = "ContactNumber,Name,DOB,IdNumber,Address", PrimaryDisplayProperty = "Name")]
    public partial class Contact
    {

        /// <summary>
        /// Initializes a new instance of the Contact class
        /// </summary>
        public Contact()
        {

        }

        /// <summary>
        /// Display date end used by date of birth date picker to disable registrating DOB into the future
        /// </summary>
        [NotMapped]
        [EntityMember(IsReadOnly = false, IsSortable = false, IsQueryable = false, Order = 101)]
        public virtual DateTime DisplayDateEnd
        {
            get { return DateTime.Now; }
        }

    }

}
