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

namespace Cenium.Reservations.Activities.Helpers.Room
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomHelper
    {
        private static IActivityFactory _roomActivityFactory = ComponentManager.IsComponentInstalled("Rooms") ? ActivityManager.GetActivityFactory("Rooms") : null;
        private static IEntityFactory _roomEntityFactory = ComponentManager.IsComponentInstalled("Rooms") ? EntityManager.GetEntityFactory("Rooms") : null;

        private static bool _isRoomAvailable = ((_roomEntityFactory == null) || (_roomActivityFactory == null)) ? false : _roomActivityFactory.IsActivityAvailable("Room");


        public static void ChangeRoomStatus(RoomProxy roomProxy)
        {
            if (!_isRoomAvailable)
                 return;

            var activity = _roomActivityFactory.Create("Room");
            var result = ((activity == null) || (!activity.IsMethodAvailable("ChangeStatus"))) ? null : activity.Invoke("ChangeStatus", roomProxy.EntityProxy);

        }

        public static RoomProxy GetRoomDetailsByRoomumber(string roomNumber)
        {
            if (!_isRoomAvailable)
                return null;

            var activity = _roomActivityFactory.Create("Room");
            var result = ((activity == null) || (!activity.IsMethodAvailable("GetByRoomNumber"))) ? null : activity.Get("GetByRoomNumber", roomNumber);

            var proxy = (result == null) ? null : new RoomProxy(result);
            return proxy == null ? null : proxy;
        }


        public static IEntityProxy CreateRoomProxy()
        {
            return _isRoomAvailable ? _roomEntityFactory.Create("Room") : null;
        }

    }

}
