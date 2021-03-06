CREATE PROCEDURE [dbo].[SP_AddCasting]
	@StaffId uniqueidentifier,
	@MovieId uniqueidentifier,
	@Character nvarchar(50)
AS
	begin
	insert into [Casting] ([MovieId], [StaffId], [Character]) output inserted.Id values (@MovieId, @StaffId, @Character)
	end
