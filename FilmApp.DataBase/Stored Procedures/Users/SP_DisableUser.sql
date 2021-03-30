CREATE PROCEDURE [dbo].[SP_DisableUser]
	@Id uniqueidentifier,
	@Disable_Until date,
	@Reason nvarchar(250)
AS
begin
	Update [Users] set [Disable_Until] = @Disable_Until, [Reason] = @Reason where [Id] = @Id;
end

