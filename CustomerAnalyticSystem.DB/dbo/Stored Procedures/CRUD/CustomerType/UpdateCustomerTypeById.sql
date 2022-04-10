CREATE PROCEDURE [dbo].[UpdateCustomerTypeById]
  @Id integer,
  @Name nvarchar(50)
as
  update [dbo].[CustomerType]
  set [Name] = @Name
  where Id = @Id