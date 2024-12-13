namespace AspireBlog.Common.Interfaces;

public interface ICategoryService
{
	Task<CategoryDto?> GetByIdAsync(ObjectId id);
	Task<CategoryDto?> GetBySlugAsync(string slug);
	Task<IEnumerable<CategoryDto?>?> GetCategoriesAsync(int count, int page);
	Task<IQueryable<CategoryDto?>?> GetQuerableCategoriesAsync(int count, int page);
	Task<MethodResult> CreateCategoryAsync(CategoryDto model);
	Task<MethodResult> UpdateCategoryAsync(CategoryDto model);
	Task<MethodResult> DeleteCategoryAsync(CategoryDto model);
}