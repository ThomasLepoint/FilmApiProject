CREATE PROCEDURE [dbo].[SP_LoginUser]
	@Login NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	-- Recuperation du salt lier a l'email
	DECLARE @Salt NVARCHAR(100);
	SELECT @Salt = [Salt] FROM [dbo].[Users] WHERE [Login] LIKE @Login;

	-- On continue sur on a trouvé un salt
	IF @Salt IS NOT NULL
	BEGIN
		-- Recuperation de la valeur secrete
		DECLARE @Secret NVARCHAR(50);
		SET @Secret = '&N*%zh/2ZM?!3n#J.wWH9%3UpDvDq%v$R!;84ew+q+%vr)FPbH';

		-- On hash le mot de passe recu pour pouvoir réaliser la comparaison
		DECLARE @Password_Hash VARBINARY(64);
		SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Secret, @Salt));

		-- On souhaite obtenir l'id de l'utilisateur sur base de l'email et du password hashé
		DECLARE @UserId UNIQUEIDENTIFIER;
		SELECT @UserId = [Id] FROM [Users] WHERE [Login] LIKE @Login AND [Password] = @Password_Hash;
		SELECT * FROM [Users] WHERE [Id] = @UserId;
	END
END