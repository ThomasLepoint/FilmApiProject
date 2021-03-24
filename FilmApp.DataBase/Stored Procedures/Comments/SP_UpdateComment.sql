CREATE PROCEDURE [dbo].[SP_UpdateComment]
	@Id uniqueidentifier,
	@Title nvarchar(50),
	@Content nvarchar(250),
	@Value int
AS
begin
	update [Comments] set [Title] = @Title, [Content] = @Content, [Value] = @Value, [Updated_at] = GETDATE() where [Id] = @Id;
end
