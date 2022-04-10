CREATE PROCEDURE [dbo].[DeleteTagById]
	@Id integer
AS
	update dbo.[Tag]
	set IsDeleted = 1
	where Id = @Id
return @Id