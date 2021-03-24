﻿CREATE TABLE [dbo].[Staff]
(
	[Id] UNIQUEIDENTIFIER NOT NULL default NEWSEQUENTIALID(), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NULL,

    CONSTRAINT PK_StaffId Primary key ([Id])
)
