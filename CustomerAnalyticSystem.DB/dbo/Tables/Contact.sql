CREATE TABLE [dbo].[Contact]
(
	[Id] integer identity primary key,
    [CustomerId] integer NOT NULL,
    [ContactTypeId] integer NOT NULL,
    Foreign key (CustomerId) references [Customer] (Id),
    Foreign key (ContactTypeId) references [ContactType] (Id),
    [Value] nvarchar(50) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
