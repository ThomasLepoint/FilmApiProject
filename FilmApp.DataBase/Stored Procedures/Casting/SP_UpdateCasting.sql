CREATE PROCEDURE [dbo].[SP_UpdateCasting]
	@StaffId uniqueidentifier,
	@MovieId uniqueidentifier,
	@Character nvarchar(50)
AS
begin
	update [Casting] set [Character] = @Character where [MovieId] = @MovieId and [StaffId] = @StaffId;
end