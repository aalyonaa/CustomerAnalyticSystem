CREATE PROCEDURE [dbo].[GetProductById]
	@Id integer
AS
	SELECT P.[Id], P.[Name], P.[Description], P.[GroupId] from [dbo].[Product] as P
	where Id = @Id and IsDeleted = 0
RETURN @Id
