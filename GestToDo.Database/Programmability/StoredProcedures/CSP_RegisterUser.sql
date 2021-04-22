CREATE PROCEDURE [dbo].[CSP_RegisterUser]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	INSERT INTO [User] ([LastName], [FirstName], [Email], [Passwd]) VALUES (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', [dbo].[CSF_GetPreSalt]() + @Passwd + [dbo].[CSF_GetPostSalt]()));
	RETURN 0
END
