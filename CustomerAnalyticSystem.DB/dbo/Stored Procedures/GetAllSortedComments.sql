CREATE PROCEDURE [dbo].[GetAllSortedComments]
	as
select C.[Id], C.[CustomerId], C.[Text], C.[Id] as TempId
from [dbo].[Comment] as C
where C.IsDeleted = 0
order by CustomerId
