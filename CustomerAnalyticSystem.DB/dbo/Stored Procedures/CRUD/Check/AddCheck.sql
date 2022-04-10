CREATE PROCEDURE [dbo].[AddCheck]
	@ProductId integer,
	@OrderId integer,
	@Amount integer,
	@Mark integer
as 
	insert into [dbo].[Check] 
	values
	(@ProductId, @OrderId, @Amount, @Mark, 0)