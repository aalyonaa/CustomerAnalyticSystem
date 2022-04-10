CREATE TABLE [dbo].[ContactType]
(
	[Id] integer identity primary key,
    [Name] nvarchar (30) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
