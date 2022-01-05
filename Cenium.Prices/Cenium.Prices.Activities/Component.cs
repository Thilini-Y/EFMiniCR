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
 * Thilini.Y   11/16/2021    Created
 */

using System;
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Prices")]
[assembly: ComponentDescription("Prices", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]

[assembly: SecureResourceType("RoomPrices.administration", "RoomPrices Administration", "Full administration of RoomPrices")]

