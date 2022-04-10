CREATE PROCEDURE [dbo].[GetCheckById]
	@Id integer
as
	select C.Id, C.ProductId, C.OrderId, C.Amount, C.Mark
	from [dbo].[Check] as C
	where Id=@Id and IsDeleted = 0
