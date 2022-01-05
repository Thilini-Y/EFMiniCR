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

  #Version([0.0.0.1])

 create table [dbo].[Contacts_Contacts] (
    [ContactId] [bigint] not null identity,
    [Name] [nvarchar](255) not null,
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

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.2])

 #AddColumn([Contacts_Contacts], [DOB], [datetime] not null default (0000/00/00))
 #AddColumn([Contacts_Contacts], [IdNumber], [nvarchar(255) not null default('null')])
 #AddColumn([Contacts_Contacts], [Address], [nvarchar(1024) not null default('null')])
 #AddColumn([Contacts_Contacts], [IsActive], [bit not null default(0)])


#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.3])

 #AddColumn([Contacts_Contacts], [ProfileImage], [uniqueidentifier null])


#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.4])

 #AddColumn([Contacts_Contacts], [ContactNumber], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [FirstName], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [MiddleName], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [LastName], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [City], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [Province], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [Country], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [ZipCode], [nvarchar(255) null])
 #AddColumn([Contacts_Contacts], [Gender], [nvarchar(255) null])

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])
