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
using Cenium.Reservations.Data;
using Cenium.Framework.Security;
using Cenium.Reservations.Activities.Helpers.Contacts;
using Cenium.Reservations.Activities.Helpers.Room;
using Cenium.Reservations.Activities.Entity;
using Cenium.Reservations.Activities.Helpers.Price;

namespace Cenium.Reservations.Activities
{

    /// <summary>
    /// The ReservationActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Reservations.Data.Reservation"/>
    /// <seealso cref="Cenium.Reservations.Data.ReservationsEntitiesContext"/>
    [Activity("Reservation")]
    public class ReservationActivity : IDisposable
    {

        private ReservationsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the ReservationActivity class
        /// </summary>
        public ReservationActivity()
        {
            _ctx = new ReservationsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the ReservationActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal ReservationActivity(ReservationsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Reservation&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Reservation> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Reservations.ReadOnlyQuery().OrderBy(p => p.ReservationId);



            return Logger.TraceMethodExit(result) as IEnumerable<Reservation>;
        }


        /// <summary>
        /// Gets a Reservation instance from the datastore based on Reservation keys.
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A Reservation instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Read)]
        public Reservation Get(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var result = _ctx.Reservations.FindByKeys(reservationId);

            ContactProxy contact_proxy = new ContactProxy(ContactHelper.CreateContactProxy());
            var contactResult = ContactHelper.GetContactDetailsById(result.ContactId);
            result.ContactName = contactResult.Name;
            result.IdNumber = contactResult.IdNumber;
            return Logger.TraceMethodExit(result) as Reservation;
        }


        /// <summary>
        /// Adds a new instance of Reservation to the data store
        /// </summary>
        /// <param name="reservation">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Create(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            //assign reservation ststus
            reservation.Status = "Created";

            //assign payment status
            reservation.PaymentStatus = "NotPaid";


            //calculate charging price
            if (reservation.CheckOutDate > reservation.CheckInDate)
            {
                int wholeDays = (reservation.CheckOutDate - reservation.CheckInDate).Days;

                var roomTypeDetails = RoomTypeHelper.GetRoomTypeDetailsByRoomTypeName(reservation.RoomTypeName);

                var priceResult = PriceHelper.GetPriceDetailsByCode(roomTypeDetails.Code);

                decimal roomPrice = priceResult.ChargingPrice;

                reservation.Price = roomPrice * wholeDays;


            }
            else
            {
                return null;
            }

            //generate reservation number
            var items = _ctx.Reservations.ReadOnlyQuery().OrderByDescending(p => p.ReservationNumber);

            if (items != null)
            {
                IEnumerable<Reservation> reservationNumberList = items.ToList();

                string maxReservationNumber = reservationNumberList.FirstOrDefault().ReservationNumber;

                maxReservationNumber = maxReservationNumber.Remove(0, 2);

                string newReservationNumber = string.Format("RE{0:000000}", long.Parse(maxReservationNumber) + 1);

                reservation.ReservationNumber = newReservationNumber;


            }

            else
            {
                string newReservationNumber = string.Format("RE{0:000000}", 1);

                reservation.ReservationNumber = newReservationNumber;
            }


            reservation = _ctx.Reservations.Add(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Update(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            if (reservation.RoomNumber != null )
            {
                //get RoomId
                var roomResult = RoomHelper.GetRoomDetailsByRoomumber(reservation.RoomNumber);
                reservation.RoomId = roomResult.RoomId;
            }

            //calculate charging price
            if (reservation.CheckOutDate > reservation.CheckInDate)
            {
                int wholeDays = (reservation.CheckOutDate - reservation.CheckInDate).Days;

                var roomTypeDetails = RoomTypeHelper.GetRoomTypeDetailsByRoomTypeName(reservation.RoomTypeName);

                var priceResult = PriceHelper.GetPriceDetailsByCode(roomTypeDetails.Code);

                decimal roomPrice = priceResult.ChargingPrice;

                reservation.Price = roomPrice * wholeDays;
               


            }
            else
            {
                return null;
            }



            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }

        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Confirm", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Confirm(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation.Status = "Confirmed";

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            RoomProxy room_proxy = new RoomProxy();
            room_proxy.RoomId = reservation.RoomId;
            room_proxy.RoomStatus = "Assigned";

            RoomHelper.ChangeRoomStatus(room_proxy);

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("CheckIn", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation CheckIn(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation.Status = "CheckedIn";

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            RoomProxy room_proxy = new RoomProxy();
            room_proxy.RoomId = reservation.RoomId;
            room_proxy.RoomStatus = "Occupied";

            RoomHelper.ChangeRoomStatus(room_proxy);

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("CheckOut", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation CheckOut(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation.Status = "CheckedOut";

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            RoomProxy room_proxy = new RoomProxy();
            room_proxy.RoomId = reservation.RoomId;
            room_proxy.RoomStatus = "Dirty";

            RoomHelper.ChangeRoomStatus(room_proxy);

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }

        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Cancel", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Cancel(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation.Status = "Cancel";

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Paid", MethodType.Update, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Paid(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation.PaymentStatus = "Paid";

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Deletes a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            _ctx.Reservations.Remove(reservation);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }



        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Reservation&gt; instance. 
        /// </summary>
        /// <param name="dates">The instance to delete</param>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("UnavailableRooms", MethodType.Invoke, IsDefault = true)]
        [ActivityResult("Items")]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Read)]
        public ReservationResults UnavailableRooms(DateEntity dates)
        {
            Logger.TraceMethodEnter(dates);

            var result = _ctx.Reservations.ReadOnlyQuery().Where(x => x.CheckInDate > dates.CheckOutDate || x.CheckOutDate < dates.CheckInDate);
            IEnumerable<Reservation> UnconflictReservations = result.ToList();

            IEnumerable<Reservation> allReservations = Query().ToList();

            IEnumerable<Reservation> ConflictReservations = allReservations.Where(p => !UnconflictReservations.Any(x => x.ReservationId == p.ReservationId)).ToList();

            var reservationResult = new ReservationResults();
            reservationResult.Items = ConflictReservations.ToList();
            return Logger.TraceMethodExit( reservationResult);

        }



        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A single Reservation instance, or null if the instance doesn't exist</returns>
        protected Reservation GetFromDatastore(long reservationId)
        {
            return _ctx.Reservations.ReadOnlyQuery().Where(p => p.ReservationId == reservationId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this ReservationActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
