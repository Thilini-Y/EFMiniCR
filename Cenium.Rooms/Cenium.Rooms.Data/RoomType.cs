/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * This code was generated from a template. Changes to this file may cause incorrect behavior 
 * and will be lost if the code is regenerated. 
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Cenium.Framework.Data;
using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Context;
using Cenium.Framework.ComponentModel;



namespace Cenium.Rooms.Data
{

    [Entity]
    [Table("Rooms_RoomTypes")]
    public partial class RoomType
    {


        #region Variables

        private long _roomTypeId;
        private string _roomTypeName;
        private string _roomTypeDescription;
        private Nullable<int> _capacity;
        private string _code;
        private ICollection<Room> _rooms;
        private ICollection<FeatureRoomType> _featureRoomTypes;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomTypeName
        {
            get { return _roomTypeName; }
            set { _roomTypeName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomTypeDescription
        {
            get { return _roomTypeDescription; }
            set { _roomTypeDescription = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<int> Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Code
        {
            get { return _code; }
            set { _code = value; }
        }


        #endregion


        #region Navigation Properties

        [EntityMember(IsReadOnly = false, Order = 5)]
        public virtual ICollection<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 6)]
        public virtual ICollection<FeatureRoomType> FeatureRoomTypes
        {
            get { return _featureRoomTypes; }
            set { _featureRoomTypes = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 7, IsQueryable = false, IsSortable = false)]
        public virtual Guid TenantId
        {
            get { return _tenantId; }
            set { _tenantId = value; }
        }

        /// <summary>
        /// Concurrency control version number
        /// </summary>
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [EntityMember(IsReadOnly = true, Order = 8, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
