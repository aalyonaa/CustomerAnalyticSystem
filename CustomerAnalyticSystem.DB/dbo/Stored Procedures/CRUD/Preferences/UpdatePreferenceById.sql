CREATE PROCEDURE [dbo].[UpdatePreferenceById]
	@Id integer, 
	@ProductId integer, 
	@CustomerId integer, 
	@TagId integer, 
	@GroupId integer, 
	@IsInterested bit
as
update dbo.[Preferences]
set ProductId=@ProductId, CustomerId=@CustomerId, TagId=@TagId, GroupId=@GroupId, IsInterested=@IsInterested
where Id=@Id
