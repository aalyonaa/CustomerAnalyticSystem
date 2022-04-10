CREATE PROCEDURE [dbo].[UpdateCustomerById]
  @Id integer,
  @FirstName nvarchar(50),
  @LastName nvarchar(50),
  @TypeId integer
as
  update [dbo].[Customer]
  set FirstName = @FirstName,
  LastName = @LastName,
  TypeId = @TypeId
  where Id = @Id
RETURN @Id
