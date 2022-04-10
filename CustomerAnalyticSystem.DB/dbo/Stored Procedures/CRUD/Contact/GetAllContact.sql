CREATE PROCEDURE [dbo].[GetAllContact]
as
select *
from dbo.[Contact]
where IsDeleted = 0
RETURN 0
