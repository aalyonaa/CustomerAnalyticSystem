CREATE PROCEDURE [dbo].[GetAllProduct]
AS
	SELECT P.Id, P.Name, P.Description, P.GroupId from [dbo].[Product] as P
	where IsDeleted = 0
RETURN 0
