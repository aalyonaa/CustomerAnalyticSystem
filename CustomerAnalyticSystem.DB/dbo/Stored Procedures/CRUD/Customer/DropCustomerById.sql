CREATE PROCEDURE [dbo].[DropCustomerById]
	@Id integer
AS
update [dbo].[Customer] 
set IsDeleted = 1
	where Id = @Id
update [dbo].[Contact]
set IsDeleted = 1
	where CustomerId = @Id
update [dbo].[Comment]
set IsDeleted = 1
	where CustomerId = @Id
return @Id