CREATE PROCEDURE [dbo].[DeleteStatusById]
	@Id integer
AS
	update dbo.[Status]
	set IsDeleted = 1
	where Id= @Id
return @Id

