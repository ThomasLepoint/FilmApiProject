CREATE TABLE [dbo].[Movies]
(
	[Id] UNIQUEIDENTIFIER NOT NULL default NEWSEQUENTIALID(), 
    [Title] NVARCHAR(50) NOT NULL, 
    [Synopsis] NVARCHAR(255) NULL, 
    [ReleaseDate] DATETIME2 NULL, 
    [ScriptWriterId] UNIQUEIDENTIFIER NOT NULL, 
    [DirectorId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT PK_Movies PRIMARY KEY([Id]),
    CONSTRAINT FK_Movie_ScriptWriter Foreign key ([ScriptWriterId]) References [Staff]([Id]),
    CONSTRAINT FK_Movie_Director foreign key ([DirectorId]) References [Staff]([Id])

)
