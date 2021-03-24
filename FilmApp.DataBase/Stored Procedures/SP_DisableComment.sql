CREATE PROCEDURE [dbo].[SP_DisableComment]
	@Id uniqueidentifier,
	@Reason nvarchar(250)
AS
begin
	Update [Comments] set [Disable_at] = GETDATE(), [Reason] = @Reason where [Id] = @Id;
end
