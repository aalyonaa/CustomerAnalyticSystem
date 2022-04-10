CREATE TABLE [dbo].[Group]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Name] nvarchar (30) NOT NULL,
	[Description] nvarchar (255), 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
