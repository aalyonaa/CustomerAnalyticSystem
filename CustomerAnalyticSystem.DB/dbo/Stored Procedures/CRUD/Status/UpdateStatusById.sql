CREATE PROCEDURE [dbo].[UpdateStatusById]
	@Id integer, 
	@Name nvarchar(30)
AS
	update dbo.[Status]
	set Name = @Name
	where Id= @Id
RETURN @Id
