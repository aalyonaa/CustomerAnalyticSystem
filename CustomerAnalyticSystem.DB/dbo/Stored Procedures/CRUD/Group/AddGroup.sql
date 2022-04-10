CREATE PROCEDURE [dbo].[AddGroup]
	@Name nvarchar(35),
	@Description nvarchar(100)
AS
	INSERT INTO [dbo].[Group]
	VALUES(@Name, @Description, 0)
RETURN 0
