CREATE PROCEDURE [dbo].[GetAllGradesByProductId]
	@Id integer
as
  select P.Name, P.Description, G.Value, C.Amount, C.Mark
  from Grade as G
  left join [dbo].[Product] as P
  on P.Id=G.ProductId
  left join [dbo].[Check] as C
  on P.Id=C.ProductId
  where P.Id=@Id
RETURN @Id