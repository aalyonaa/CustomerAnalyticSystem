CREATE PROCEDURE [dbo].[AddOrder]
	@CustomerId integer, 
	@Date nvarchar(10), 
	@StatusId integer,
	@Cost integer
AS
	insert dbo.[Order]
	values (@CustomerId, @Date, @StatusId, @Cost, 0)

