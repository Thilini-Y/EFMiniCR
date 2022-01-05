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

/* Replace with component specific create script */


create table [dbo].[Prices_Prices] (
    [PriceId] [bigint] not null identity,
    [Code] [nvarchar](255) not null,
	[Description] [nvarchar](1024) not null,
	[ChargingPrice] [decimal](28, 5) not null,
	[PropertyContextId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([PriceId])
);

#SetVersion([Cenium.Prices.Data.PricesEntitiesDbContext], [Prices], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
