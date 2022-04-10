CREATE PROCEDURE [dbo].[GetContactById]
	@Id integer
as
select *
from dbo.[Contact]
where Id = @Id and IsDeleted = 0
RETURN 0
