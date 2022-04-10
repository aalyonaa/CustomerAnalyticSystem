CREATE PROCEDURE [dbo].[AddCustomerType]
  @Name nvarchar(50)
as
  insert into [dbo].[CustomerType] 
  values 
  (@Name, 0)
