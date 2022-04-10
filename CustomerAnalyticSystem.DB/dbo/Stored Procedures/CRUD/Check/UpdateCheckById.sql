CREATE PROCEDURE [dbo].[UpdateCheckById]
	@Id integer,
	@ProductId integer,
	@OrderId integer,
	@Amount integer,
	@Mark integer
as
	update [dbo].[Check]
	set Amount=@Amount,
	ProductId = @ProductId,
	OrderId = @OrderId,
	Mark=@Mark
	where Id=@Id
return @Id
