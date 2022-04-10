CREATE PROCEDURE [dbo].[AddTag]
	@Name nvarchar(50)
AS
	insert into [dbo].[Tag]
	values 
  (@Name, 0)
RETURN 0
