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


using Cenium.Framework.Client.AppResources.Metadata;
using Cenium.Framework.Client.Metadata;
using System;
using Cenium.Framework.Client.Model;

namespace Cenium.Contacts.Client.Windows.Extentions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [RegisterEntityPropertyExtension("contacts.entityextension.ageyears")]
    public class AgeYearsEntityExtension : IEntityPropertyExtension
    {
        private const string DateOfBirth = "DOB";

        /// <summary>
        /// Initializes a new instance of the AgeYearsEntityExtension class
        /// </summary>
        public AgeYearsEntityExtension()
        {

        }

        public object Get(Record record)
        {
            if (record == null)
                return string.Empty;

            var dateOfBirth = record.GetValue<DateTime>(DateOfBirth);

            if (dateOfBirth > DateTime.Now)
                return string.Empty;

            if (dateOfBirth != null && dateOfBirth != DateTime.MinValue)
                return GetYears(dateOfBirth, DateTime.Today).ToString();

            return string.Empty;
        }

        public static int GetYears(DateTime dob, DateTime today)
        {
           

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }


            return years;
        }

        
    }

}
