CREATE PROCEDURE [dbo].[DropCustomerTypeById]
  @Id integer
as
update [dbo].[CustomerType]
set IsDeleted = 1
  where Id = @Id
RETURN @Id