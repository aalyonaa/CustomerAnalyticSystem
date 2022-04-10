CREATE PROCEDURE [dbo].[DeleteProduct_TagByTagIdAndProductId]
@Id integer,
@IdProduct integer
as
delete from [dbo].[Product_Tag] 
	where [dbo].[Product_Tag].TagId = @Id and [dbo].[Product_Tag].ProductId = @IdProduct and IsDeleted = 0
return @Id
