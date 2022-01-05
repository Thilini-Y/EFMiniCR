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
    [Table("Rooms_Rooms")]
    public partial class Room
    {


        #region Variables

        private long _roomId;
        private string _roomNumber;
        private string _roomStatus;
        private long _propertyContextId;
        private string _colorCode;
        private Nullable<double> _width;
        private Nullable<double> _length;
        private Nullable<double> _ceilingHeight;
        private Nullable<double> _area;
        private string _additionalDetails;
        private long _roomTypeId;
        private RoomType _roomType;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomStatus
        {
            get { return _roomStatus; }
            set { _roomStatus = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long PropertyContextId
        {
            get { return _propertyContextId; }
            set { _propertyContextId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> Width
        {
            get { return _width; }
            set { _width = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> Length
        {
            get { return _length; }
            set { _length = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> CeilingHeight
        {
            get { return _ceilingHeight; }
            set { _ceilingHeight = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<double> Area
        {
            get { return _area; }
            set { _area = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string AdditionalDetails
        {
            get { return _additionalDetails; }
            set { _additionalDetails = value; }
        }


        #endregion


        #region Navigation Properties

        /// <summary>
        /// Foreign key property for RoomType
        /// </summary>
        [Required]
        [ForeignKey("RoomType")]
        [EntityMember(IsReadOnly = false, Order = 10, Reference = "RoomType", IsQueryable = false, IsSortable = false)]
        public virtual long RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 11)]
        public virtual RoomType RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 12, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 13, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
