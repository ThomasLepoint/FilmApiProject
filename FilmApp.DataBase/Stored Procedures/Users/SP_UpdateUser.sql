CREATE PROCEDURE [dbo].[SP_UpdateUser]
	@Id uniqueidentifier,
	@Email NVARCHAR(255),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2
AS
BEGIN
	SET NOCOUNT ON;

	-- Generation du Salt
	DECLARE @Salt NVARCHAR(100);
	SELECT @Salt = [Salt] FROM [dbo].[Users] WHERE [Id] LIKE @Id;

	-- On continue sur on a trouvé un salt
	IF @Salt IS NOT NULL
	BEGIN
	-- Ajout de l'utilisateur dans la DB avec le mot de passe hashé
	update [dbo].[Users] set [Email] = @Email, [FirstName] = @FirstName, [LastName] = @LastName, [BirthDate] = @BirthDate where [Id] = @Id
	END
END
