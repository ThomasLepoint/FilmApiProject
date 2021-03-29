CREATE VIEW [dbo].[V_Comments]
	AS SELECT c.[Id], c.[Title], c.[Content], c.[Value], c.[MovieId],m.[Title] as 'MovieTile', c.[UserId], u.[Login], c.[Created_at], c.[Updated_at] FROM [Comments] c join [Movies] m on c.[MovieId] = m.[Id] join [Users] u on c.[UserId] = u.[Id] where c.[Disable_at] is null;
