CREATE PROCEDURE [dbo].[AddCustomer]
  @LastName nvarchar(50),
  @FirstName nvarchar(50),
  @TypeId integer
as
  insert into [dbo].[Customer] 
  values 
  (@LastName, @FirstName, @TypeId, 0)