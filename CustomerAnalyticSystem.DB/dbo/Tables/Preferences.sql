CREATE TABLE [dbo].[Preferences]
(
	Id integer identity primary key,
	[ProductId] integer NULL,
	[CustomerId] integer NOT NULL,
	[TagId] integer NULL,
	[GroupId] integer NULL,
	[IsInterested] bit NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0, 
    Foreign key ([ProductId]) references [Product] (Id),
	Foreign key ([CustomerId]) references [Customer] (Id),
	Foreign key (TagId) references [Tag] (Id),
	Foreign key (GroupId) references [Group] (Id)
)
