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
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Rooms")]
[assembly: ComponentDescription("Rooms", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]

[assembly: SecureResourceType("rooms.administration", "Room Administration", "Full administration of Rooms")]

[assembly: SecureResourceType("roomtypes.administration", "RoomTypes Administration", "Full administration of RoomTypes")]

[assembly: SecureResourceType("feature.administration", "Features Administration", "Full administration of Features")]