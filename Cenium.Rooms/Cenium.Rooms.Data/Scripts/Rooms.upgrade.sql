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

#Version([0.0.0.1])

create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNumber] [bigint] not null,
	[RoomStatus] [nvarchar](255) not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomId])
);


create table [dbo].[Rooms_RoomTypes] (
    [RoomTypeId] [bigint] not null identity,
    [RoomTypeName] [nvarchar](max) not null,
    [RoomTypeDescription] [nvarchar](max) null,
    [Capacity] [int] null,
	[PropertyId] [bigint] not null,
	[PriceId] [bigint] not null,
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
	[PriceId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureId])
);


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.2])

alter table [dbo].[Rooms_Rooms] add [RoomTypeId] [bigint] not null;
alter table [dbo].[Rooms_Rooms] add constraint [fk_roomtype_id] foreign key ([RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.3])

create table [dbo].[RoomTypeFeature] (
    [Feature_FeatureId] [bigint] not null,
    [RoomType_RoomTypeId] [bigint] not null,
    primary key ([Feature_FeatureId], [RoomType_RoomTypeId])
);
alter table [dbo].[RoomTypeFeatures] add constraint [RTF_Source] foreign key ([Feature_FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;
alter table [dbo].[RoomTypeFeatures] add constraint [RTF_Target] foreign key ([RoomType_RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.4])



#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.5])


#AddColumn([Rooms_RoomTypes], [Code], [nvarchar(255) null])


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.5], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.6])



#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.6], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.7])

#AddColumn([Rooms_Rooms], [PropertyContextId], [bigint not null])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.7], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])




#Version([0.0.0.8])

/***create table [dbo].[Rooms_FeatureRoomTypes] (
	[FeatureRoomTypeId] [bigint] not null identity,
	[RoomTypeId] [bigint] not null,
    [FeatureId] [bigint] not null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureRoomTypeId])
);
alter table [dbo].[Rooms_FeatureRoomTypes] add constraint [Feature_RoomTypes_S] foreign key ([Feature_FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;
alter table [dbo].[Rooms_FeatureRoomTypes] add constraint [Feature_RoomTypes_T] foreign key ([RoomType_RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;
***/

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.8], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.9])

alter table [dbo].[Rooms_Rooms] alter column [RoomNumber] [nvarchar](255) not null

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.9], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.10])

#AddColumn([Rooms_Rooms], [ColorCode], [nvarchar(255) null])
#AddColumn([Rooms_Rooms], [Width], [float null])
#AddColumn([Rooms_Rooms], [Width], [float null])
#AddColumn([Rooms_Rooms], [Length], [float null])
#AddColumn([Rooms_Rooms], [CeilingHeight], [float null])
#AddColumn([Rooms_Rooms], [Area], [float null])


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.10], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.11])

#AddColumn([Rooms_Rooms], [RoomDescription], [nvarchar(1024) null])


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.11], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.12])

alter table [dbo].[Rooms_Rooms] drop column RoomDescription;
#AddColumn([Rooms_Rooms], [AdditionalDetails], [nvarchar(1024) null])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.12], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.13])

alter table [dbo].[Rooms_Rooms] drop column AdditonalDetails;
#AddColumn([Rooms_Rooms], [AdditionalDetails], [nvarchar(1024) null])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.13], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
