CREATE PROCEDURE [dbo].[SP_UpdateMovie]
	@Id uniqueidentifier,
	@Title nvarchar(50),
	@Synopsis nvarchar(255),
	@ReleaseDate datetime2,
	@ScriptWriterId uniqueIdentifier,
	@DirectorId uniqueidentifier
AS
begin
	update [Movies] set [Title] = @Title, [Synopsis] = @Synopsis, [ReleaseDate] = @ReleaseDate, [ScriptWriterId] = @ScriptWriterId, [DirectorId] = @DirectorId where [Id] = @Id ;
end