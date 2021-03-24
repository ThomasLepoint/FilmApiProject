CREATE TABLE [dbo].[Casting]
(
	[Id] UNIQUEIDENTIFIER NOT NULL default NEWSEQUENTIALID(), 
    [StaffId] UNIQUEIDENTIFIER NOT NULL, 
    [MovieId] UNIQUEIDENTIFIER NOT NULL, 
    [Character] NVARCHAR(50) NULL,

    constraint PK_Casting_Id primary key([Id]),
    constraint FK_Casting_Staff foreign key ([StaffId]) references [Staff] ([Id]),
    constraint FK_Casting_Movie foreign key ([MovieId]) references [Movies] ([Id])


)
