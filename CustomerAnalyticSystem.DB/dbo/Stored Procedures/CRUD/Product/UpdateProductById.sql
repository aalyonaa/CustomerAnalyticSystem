CREATE PROCEDURE [dbo].[UpdateProductById]
  @Id integer,
  @Name nvarchar(35),
  @Description nvarchar(100),
  @GroupId integer
  as
  update dbo.[Product]
  set [Name] = @Name,
  [Description] = @Description,
  [GroupId] = @GroupId
  where Id = @Id
RETURN @Id
