CREATE PROCEDURE [dbo].[SP_UpdateStaff]
	@Id uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2
AS
BEGIN
	-- Ajout de l'utilisateur dans la DB avec le mot de passe hashé
	update [dbo].[Staff] set [FirstName] = @FirstName, [LastName] = @LastName,[BirthDate] = @BirthDate where [Id] = @Id;
END