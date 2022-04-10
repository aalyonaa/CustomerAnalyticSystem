CREATE PROCEDURE [dbo].[GetGroupById]
	@Id integer
AS
	SELECT G.[Id], G.[Name], G.[Description] FROM [dbo].[Group] as G
	WHERE Id = @Id and IsDeleted = 0
RETURN 0
