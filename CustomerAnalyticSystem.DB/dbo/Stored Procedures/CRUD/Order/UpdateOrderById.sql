CREATE PROCEDURE [dbo].[UpdateOrderById]
	@Id integer,
	@CustomerId integer,
	@Date nvarchar(10), 
	@StatusId integer,
	@Cost integer
	AS
	update dbo.[Order]
	set CustomerId = @CustomerId,
	Date = @Date,
	StatusId = @StatusId,
	Cost = @Cost
	where Id= @Id

	
RETURN @Id
