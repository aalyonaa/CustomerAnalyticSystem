CREATE PROCEDURE [dbo].[GetCommentById]
	@Id integer
as
	select C.[Id], C.[CustomerId], C.[Text]
	from [dbo].[Comment] as C
	where Id=@Id and C.IsDeleted = 0
