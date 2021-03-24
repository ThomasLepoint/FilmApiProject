CREATE PROCEDURE [dbo].[SP_DisableUser]
	@Id uniqueidentifier,
	@Reason nvarchar(250)
AS
begin
	Update [Users] set [Disable_at] = GETDATE(), [Reason] = @Reason where [Id] = @Id;
end

