CREATE VIEW [dbo].[V_Comments]
	AS SELECT [Id], [Title], [Content], [Value], [MovieId], [UserId], [Created_at], [Updated_at] FROM [Comments] where [Disable_at] is null;
