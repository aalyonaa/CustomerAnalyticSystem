CREATE PROCEDURE [dbo].[GetAllPreferencesByCustomerId]
@Id integer
	as
	select P.ProductId, P.TagId, P.GroupId, P.IsInterested from dbo.[Preferences] as P
	where P.CustomerId = @Id and P.IsDeleted = 0
RETURN 0
