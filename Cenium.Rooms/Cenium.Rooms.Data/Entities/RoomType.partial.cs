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
 * Thilini.Y   12/13/2021    Created
 */


using Cenium.Framework.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenium.Rooms.Data
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [EntityInfo(ValueListProperties = "RoomTypeName,RoomTypeDescription,Capacity", PrimaryDisplayProperty = "RoomTypeName")]
    public partial class RoomType
    {

        [NotMapped]
        [EntityMember(Order = 101)]
        public string PriceCode { get; set; }


    }

}
