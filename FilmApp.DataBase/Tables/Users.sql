CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL default NEWSEQUENTIALID(), 
    [Login] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(255) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [BirthDate] DATE NULL, 
    [IsAdmin] BIT NOT NULL DEFAULT 0, 
    [Disable_at] DATETIME2 NULL, 
    [Reason] NVARCHAR(255) NULL,

    [Salt] NVARCHAR(100) NOT NULL, 
    CONSTRAINT PK_UserApp PRIMARY KEY([Id]),
	CONSTRAINT UK_UserApp_Username UNIQUE ([Login])
)
