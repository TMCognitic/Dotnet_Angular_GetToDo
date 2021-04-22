CREATE TABLE [dbo].[ToDo]
(
	[Id] INT NOT NULL IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[Ended] BIT NOT NULL
		CONSTRAINT DF_ToDo_Ended Default (0),
	[CreatedDate] DATETIME2 NOT NULL
		CONSTRAINT DF_ToDo_CreatedDate DEFAULT (SysDateTime()),
	[UserId] INT NOT NULL, 
    CONSTRAINT [PK_ToDo] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ToDo_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)

GO

CREATE INDEX [IX_ToDo_UserId] ON [dbo].[ToDo] ([UserId])
