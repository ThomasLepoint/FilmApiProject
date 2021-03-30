CREATE PROCEDURE [dbo].[SP_GetMovieComment]
	@IdMovie uniqueidentifier
AS
begin
select c.[Id], c.[Title], c.[Content], c.[Value], c.[Created_at], c.[MovieId], m.[Title] as 'MovieTitle', c.[UserId], u.[Login] from [Comments] c join [Movies] m on c.MovieId = m.Id join [Users] u on c.UserId = u.Id where c.MovieId = @IdMovie and  [Disable_at] is null;
end
