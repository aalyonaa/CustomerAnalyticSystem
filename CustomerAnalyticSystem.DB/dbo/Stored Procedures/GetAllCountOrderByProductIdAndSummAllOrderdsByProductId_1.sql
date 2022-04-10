CREATE PROCEDURE [dbo].[GetAllCountOrderByProductIdAndSummAllOrderdsByProductId]
	@Id integer
as
SELECT P.Name, Count(ProductId)AS CountOrder, SUM(Amount)AS SummAllProductsInOrders
FROM [dbo].[Check] as C 
join [dbo].[Product] as P
	on C.ProductId = P.Id
	where P.Id=@Id
GROUP BY ProductId, P.Name
ORDER BY ProductId
return @Id
