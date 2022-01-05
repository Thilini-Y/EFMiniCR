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

create table [dbo].[Contacts_Contacts] (
    [ContactId] [bigint] not null identity,
    [Name] [nvarchar](255) not null,
	[DOB] [datetime] not null,
	[IdNumber] [nvarchar](255) not null,
	[Address] [nvarchar](1024) not null,
	[IsActive] [bit] not null,
	[ProfileImage] [uniqueidentifier] null,
	[ContactNumber] [nvarchar](255) null,
	[FirstName] [nvarchar](255) null,
	[MiddleName] [nvarchar](255) null,
	[LastName] [nvarchar](255) null,
	[City] [nvarchar](255) null,
	[Province] [nvarchar](255) null,
	[Country] [nvarchar](255) null,
	[ZipCode] [nvarchar](255) null,
	[Gender] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ContactId])
);

create table [dbo].[Contacts_Emails] (
    [EmailId] [bigint] not null identity,
    [EmailAddress] [nvarchar](255) not null,
	[ContactId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([EmailId])

);

alter table [dbo].[Contacts_Emails] add constraint [Email_Contact] foreign key ([ContactId]) references [dbo].[Contacts_Contacts]([ContactId]) on delete cascade;


create table [dbo].[Contacts_PhoneNumbers] (
    [PhoneNumberId] [bigint] not null identity,
    [ContactNumber] [nvarchar](255) not null,
	[ContactId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([PhoneNumberId])

);

alter table [dbo].[Contacts_PhoneNumbers] add constraint [PhoneNumber_Contact] foreign key ([ContactId]) references [dbo].[Contacts_Contacts]([ContactId]) on delete cascade;


#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
