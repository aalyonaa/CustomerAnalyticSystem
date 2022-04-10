CREATE PROCEDURE [dbo].[GetAllGrades] 
	as
select Grade.[Id], Grade.[ProductId], Grade.[CustomerId], Grade.[Value]
from dbo.[Grade]
where IsDeleted = 0
