CREATE PROCEDURE [dbo].[GetContactTypeById]
	@Id integer
as
select *
from dbo.[ContactType]
where Id = @Id and IsDeleted = 0
RETURN 0
