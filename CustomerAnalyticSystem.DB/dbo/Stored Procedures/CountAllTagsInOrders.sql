CREATE PROCEDURE [dbo].[CountAllTagsInOrders]
AS
	select PT.TagId,T.[Name] as "TagName", COUNT (O.Id) as 'Number' from [dbo].[Order] as O
	join [dbo].[Check] as C
	on O.Id = C.Id
	join [dbo].[Product_Tag] as PT
	on C.ProductId = PT.ProductId
	join [dbo].[Tag] as T
	on T.[Id] = PT.TagId
	group by PT.TagId, T.[Name]
RETURN 0
