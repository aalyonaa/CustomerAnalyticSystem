CREATE PROCEDURE [dbo].[GetAllPreferencesInfoByCustomerId]
	@Id integer
AS
select Cust.[Id], Cust.[FirstName], Cust.[LastName],Pref.ProductId as "Id", P.[Name], P.[Description],Pref.IsInterested,Pref.TagId as "Id",T.[Name],Pref.IsInterested,Pref.GroupId as "Id",G.[Name],G.[Description], Pref.IsInterested from[dbo].[Preferences] as Pref
full join  [dbo].[Product] as P
on Pref.ProductId = P.Id
full join [dbo].[Tag] as T
on Pref.TagId = T.Id
full join [dbo].[Group] as G
on Pref.GroupId = G.Id
join [dbo].[Customer] as Cust
on Pref.CustomerId = Cust.Id
where Pref.CustomerId = @Id
RETURN 0
