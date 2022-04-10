CREATE TABLE [dbo].[Tag]
(
	[Id] integer identity primary key,
    [Name] nvarchar(30) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)

