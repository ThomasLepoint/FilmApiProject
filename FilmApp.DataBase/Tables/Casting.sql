CREATE TABLE [dbo].[Casting]
(
	[Id] UNIQUEIDENTIFIER NOT NULL default NEWSEQUENTIALID(), 
    [StaffId] UNIQUEIDENTIFIER NOT NULL, 
    [MovieId] UNIQUEIDENTIFIER NOT NULL, 
    [Character] NVARCHAR(50) NULL,

    CONSTRAINT PK_Casting_Id PRIMARY KEY([Id]),
    CONSTRAINT FK_Casting_Staff foreign key ([StaffId]) references [Staff]([Id]),
    CONSTRAINT FK_Casting_Movie foreign key ([MovieId]) references [Movies]([Id])


)
