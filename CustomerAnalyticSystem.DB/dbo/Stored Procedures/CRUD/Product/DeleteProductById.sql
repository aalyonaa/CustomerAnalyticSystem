CREATE PROCEDURE [dbo].[DeleteProductById]
	@Id integer
AS
	update [dbo].[Product]
	set IsDeleted = 1
	WHERE Id = @Id
RETURN @Id
