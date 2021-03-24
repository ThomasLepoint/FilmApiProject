CREATE PROCEDURE [dbo].[SP_AddComment]
	@Title nvarchar(50),
	@Content nvarchar(250),
	@Value int,
	@MovieId uniqueidentifier,
	@UserId uniqueidentifier
AS
begin
	insert into [Comments] ( [Title], [Content], [Value], [UserId], [MovieId], [Created_at]) values (@Title, @Content,@Value, @MovieId,@UserId, GETDATE() )
end
