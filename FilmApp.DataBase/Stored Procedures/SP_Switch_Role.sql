CREATE PROCEDURE [dbo].[SP_Switch_Role]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	IF((SELECT IsAdmin FROM [dbo].[Users] WHERE Id = @Id) = 1)
	BEGIN
		UPDATE [dbo].[Users] SET IsAdmin = 0 WHERE Id = @Id
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Users] SET IsAdmin = 1 WHERE Id = @Id
	END
END
