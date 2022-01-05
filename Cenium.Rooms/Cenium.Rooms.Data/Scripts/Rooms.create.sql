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
 */D:\ceniumMiniproject\Cenium.Rooms\Cenium.Rooms.Data\Scripts\Rooms.create.sql

/* Replace with component specific create script */

create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNumber] [nvarchar](255) not null,
	[RoomStatus] [nvarchar](255) not null,
	[RoomTypeId] [bigint] not null,
	[PropertyContextId] [bigint] null,
	[ColorCode] [nvarchar](255) null,
	[Width] [float] null,
	[Length] [float] null,
	[CeilingHeight] [float] null,
	[Area] [float] null,
	[AdditionalDetails] [nvarchar](1024) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomId])
);

alter table [dbo].[Rooms_Rooms] add constraint [Room_RoomType] foreign key ([RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;


create table [dbo].[Rooms_RoomTypes] (
    [RoomTypeId] [bigint] not null identity,
    [RoomTypeName] [nvarchar](max) not null,
    [RoomTypeDescription] [nvarchar](max) null,
    [Capacity] [int] null,
	[Code] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomTypeId])
);

create table [dbo].[Rooms_Features] (
    [FeatureId] [bigint] not null identity,
    [FeatureName] [nvarchar](max) not null,
	[Description] [nvarchar](max) null,
    [Category] [nvarchar](max) not null,
    [Amount] [int] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureId])
);


create table [dbo].[Rooms_FeatureRoomTypes] (
	[FeatureRoomTypeId] [bigint] not null identity,
	[RoomTypeId] [bigint] not null,
    [FeatureId] [bigint] not null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureRoomTypeId])
);
alter table [dbo].[Rooms_FeatureRoomTypes] add constraint [Feature_RoomTypes_S] foreign key ([Feature_FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;
alter table [dbo].[Rooms_FeatureRoomTypes] add constraint [Feature_RoomTypes_T] foreign key ([RoomType_RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.13], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

