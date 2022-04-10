CREATE PROCEDURE [dbo].[UpdateGroupById]
	@Id integer,
	@Name nvarchar (35),
	@Description nvarchar (100)
AS
	UPDATE [dbo].[Group]
	SET [Name] = @Name,
	[Description] = @Description
	WHERE [Id] = @Id
RETURN @Id
