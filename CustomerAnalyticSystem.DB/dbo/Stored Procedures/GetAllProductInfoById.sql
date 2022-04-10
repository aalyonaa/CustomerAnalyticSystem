CREATE PROCEDURE [dbo].[GetAllProductInfoById]
	@Id integer
AS
select P.[Id], p.[Name], p.GroupId as "GroupId", G.[Name] as "GroupName", G.[Description] as "GroupDescription",C.[Id]
, C.OrderId as "OrderId", C.[Amount], C.[Mark], Cus.[Id] as "CustomerId", Cus.[FirstName], Cus.[LastName] from [dbo].[Product] as P
join [dbo].[Group] as G
on P.GroupId = G.Id
join [dbo].[Check] as C
on P.Id = C.ProductId
join [dbo].[Order] as O
on C.OrderId = O.Id
join [dbo].[Customer] as Cus
on Cus.Id = O.CustomerId
where P.Id=@Id and P.IsDeleted = 0 and G.IsDeleted = 0 and C.IsDeleted = 0 and O.IsDeleted = 0 and Cus.IsDeleted = 0
RETURN @Id