CREATE PROCEDURE [dbo].[GetAllOrders]
AS
	select O.Id, O.CustomerId, O.Date, O.StatusId, O.Cost from dbo.[Order] as O
	where IsDeleted = 0
return 0
