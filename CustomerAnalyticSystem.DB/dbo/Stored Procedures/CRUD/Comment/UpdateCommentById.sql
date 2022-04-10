CREATE PROCEDURE [dbo].[UpdateCommentById]
	@Id integer,
	@CustomerId integer, /*надо ли?*/
	@Text nvarchar(255)
as
	update [dbo].[Comment]
	set CustomerId=@CustomerId, /*надо ли?*/
	[Text]=@Text
	where Id=@Id
return @Id
