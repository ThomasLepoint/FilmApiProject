CREATE PROCEDURE [dbo].[SP_AddStaff]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2
AS
BEGIN
	-- Ajout de l'utilisateur dans la DB avec le mot de passe hashé
	INSERT INTO [dbo].[Staff] ([FirstName], [LastName],[BirthDate])
	 OUTPUT [inserted].[Id]
	 VALUES (@FirstName, @LastName, @BirthDate);
END
