CREATE TABLE [dbo].[Grade]
(
	[Id] integer identity primary key,
	[ProductId] integer NOT NULL,
	[CustomerId] integer NOT NULL,
	[Value] integer NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key (ProductId) references [Product] (ID),
	Foreign key (CustomerId) references [Customer] (ID)
)
