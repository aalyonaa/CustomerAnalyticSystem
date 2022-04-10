CREATE PROCEDURE [dbo].[GetPreferenceById]
	@Id integer
as
select Preferences.[Id], Preferences.[ProductId], Preferences.[CustomerId], Preferences.[TagId], Preferences.[GroupId], Preferences.[IsInterested]
from dbo.[Preferences]
where Id=@Id and IsDeleted = 0

