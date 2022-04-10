CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Name] nvarchar (50) NOT NULL,
	[Description] nvarchar (255) NULL,
	[GroupId] int NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key ([GroupId]) references [Group]([Id])
)
