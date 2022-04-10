CREATE PROCEDURE [dbo].[DeleteCommentById]
	@Id integer
as
update [dbo].[Comment] 
set IsDeleted = 1
	where Id=@Id
