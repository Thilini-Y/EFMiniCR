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
 * Thilini.Y   12/20/2021    Created
 */


using Cenium.Framework.Activities;
using Cenium.Reservations.Activities.Entity.Extensions;
using System;
using System.Linq;

namespace Cenium.Reservations.Activities.ResourceHelper
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [ActivityResultExtension("Contacts/Contact/Get/{ContactId}", "ReservationExtension", "ReservationExtension.Items", "ReservationExtension.Items.PropertyContext")]
    public class ContactResultHandlerFactory : AbstractActivityResultHandlerFactory
    {

        /// <summary>
        /// Initializes a new instance of the ContactResultHandler class
        /// </summary>
        public ContactResultHandlerFactory() : base(typeof(ReservationContactExtension), "Contacts.Contact", "ReservationExtension")
        {

        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override IActivityResultExtensionHandler CreateHandler()
        {
            return new ContactHandler();
        }

        private class ContactHandler : ReservationResultHandler, IActivityResultExtensionHandler
        {
            public override void CreateOrUpdate(string parentEntity, object parentKey, object entity)
            {
                
            }

            public override void Delete(string parentEntity, object parentKey, object entity)
            {
                
            }

            public override object Get(string parentEntity, object parentKey)
            {
                var id = SafeGetLongKey(parentKey);

                var result = new ReservationContactExtension();

                result.Items = Context.Reservations.ReadOnlyQuery()
                    .Where(x => x.ContactId == id)
                    .Select(y => new ReservationContactExtensionItem()
                    {
                        ReservationNumber = y.ReservationNumber,
                        CheckInDate = y.CheckInDate,
                        CheckOutDate = y.CheckOutDate,
                        Status = y.Status,
                        PropertyContextId = y.PropertyContextId

                }).ToList();
                

                return result;
            }


        }


    }

}
