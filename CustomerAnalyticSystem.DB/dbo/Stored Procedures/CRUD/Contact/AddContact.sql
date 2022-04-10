CREATE PROCEDURE [dbo].[AddContact]
	@CustomerId integer,
	@ContactTypeId integer,
	@Value nvarchar(255)
as
	insert [dbo].[Contact] 
	values (@CustomerId , @ContactTypeId , @Value, 0)
return 0