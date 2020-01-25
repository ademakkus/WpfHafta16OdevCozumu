create proc DeleteCategory
(
	@CategoryID int,
	@ProductCount int output
)
as
begin
	select @ProductCount=count(*) from Products
	where CategoryID=@CategoryID
	if(@ProductCount=0)
	begin
		delete Categories where CategoryID=@CategoryID
		return 1
	end
	else
		return 0
end