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

/* Replace with component specific create script */

create table [dbo].[Reservations_Reservations] (
    [ReservationId] [bigint] not null identity,
	[PropertyContextId] [bigint] not null ,
	[ReservationNumber] [nvarchar](255) null,
	[CheckInDate] [date] not null,
	[CheckOutDate] [datetime] not null,
	[Status] [nvarchar](255) null,
	[RoomId] [bigint] not null,
	[ContactId] [bigint] not null,
	[Name] [nvarchar](255) null,
	[RoomTypeName] [nvarchar](255) null,
	[RoomNumber] [nvarchar](255) null,
	[Price] [decimal](28, 5) null,
	[PaymentStatus] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ReservationId])
);


#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [0.0.0.9], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
