create proc GetAllCategories
as
begin
	select CategoryID,CategoryName,Description 
	from Categories
end