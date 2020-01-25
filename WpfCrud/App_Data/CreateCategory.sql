create proc CreateCategory
(
	@CategoryName nvarchar(15),
	@Description ntext,
	@CategoryID int output
)
as
begin
	declare @Count int
	select @Count=count(*) from Categories
	where CategoryName=@CategoryName
	if(@Count=0)
	begin
		insert into Categories(CategoryName,Description)
		values (@CategoryName,@Description)
		return @@identity
	end
	else
	begin
		select @CategoryID=CategoryID from Categories
		where CategoryName= @CategoryName
		return 0
	end
end