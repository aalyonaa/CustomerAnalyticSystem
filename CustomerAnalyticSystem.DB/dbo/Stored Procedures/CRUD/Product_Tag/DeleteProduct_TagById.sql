CREATE PROCEDURE [dbo].[DeleteProduct_TagById]
	@Id integer
AS
	delete from [dbo].[Product_Tag]
	where Id = @Id
return @Id