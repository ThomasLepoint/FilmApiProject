CREATE TABLE [dbo].[Comments]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(), 
    [Title] NVARCHAR(50) NOT NULL, 
    [Content] NVARCHAR(255) NOT NULL, 
    [Value] INT NULL, 
    [MovieId] UNIQUEIDENTIFIER NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Created_at] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [Updated_at] DATETIME2 NULL, 
    [Disable_at] DATETIME2 NULL, 
    [Reason] NVARCHAR(255) NULL,

    CONSTRAINT PK_Comment_Id primary key ([Id]),
    CONSTRAINT FK_Comment_Movie foreign key ([MovieId]) references [Movies]([Id]),
    CONSTRAINT FK_Comment_User foreign key ([UserId]) references [Users]([Id])
)