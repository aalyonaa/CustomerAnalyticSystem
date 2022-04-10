CREATE PROCEDURE [dbo].[GetAllProductsByTag]
	@Id integer
	as
	select P.[Id], G.[Name] as GroupName, P.[Name], P.[Description] from dbo.[Product] as P
	inner join Product_Tag as PT
	on PT.ProductId = P.Id and PT.TagId = @Id
	inner join dbo.[Group] as G
	on G.Id = P.GroupId
	where P.IsDeleted = 0 and PT.IsDeleted = 0 and G.IsDeleted = 0
RETURN 0
