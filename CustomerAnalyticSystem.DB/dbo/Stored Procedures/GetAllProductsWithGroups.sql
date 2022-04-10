CREATE PROCEDURE [dbo].[GetAllProductsWithGroups]
	as
select P.Id, G.Name as GroupName, P.Name, P.Description, G.Id from dbo.[Product] as P
inner join dbo.[Group] as G
on P.GroupId = G.Id
where P.IsDeleted = 0 and G.IsDeleted = 0
RETURN 0
