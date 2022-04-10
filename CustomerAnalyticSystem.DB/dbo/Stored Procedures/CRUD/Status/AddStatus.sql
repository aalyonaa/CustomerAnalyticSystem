CREATE PROCEDURE [dbo].[AddStatus]
	@Name nvarchar(30)
AS
	insert dbo.[Status]
	values (@Name, 0)

