CREATE PROCEDURE [dbo].[SP_AddMovie]
	@Title nvarchar(50),
	@Synopsis nvarchar(255),
	@ReleaseDate datetime2,
	@ScriptWriterId uniqueIdentifier,
	@DirectorId uniqueidentifier
AS
begin
	insert into [Movies] ([Title], [Synopsis], [ReleaseDate], [ScriptWriterId], [DirectorId]) values (@Title, @Synopsis, @ReleaseDate, @ScriptWriterId, @DirectorId);
end
