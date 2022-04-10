CREATE PROCEDURE [dbo].[DeleteGroupById]
	@Id integer
AS
	update [dbo].[Group]
	set IsDeleted = 1
	WHERE Id = @Id
RETURN @Id
