CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),    
)
