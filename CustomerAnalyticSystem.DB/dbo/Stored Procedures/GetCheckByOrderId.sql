CREATE PROCEDURE [dbo].[GetCheckByOrderId]
@Id integer
as
select P.Id as ProductId, P.Name as ProductName, C.Amount, C.Mark from [dbo].[Order] as O
join [dbo].[Check] as C
on C.OrderId = O.Id
join [dbo].[Product] as P
on P.Id = C.ProductId
where O.Id = @Id and O.IsDeleted = 0 and C.IsDeleted = 0 
RETURN 0
