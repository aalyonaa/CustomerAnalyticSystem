CREATE PROCEDURE [dbo].[GetAllTagsWithMarksByCustomerId]
	@Id integer
AS
	select T.[Id], T.[Name], C.[Mark] from [dbo].[Tag] as T
inner join [dbo].[Product_Tag] as PT
on T.Id = PT.TagId
inner join Product as P
on P.Id = PT.ProductId
inner join [dbo].[Check] as C
on C.ProductId = P.Id
inner join [dbo].[Order] as O
on C.OrderId = O.Id
where O.CustomerId = @Id and T.IsDeleted = 0 and PT.IsDeleted = 0 and P.IsDeleted = 0 
and C.IsDeleted = 0 and O.IsDeleted = 0
RETURN @Id
