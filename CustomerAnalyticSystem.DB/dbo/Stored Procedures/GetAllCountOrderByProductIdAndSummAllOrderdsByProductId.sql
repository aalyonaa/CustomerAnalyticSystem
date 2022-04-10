CREATE PROCEDURE [dbo].[GetAllCountOrderByProductIdAndSummAllOrderdsByProductId]
	 @Id integer
as
SELECT ProductId, Count(ProductId)AS CountOrder, SUM(Amount)AS SummAllOrder
FROM [dbo].[Check] as C 
join [dbo].[Product] as P
	on C.ProductId = P.Id
	where P.Id=@Id
GROUP BY ProductId
ORDER BY ProductId
return @id