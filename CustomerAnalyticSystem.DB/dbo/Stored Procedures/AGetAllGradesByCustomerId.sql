CREATE PROCEDURE [dbo].[AGetAllGradesByCustomerId]
@Id integer
AS
select G.CustomerId, C.FirstName, C.LastName, G.ProductId, P.[Name], P.[Description],  G.[Value] from [dbo].[Grade] as G
join [dbo].[Customer] as C
on G.CustomerId = C.Id
join [dbo].Product as P
on G.ProductId = p.Id
where C.Id = @Id
order by P.[Name]
RETURN @Id
