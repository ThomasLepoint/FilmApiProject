CREATE VIEW [dbo].[V_Users]
	AS SELECT [Id], [Login], [Email], [FirstName], [LastName], [BirthDate], [IsAdmin] FROM [Users] where [Disable_at] is null;
