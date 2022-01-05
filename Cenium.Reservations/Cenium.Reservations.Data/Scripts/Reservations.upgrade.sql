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
 * Thilini.Y   11/15/2021    Created
 */

#Version([0.0.0.2])

create table [dbo].[Reservations_Reservations] (
    [ReservationId] [bigint] not null identity,
	[PropertyContextId] [bigint] not null,
	[ReservationNumber] [bigint] not null,
	[CheckInDate] [datetime] not null,
	[CheckOutDate] [datetime] not null,
	[Status] [nvarchar](255) not null,
	[RoomId] [bigint] not null,
	[ContactId] [bigint] not null,
	[Name] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ReservationId])
);

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.3])

#AddColumn([Reservations_Reservations], [RoomTypeName], [nvarchar(255) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.4])

#AddColumn([Reservations_Reservations], [RoomNumber], [nvarchar(255) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.5])

alter table [dbo].[Reservations_Reservations] alter column [ReservationNumber] [nvarchar](255) null

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.5], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.6])

alter table [dbo].[Reservations_Reservations] alter column [Status] [nvarchar](255) null

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.6], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.7])

#AddColumn([Reservations_Reservations], [Price], [decimal(28, 5) null])
#AddColumn([Reservations_Reservations], [PaymentStatus], [nvarchar](255) null)

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.7], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.8])

alter table [dbo].[Reservations_Reservations] alter column [CheckInDate] [date] not null

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.8], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.9])

alter table [dbo].[Reservations_Reservations] alter column [PaymentStatus] [nvarchar](255) null


#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.9], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
