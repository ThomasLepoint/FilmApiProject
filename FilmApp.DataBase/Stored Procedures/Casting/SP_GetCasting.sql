CREATE PROCEDURE [dbo].[SP_GetCasting]
	@IdMovie uniqueidentifier
AS
begin
select c.[Id], c.[MovieId], s.[FirstName], s.[LastName], s.[BirthDate], c.[Character] from [Casting] c join [Staff] s on c.StaffId = s.Id where c.[MovieId] = @IdMovie;
end
