CREATE PROCEDURE [dbo].[UpdateTagById]
	@Id integer,
	@Name nvarchar (50)	
AS
	UPDATE [dbo].[Tag]
	SET [dbo].[Tag].[Name] = @Name	
	WHERE [dbo].[Tag].[Id] = @Id
RETURN @Id