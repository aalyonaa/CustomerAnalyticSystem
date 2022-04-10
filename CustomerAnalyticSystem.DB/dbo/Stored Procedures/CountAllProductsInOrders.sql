CREATE PROCEDURE [dbo].[CountAllProductsInOrders]
AS
	select C.ProductId,P.[Name],P.[Description], COUNT (O.Id) as 'Number' from [dbo].[Order] as O
	join [dbo].[Check] as C
	on O.Id = C.Id
	join [dbo].[Product] as P
	on P.Id = C.Id
	group by C.ProductId, P.[Name], P.[Description]
RETURN 0
