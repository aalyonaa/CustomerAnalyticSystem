CREATE PROCEDURE [dbo].[GetAllGradesByCustomerId]
	  @Id integer
as
  select  P.[Id] as ProductId, P.[Name],G.[Id] as GradeId, G.[Value] as ProductGrade from [dbo].[Customer] as C
  left join [dbo].[Grade] as G
  on C.Id=G.CustomerId
  left join [dbo].[Product] as P
  on P.Id=G.ProductId
  
  where C.Id= @Id
RETURN @Id


