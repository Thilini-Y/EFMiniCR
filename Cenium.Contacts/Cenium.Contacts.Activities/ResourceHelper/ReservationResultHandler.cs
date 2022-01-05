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
 * Thilini.Y   12/17/2021    Created
 */


using Cenium.Contacts.Activities.Entities.Extensions;
using Cenium.Framework.Activities;
using System;

namespace Cenium.Contacts.Activities.ResourceHelper
{
    public class ReservationResultHandler
    {

        /// <summary>
        /// Initializes a new instance of the ContactReservationExtension class
        /// </summary>
        public ReservationResultHandler()
        {

        }


        /// <summary>
        /// Explain the purpose of the class here
        /// </summary>
        //[ActivityResultExtension("Reservations/Reservation/Get/{ContactId}", "ContactExtension", "ContactExtension.Items")]
        //public class ReservationResultHandlerFactory : AbstractActivityResultHandlerFactory
        //{

        //    /// <summary>
        //    /// Initializes a new instance of the ReservationResultHandler class
        //    /// </summary>
        //    public ReservationResultHandlerFactory()
        //         : base(typeof(ContactReservationExtension), "Contacts.Contact", "ContactExtension")
        //    {

        //    }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //protected override IActivityResultExtensionHandler CreateHandler()
        //{
        //    return new ReservationHandler();
        //}

        //private class ReservationHandler : ContactResultHandler, IActivityResultExtensionHandler
        //{
        //    public override void CreateOrUpdate(string parentEntity, object parentKey, object entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public override void Delete(string parentEntity, object parentKey, object entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public override object Get(string parentEntity, object parentKey)
        //    {

        //        var id = SafeGetLongKey(parentKey);

        //        var result = new ContactReservationExtension();

        //        var contactData = Context.Contacts.FindByKeys(parentKey);

        //        result.Name = contactData.Name;
        //        result.DOB = contactData.DOB;
        //        result.IdNumber = contactData.IdNumber;
        //        result.Address = contactData.Address;

        //        return result;

        //    }
        //}


    }

}
