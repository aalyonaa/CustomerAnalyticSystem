CREATE PROCEDURE [dbo].[UpdateContactType]
	@Id integer,
	@Name nvarchar (255)
as
update dbo.[ContactType]
set Name = @Name
where Id = @Id
RETURN 0
