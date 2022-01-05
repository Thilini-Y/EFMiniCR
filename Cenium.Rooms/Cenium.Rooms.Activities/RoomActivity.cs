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
 * Thilini.Y   11/19/2021    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Rooms.Data;
using Cenium.Framework.Security;
using Cenium.Rooms.Activities.Entities;
using Cenium.Rooms.Activities.Helpers.Reservations;
using System.Collections;

namespace Cenium.Rooms.Activities
{

    /// <summary>
    /// The RoomActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.Room"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("Room")]
    public class RoomActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the RoomActivity class
        /// </summary>
        public RoomActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the RoomActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal RoomActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Room&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Rooms.ReadOnlyQuery().OrderBy(p => p.RoomId);

            return Logger.TraceMethodExit(result) as IEnumerable<Room>;
        }


        /// <summary>
        /// Gets a Room instance from the datastore based on Room keys.
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A Room instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public Room Get(long roomId)
        {
            Logger.TraceMethodEnter(roomId);

            var result = _ctx.Rooms.FindByKeys(roomId);

            return Logger.TraceMethodExit(result) as Room;
        }

        /// <summary>
        /// Gets a Room instance from the datastore based on Room keys.
        /// </summary>
        /// <param name="roomNumber">The key for Room</param>
        /// <returns>A Room instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("GetByRoomNumber", MethodType.Get, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public Room GetByRoomNumber(string roomNumber)
        {
            Logger.TraceMethodEnter(roomNumber);

            var result = _ctx.Rooms.ReadOnlyQuery().Where(x => x.RoomNumber.Equals(roomNumber) ).FirstOrDefault();

            return Logger.TraceMethodExit(result) as Room;
        }


        /// <summary>
        /// Adds a new instance of Room to the data store
        /// </summary>
        /// <param name="room">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Create(Room room)
        {
            Logger.TraceMethodEnter(room);

            //generate room number
            var items = _ctx.Rooms.ReadOnlyQuery().OrderByDescending(p => p.RoomNumber);

            if (items != null)
            {
                IEnumerable<Room> roomNumberList = items.ToList();

                string maxRoomNumber = roomNumberList.FirstOrDefault().RoomNumber;

                maxRoomNumber = maxRoomNumber.Remove(0, 2);

                string newRoomnNumber = string.Format("RM{0:000000}", long.Parse(maxRoomNumber) + 1);

                room.RoomNumber = newRoomnNumber;


            }

            else
            {
                string newRoomnNumber = string.Format("RM{0:000000}", 1);

                room.RoomNumber = newRoomnNumber;
            }

            room.RoomStatus = "Clean";



            room = _ctx.Rooms.Add(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Updates a Room instance in the data store
        /// </summary>
        /// <param name="room">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Update(Room room)
        {
            Logger.TraceMethodEnter(room);

            room = _ctx.Rooms.Modify(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        [ActivityMethod("ChangeStatus", MethodType.Invoke, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void ChangeStatus(Room room)
        {
            Logger.TraceMethodEnter(room);

            var roomStatus = room.RoomStatus;

            room = _ctx.Rooms.ReadOnlyQuery().Where(x => x.RoomId == room.RoomId).FirstOrDefault();

            room.RoomStatus = roomStatus;

            room = _ctx.Rooms.Modify(room);
            _ctx.SaveChanges();

            
        }

        [ActivityMethod("Clean", MethodType.Invoke, IsDefault = true)]
        [ActivityResult("RoomType")]
        [ActivityResult("RoomType.FeatureRoomTypes")]
        [ActivityResult("RoomType.FeatureRoomTypes.Feature")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Room Clean(Room room)
        {
            Logger.TraceMethodEnter(room);

            room = _ctx.Rooms.ReadOnlyQuery().Where(x => x.RoomId == room.RoomId).FirstOrDefault();

            room.RoomStatus = "Clean";

            room = _ctx.Rooms.Modify(room);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(room) as Room;
        }



        /// <summary>
        /// Deletes a Room instance from the data store
        /// </summary>
        /// <param name="room">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Room room)
        {
            Logger.TraceMethodEnter(room);

            _ctx.Rooms.Remove(room);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        ///// <summary>
        ///// Activity query method that returns an IEnumerable&lt;Reservation&gt; instance. 
        ///// </summary>
        ///// <param name="dates">The instance to delete</param>
        ///// <returns>A strongly type IEnumerable instance </returns>
        //[ActivityMethod("AvailableRooms", MethodType.Invoke, IsDefault = true)]
        //[SecureResource("reservation.administration", SecureResourcePermissionLevel.Read)]
        //public List<Room> AvailableRoomIds(DateEntity dates)
        //{
        //    Logger.TraceMethodEnter(dates);

        //    DateEntityProxy dateProxy = new DateEntityProxy();
        //    dateProxy.CheckInDate = dates.CheckInDate;
        //    dateProxy.CheckOutDate = dates.CheckOutDate;

        //    var unavailabeRooms = ReservationHelper.GetUnAvailableRooms(dateProxy);

        //    var result = new ReservationResult();

        //    List<long> roomids = new List<long>();

        //    foreach (var item in unavailabeRooms.Items)
        //    {

        //        var reservation = new Reservation()
        //        {
        //            RoomId = item.RoomId
        //        };

        //        result.Items.Add(reservation);
        //        roomids.Add(reservation.RoomId);
        //    }

        //    List<Room> rooms = Query().ToList();

        //    List<Room> availableRooms = new List<Room>();

        //    foreach (var item in rooms)
        //    {
        //        if (!roomids.Contains(item.RoomId))
        //        {
        //            availableRooms.Add(item);
        //        }
        //    }

        //        return availableRooms ;

        //}


        

        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Room&gt; instance. 
        /// </summary>
        /// <param name="reservationId">The instance to delete</param>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("AvailableRooms", MethodType.Query, IsDefault = true)]
        [SecureResource("reservation.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room> AvailableRooms(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var result = ReservationHelper.GetReservationDetails(reservationId);
            
            DateEntityProxy dateProxy = new DateEntityProxy();
            dateProxy.CheckInDate = result.CheckInDate;
            dateProxy.CheckOutDate = result.CheckOutDate;
     

            var unavailabeRooms = ReservationHelper.GetUnAvailableRooms(dateProxy);

            var reservationResult = new ReservationResult();

            ArrayList roomNumbersList = new ArrayList();

            foreach (var item in unavailabeRooms.Items)
            {

                Reservation reservation = new Reservation()
                {
                    RoomNumber = item.RoomNumber
                };

                reservationResult.Items.Add(reservation);

                if (reservation.RoomNumber != null || (reservation.Status != "Cancel" || reservation.Status != "CheckedOut"))
                {
                    roomNumbersList.Add(reservation.RoomNumber);
                }
                
            }

            

            List<Room> rooms = Query().ToList();

            var availableRooms = new List<Room>();

            foreach (var item in rooms)
            {
                if (!roomNumbersList.Contains(item.RoomNumber) && item.RoomType.RoomTypeName == result.RoomTypeName)
                {
                    availableRooms.Add(item);
                }
            }

          
            return Logger.TraceMethodExit(availableRooms) as IEnumerable<Room>;


        }



        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A single Room instance, or null if the instance doesn't exist</returns>
        protected Room GetFromDatastore(long roomId)
        {
            return _ctx.Rooms.ReadOnlyQuery().Where(p => p.RoomId == roomId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this RoomActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
