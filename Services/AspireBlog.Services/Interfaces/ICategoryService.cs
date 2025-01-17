// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ICategoryService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services
// ========================================================

namespace AspireBlog.Services.Interfaces;

public interface ICategoryService
{

	Task<MethodResult> Add(Category entity);

	Task<MethodResult>  AddRange(IEnumerable<Category> entities);

	Task<CategoryDto?> GetBySlugAsync(string slug);

	Task<IEnumerable<CategoryDto>?> GetAllAsync();

	Task<IEnumerable<CategoryDto>?> FindAsync(Expression<Func<Category, bool>> predicate);

	Task<CategoryDto?> FindFirstAsync(Expression<Func<Category, bool>> predicate);

	Task<MethodResult> RemoveAsync(Category entity);

	Task<MethodResult> UpdateAsync(Category entity);

}