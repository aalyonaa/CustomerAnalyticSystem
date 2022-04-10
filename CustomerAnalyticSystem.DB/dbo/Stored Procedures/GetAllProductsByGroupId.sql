CREATE PROCEDURE [dbo].[GetAllProductsByGroupId]
@Id integer
as
select P.[Id], G.[Name] as GroupName, P.[Name], P.[Description] from dbo.[Product] as P
inner join dbo.[Group] as G
on G.Id = P.GroupId
where P.GroupId = @Id and P.IsDeleted = 0 and G.IsDeleted = 0
RETURN @Id
