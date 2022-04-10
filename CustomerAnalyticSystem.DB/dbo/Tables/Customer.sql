CREATE TABLE [dbo].[Customer]
(
	[Id] integer identity primary key,
	[FirstName] nvarchar (50) NOT NULL,
	[LastName] nvarchar(50) NULL,
	[TypeId] integer NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key (TypeId) references [CustomerType] (Id)
)
