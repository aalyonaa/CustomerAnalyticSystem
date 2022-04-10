CREATE PROCEDURE [dbo].[GetAllProduct_Tag]
	as
select PT.Id, PT.ProductId, PT.TagId
from dbo.[Product_Tag] as PT
where IsDeleted = 0

