CREATE PROCEDURE [dbo].[GetAllGroup]
AS
	SELECT G.[Id], G.[Name], G.[Description] from [dbo].[Group] as G
	where IsDeleted = 0
RETURN 0
