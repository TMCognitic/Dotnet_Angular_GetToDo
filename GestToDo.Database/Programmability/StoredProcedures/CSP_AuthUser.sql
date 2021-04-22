CREATE PROCEDURE [dbo].[CSP_AuthUser]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
Begin
	SELECT [Id], [LastName], [FirstName], [Email] FROM [User] Where [Email] = @Email And [Passwd] = HASHBYTES('SHA2_512', [dbo].[CSF_GetPreSalt]() + @Passwd + [dbo].[CSF_GetPostSalt]());
	RETURN 0
End
