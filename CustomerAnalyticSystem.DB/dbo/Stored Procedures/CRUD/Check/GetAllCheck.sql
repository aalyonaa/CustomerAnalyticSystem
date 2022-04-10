CREATE PROCEDURE [dbo].[GetAllCheck]
	as
	select C.Id, C.ProductId, C.OrderId, C.Amount, C.Mark
	from [dbo].[Check] as C
	where IsDeleted = 0
