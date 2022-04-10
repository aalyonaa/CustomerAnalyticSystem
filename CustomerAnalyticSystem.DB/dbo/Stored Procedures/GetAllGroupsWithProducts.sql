CREATE PROCEDURE [dbo].[GetAllGroupsWithProducts]
AS
	SELECT * from [dbo].[Group] as G
	join [dbo].[Product] as P
	on P.GroupId = G.Id 
	where G.IsDeleted = 0 and P.IsDeleted = 0
	 ORDER BY G.Name
RETURN 0
