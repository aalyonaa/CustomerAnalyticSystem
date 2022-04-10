CREATE PROCEDURE [dbo].[AddComment]
	@CustomerId integer,
	@Text nvarchar(255)
as
	insert into [dbo].[Comment] 
	values 
	(@CustomerId, @Text, 0)
