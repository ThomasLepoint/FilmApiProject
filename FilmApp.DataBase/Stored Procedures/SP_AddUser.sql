CREATE PROCEDURE [dbo].[AddUser]
	@Login NVARCHAR(50),
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
	SET @Salt = CONCAT(NEWID(),NEWID(),NEWID());

	-- Recuperation de la valeur secrete
	DECLARE @Secret NVARCHAR(50);
	SET @Secret = '&N*%zh/2ZM?!3n#J.wWH9%3UpDvDq%v$R!;84ew+q+%vr)FPbH';

	-- Hashage du mot de passe avec le salt
	DECLARE @Password_hash VARBINARY(64);
	SET @Password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Secret, @Salt));

	-- Ajout de l'utilisateur dans la DB avec le mot de passe hashé
	INSERT INTO [dbo].[Users] ([Login], [Email], [Password],[FirstName], [LastName],[BirthDate], [Salt], [IsAdmin])
	 OUTPUT [inserted].[Id]
	 VALUES (@Login, @Email, @Password_hash, @FirstName, @LastName, @BirthDate, @Salt, @IsAdmin);
END