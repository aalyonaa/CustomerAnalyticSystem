CREATE PROCEDURE [dbo].[GetTagById]
	@Id integer
AS
	SELECT Tag.Id, Tag.[Name] FROM [dbo].[Tag]
	WHERE Id = @Id and IsDeleted = 0
RETURN @Id
