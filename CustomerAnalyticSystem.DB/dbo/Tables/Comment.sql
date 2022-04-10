CREATE TABLE [dbo].[Comment]
(
	[Id] integer identity primary key,
	[CustomerId] integer NOT NULL,
	[Text] nvarchar(255) NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key (CustomerId) references [Customer] (Id)
)
