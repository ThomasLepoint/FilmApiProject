CREATE VIEW [dbo].[V_Comments_Users]
	AS SELECT c.[Id], c.[Title], c.[Content], c.[Value], c.[Created_at], c.[Updated_at], c.[UserId], u.[Login], c.[MovieId] FROM [Comments] as c join [Users] as u on c.UserId = u.Id join [Movies] as m on c.[MovieId] = m.[Id] where c.Disable_at is null;
