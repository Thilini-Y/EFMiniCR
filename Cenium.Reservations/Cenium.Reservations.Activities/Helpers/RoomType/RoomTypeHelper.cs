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
using Cenium.Reservations.Activities.Helpers.RoomType;
using System;

namespace Cenium.Reservations.Activities.Helpers.Room
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomTypeHelper
    {
        private static IActivityFactory _roomActivityFactory = ComponentManager.IsComponentInstalled("Rooms") ? ActivityManager.GetActivityFactory("Rooms") : null;
        private static IEntityFactory _roomEntityFactory = ComponentManager.IsComponentInstalled("Rooms") ? EntityManager.GetEntityFactory("Rooms") : null;

        private static bool _isRoomAvailable = ((_roomEntityFactory == null) || (_roomActivityFactory == null)) ? false : _roomActivityFactory.IsActivityAvailable("RoomType");


        public static RoomTypeProxy GetRoomTypeDetailsByRoomTypeName(string GetByRoomTypeName)
        {
            if (!_isRoomAvailable)
                return null;

            var activity = _roomActivityFactory.Create("RoomType");
            var result = ((activity == null) || (!activity.IsMethodAvailable("GetByRoomTypeName"))) ? null : activity.Get("GetByRoomTypeName", GetByRoomTypeName);

            var proxy = (result == null) ? null : new RoomTypeProxy(result);
            return proxy == null ? null : proxy;
        }


        public static IEntityProxy CreateRoomTypeProxy()
        {
            return _isRoomAvailable ? _roomEntityFactory.Create("RoomType") : null;
        }

    }

}
