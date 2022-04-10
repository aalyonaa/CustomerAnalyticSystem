CREATE PROCEDURE [dbo].[GetAllContactType]
as
select *
from dbo.[ContactType]
where IsDeleted = 0
RETURN 0
