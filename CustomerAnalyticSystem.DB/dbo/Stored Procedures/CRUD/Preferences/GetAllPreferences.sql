CREATE PROCEDURE [dbo].[GetAllPreferences]
	as
select Preferences.[Id], Preferences.[ProductId], Preferences.[CustomerId], Preferences.[TagId], Preferences.[GroupId],
Preferences.[IsInterested]
from dbo.[Preferences]
where IsDeleted = 0
