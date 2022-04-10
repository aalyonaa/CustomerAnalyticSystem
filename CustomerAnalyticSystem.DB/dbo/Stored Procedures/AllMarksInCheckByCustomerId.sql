CREATE PROCEDURE [dbo].[AllMarksInCheckByCustomerId]
	@Id int
AS
	select C.[ProductId], Prd.[Name], Prd.[Description], C.[Mark] from [dbo].[Check] as C
join [dbo].[Product] as Prd
on C.ProductId = Prd.Id
join [dbo].[Order] as Ord
on Ord.Id = C.OrderId
full join [dbo].[Customer] as Cus
on Cus.Id = Ord.CustomerId
where Cus.Id = @Id
RETURN 0
