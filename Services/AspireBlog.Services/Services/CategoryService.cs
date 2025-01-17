// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services
// ========================================================

namespace AspireBlog.Services.Services;

/// <summary>
/// Provides services for managing categories.
/// Implements <see cref="ICategoryService"/>.
/// </summary>
public class CategoryService : ICategoryService
{

	private readonly ILogger<CategoryService> _logger;

	private readonly IUnitOfWork _unitOfWork;

	/// <summary>
	/// Initializes a new instance of the <see cref="CategoryService"/> class.
	/// </summary>
	/// <param name="unitOfWork">Instance of <see cref="IUnitOfWork"/> for database operations.</param>
	/// <param name="logger">Instance of <see cref="ILogger{CategoryService}"/> for logging.</param>
	public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
	{

		_unitOfWork = unitOfWork;

		_logger = logger;

	}

	/// <summary>
	/// Adds a new category to the database.
	/// </summary>
	/// <param name="entity">The category to add.</param>
	/// <returns>
	/// A <see cref="MethodResult"/> indicating the success or failure of the operation.
	/// Returns failure if the category already exists or if an error occurs while saving.
	/// </returns>
	public async Task<MethodResult> Add(Category entity)
	{

		var exists = await _unitOfWork.Category.AnyAsync(c => c.Slug == entity.Slug);

		if (exists)
		{

			_logger.LogError("This category already exists.");

			return MethodResult.Failure("This category already exists");

		}

		await _unitOfWork.Category.AddAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result == 0)
		{

			_logger.LogError("Unknown error occurred while saving the category.");

			return MethodResult.Failure("Unknown error occurred while saving the category");

		}

		_logger.LogInformation("Category has been saved.");

		return MethodResult.Success();

	}

	/// <summary>
	/// Adds a new list of categories to the database.
	/// </summary>
	/// <param name="entities">The categories to add.</param>
	/// <returns>
	/// A <see cref="MethodResult"/> indicating the success or failure of the operation.
	/// Returns failure if a category already exists or if an error occurs while saving.
	/// </returns>
	public async Task<MethodResult> AddRange(IEnumerable<Category> entities)
	{

		var categories = entities.ToList();

		var expected = categories.Count();

		await _unitOfWork.Category.AddRangeAsync(categories);

		var result = await _unitOfWork.CompleteAsync();

		if (result < expected)
		{

			_logger.LogError("Unknown error occurred while saving the categories. Saved {result} of {expected}.", result,
					expected);

			return MethodResult.Failure("Unknown error occurred while saving the categories. Saved {result} of {expected}.",
					result, expected);

		}

		_logger.LogInformation("Categories have been saved.");

		return MethodResult.Success();

	}

	/// <summary>
	/// Retrieves a category by its slug.
	/// </summary>
	/// <param name="slug">The slug of the category to retrieve.</param>
	/// <returns>
	/// The category as a <see cref="CategoryDto"/> if found; otherwise, <c>null</c>.
	/// Logs an error if the slug is invalid or if the category is not found.
	/// </returns>
	public async Task<CategoryDto?> GetBySlugAsync(string slug)
	{

		if (string.IsNullOrWhiteSpace(slug))
		{

			_logger.LogError("Slug is required.");

			return null;

		}

		var category = await _unitOfWork.Category.GetBySlugAsync(slug);

		if (category == null)
		{

			_logger.LogError("Category not found.");

			return null;

		}

		_logger.LogInformation("Successfully retrieved category.");

		var categoryDto = category.ToCategoryDto();

		return categoryDto;

	}

	/// <summary>
	/// Retrieves all categories.
	/// </summary>
	/// <returns>A collection of all categories, or <c>null</c> if none exist.</returns>
	public async Task<IEnumerable<CategoryDto>?> GetAllAsync()
	{

		var categories = (await _unitOfWork.Category.GetAllAsync()).ToList();

		_logger.LogInformation("Returned all categories.");

		return categories.ToCategoryDtoList();

	}

	/// <summary>
	/// Finds categories matching the given predicate.
	/// </summary>
	/// <param name="predicate">The predicate to filter categories.</param>
	/// <returns>
	/// A collection of matching categoryDtos, or <c>null</c> if no results are found.
	/// Logs success or failure information.
	/// </returns>
	public async Task<IEnumerable<CategoryDto>?> FindAsync(Expression<Func<Category, bool>> predicate)
	{

		var categories = (await _unitOfWork.Category.FindAsync(predicate)).ToList();

		if (categories.Count == 0)
		{

			_logger.LogError("Search found no results.");

			return null;

		}

		_logger.LogInformation("Successfully retrieved categories.");

		return categories.ToCategoryDtoList();

	}

	/// <summary>
	/// Finds the first category matching the given predicate.
	/// </summary>
	/// <param name="predicate">The predicate to filter the category.</param>
	/// <returns>
	/// The matching category, or <c>null</c> if not found.
	/// Logs success or failure information.
	/// </returns>
	public async Task<CategoryDto?> FindFirstAsync(Expression<Func<Category, bool>> predicate)
	{

		var category = await _unitOfWork.Category.FindFirstAsync(predicate);

		if (category == null)
		{

			_logger.LogError("Category not found.");

			return null;

		}

		_logger.LogInformation("Successfully retrieved category.");

		return category.ToCategoryDto();

	}

	/// <summary>
	/// Removes a category from the database.
	/// </summary>
	/// <param name="entity">The category to remove.</param>
	/// <returns>
	/// A <see cref="MethodResult"/> indicating the success or failure of the operation.
	/// Logs whether the removal was successful or failed.
	/// </returns>
	public async Task<MethodResult> RemoveAsync(Category entity)
	{

		var exists = await _unitOfWork.Category.AnyAsync(c => c.Slug == entity.Slug);

		if (!exists)
		{

			_logger.LogError("This category {slug} does not exist.", entity.Slug);

			return MethodResult.Failure("This category does not exist");

		}

		await _unitOfWork.Category.RemoveAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result > 0)
		{

			_logger.LogInformation("Category has been deleted.");

			return MethodResult.Success();

		}

		_logger.LogError("Unknown error occurred while deleting the category.");

		return MethodResult.Failure("Unknown error occurred while deleting the category");

	}

	/// <summary>
	/// Updates an existing category in the database.
	/// </summary>
	/// <param name="entity">The updated category entity.</param>
	/// <returns>
	/// A <see cref="MethodResult"/> indicating the success or failure of the update operation.
	/// Logs whether the update operation was successful or failed.
	/// </returns>
	public async Task<MethodResult> UpdateAsync(Category entity)
	{

		var exists = await _unitOfWork.Category.AnyAsync(c => c.Slug == entity.Slug);

		if (!exists)
		{

			_logger.LogError("This category {slug} does not exist.", entity.Slug);

			return MethodResult.Failure("This category {slug} does not exist", entity.Slug);

		}

		await _unitOfWork.Category.UpdateAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result > 0)
		{

			return MethodResult.Success();

		}

		_logger.LogError("Unknown error occurred while saving the category.");

		return MethodResult.Failure("Unknown error occurred while saving the category.");

	}

}