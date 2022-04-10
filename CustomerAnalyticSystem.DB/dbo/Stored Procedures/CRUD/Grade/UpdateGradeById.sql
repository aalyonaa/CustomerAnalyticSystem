CREATE PROCEDURE [dbo].[UpdateGradeById]
	@Id integer, 
	@ProductId integer, 
	@CustomerId integer, 
	@Value integer
as
update dbo.[Grade]
set ProductId=@ProductId, CustomerId=@CustomerId, Value=@Value
where Id=@Id
