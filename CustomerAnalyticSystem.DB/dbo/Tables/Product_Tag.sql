CREATE TABLE [dbo].[Product_Tag]
(
	[Id] integer identity primary key,
    [ProductId] integer NOT NULL,
    [TagId] integer
    Foreign key (ProductId) references [Product] (Id) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key (TagId) references [Tag] (Id)
)
