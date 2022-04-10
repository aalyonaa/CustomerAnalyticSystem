CREATE PROCEDURE [dbo].[GetOrderById]
	@Id integer
AS
	select O.Id, O.CustomerId, O.Date, O.StatusId, O.Cost from dbo.[Order] as O
	where Id = @Id and IsDeleted = 0
RETURN @Id
