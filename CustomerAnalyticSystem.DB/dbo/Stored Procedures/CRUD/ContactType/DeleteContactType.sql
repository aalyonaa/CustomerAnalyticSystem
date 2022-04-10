CREATE PROCEDURE [dbo].[DeleteContactType]
	@Id integer
as
update dbo.[ContactType]
set IsDeleted = 1
where Id = @Id 
RETURN 0
