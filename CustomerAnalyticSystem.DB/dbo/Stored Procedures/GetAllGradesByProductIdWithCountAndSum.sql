CREATE PROCEDURE [dbo].[GetAllGradesByProductIdWithCountAndSum]
	@Id integer
as
  select P.Name, P.Description, C.Amount, C.Mark, Count(ProductId)AS CountOrder, SUM(Amount)AS SummAllOrder
  FROM [dbo].[Check] as C 
  join [dbo].[Product] as P
	on C.ProductId = P.Id
  where P.Id=@Id
  GROUP BY ProductId, P.Name, P.Description, C.Amount, C.Mark
  ORDER BY ProductId
RETURN @Id
