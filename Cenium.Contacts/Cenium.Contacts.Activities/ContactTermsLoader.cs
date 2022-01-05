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


using Cenium.Framework.Language;
using System;

namespace Cenium.Contacts.Activities
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class ContactTermsLoader
    {
        public const string TermContactFirstMiddleLast = "@contacts.firstmiddlelast";

        internal static void ContactTermLoadImpl(TermCollection collection)
        {
            collection.Add(TermContactFirstMiddleLast, "First/Middle/Last");
        }


    }

}
