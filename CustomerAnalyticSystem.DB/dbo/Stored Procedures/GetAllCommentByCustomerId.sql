CREATE PROCEDURE [dbo].[GetAllCommentByCustomerId]
  @Id integer
as
  select C.Id,C.CustomerId, C.[Text] from [dbo].[Comment] as C
  where CustomerId = @Id and C.IsDeleted = 0
RETURN @Id