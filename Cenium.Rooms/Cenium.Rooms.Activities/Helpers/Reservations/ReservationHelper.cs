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
 * Thilini.Y   11/29/2021    Created
 */


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using Cenium.Rooms.Activities.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cenium.Rooms.Activities.Helpers.Reservations
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class ReservationHelper
    {
        private static IActivityFactory _reservationsActivityFactory = ComponentManager.IsComponentInstalled("Reservations") ? ActivityManager.GetActivityFactory("Reservations") : null;
        public static IEntityFactory _reservationsEntityFactory = ComponentManager.IsComponentInstalled("Reservations") ? EntityManager.GetEntityFactory("Reservations") : null;

        private static bool _isReservationAvailable = ((_reservationsEntityFactory == null) || (_reservationsActivityFactory == null)) ? false : _reservationsActivityFactory.IsActivityAvailable("Reservation");


        /// <summary>
        /// Initializes a new instance of the ReservationHelper class
        /// </summary>
        public static ReservationResultProxy GetUnAvailableRooms(DateEntityProxy dates)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _reservationsActivityFactory.Create("Reservation");
            var result = ((activity == null) || (!activity.IsMethodAvailable("UnavailableRooms"))) ? null : (IEntityProxy)activity.Invoke("UnavailableRooms", dates.EntityProxy);
            

            return (result == null) ? new ReservationResultProxy() : new ReservationResultProxy(result);

        }

        /// <summary>
        /// Initializes a new instance of the ReservationHelper class
        /// </summary>
        public static ReservationProxy GetReservationDetails(long reservationId)
        {
            if (!_isReservationAvailable)
                return null;

            var activity = _reservationsActivityFactory.Create("Reservation");
            var result = ((activity == null) || (!activity.IsMethodAvailable("Get"))) ? null : activity.Get("Get", reservationId);


            var proxy = (result == null) ? null : new ReservationProxy(result);
            return proxy == null ? null : proxy;

        }


        public static IEntityProxy CreateReservationProxy()
        {
            return _isReservationAvailable ? _reservationsEntityFactory.Create("Reservation") : null;
        }

        public static IEntityProxy CreateDateEntityProxy()
        {
            return _isReservationAvailable ? _reservationsEntityFactory.Create("DateEntity") : null;
        }

        public static IEntityProxy CreateReservationResultsProxy()
        {
            return _isReservationAvailable ? _reservationsEntityFactory.Create("ReservationResults") : null;
        }

    }


}
