create proc UpdateCategory
(
	@CategoryID int,
	@CategoryName nvarchar(15),
	@Description ntext
)
as
begin
	update Categories set 
		CategoryName=@CategoryName,
		Description=@Description
	where CategoryID=@CategoryID
end