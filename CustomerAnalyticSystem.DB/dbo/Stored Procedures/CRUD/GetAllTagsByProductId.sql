CREATE PROCEDURE [dbo].[GetAllTagsByProductId]
@Id integer
as
select T.[Id], T.[Name] from dbo.[Tag] as T
join dbo.[Product_Tag] as Pt
on PT.TagId = T.Id
where PT.ProductId = @Id and T.IsDeleted = 0
RETURN 0
