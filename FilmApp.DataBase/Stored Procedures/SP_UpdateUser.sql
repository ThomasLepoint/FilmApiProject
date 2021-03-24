CREATE PROCEDURE [dbo].[SP_UpdateUser]
	@Id uniqueidentifier,
	@Email NVARCHAR(255),
	@Password NVARCHAR(50),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2,
	@IsAdmin BIT
AS
BEGIN
	SET NOCOUNT ON;

	-- Generation du Salt
	DECLARE @Salt NVARCHAR(100);
	SELECT @Salt = [Salt] FROM [dbo].[Users] WHERE [Id] LIKE @Id;

	-- On continue sur on a trouvé un salt
	IF @Salt IS NOT NULL
	BEGIN
		-- Recuperation de la valeur secrete
		DECLARE @Secret NVARCHAR(50);
		SET @Secret = '&N*%zh/2ZM?!3n#J.wWH9%3UpDvDq%v$R!;84ew+q+%vr)FPbH';

		-- On hash le mot de passe recu pour pouvoir réaliser la comparaison
		DECLARE @Password_Hash VARBINARY(64);
		SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Secret, @Salt));

	-- Ajout de l'utilisateur dans la DB avec le mot de passe hashé
	update [dbo].[Users] set [Email] = @Email, [Password] = @Password_Hash, [FirstName] = @FirstName, [LastName] = @LastName, [BirthDate] = @BirthDate, [IsAdmin] = @IsAdmin where [Id] = @Id
	END
END
