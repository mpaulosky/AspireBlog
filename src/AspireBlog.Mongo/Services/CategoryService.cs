using Ardalis.GuardClauses;

using AspireBlog.Common.Entities;
using AspireBlog.Common.GuardClauses;
using AspireBlog.Common.Interfaces;
using AspireBlog.Common.Mappers;
using AspireBlog.Common.Models;
using AspireBlog.Mongo.Repositories;

using Microsoft.Extensions.Logging;

using MongoDB.Bson;

namespace AspireBlog.Mongo.Services;

/// <summary>
///   Service for managing categories.
/// </summary>
public class CategoryService : ICategoryService
{
	private readonly ILogger<CategoryService> _logger;
	private readonly IUnitOfWork _unitOfWork;

	/// <summary>
	///   Initializes a new instance of the <see cref="CategoryService" /> class.
	/// </summary>
	/// <param name="unitOfWork">The unit of work.</param>
	/// <param name="logger">The logger.</param>
	public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
	{
		_unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
		_logger = Guard.Against.Null(logger, nameof(logger));
	}

	/// <summary>
	///   Gets the category by identifier asynchronously.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns>The category DTO if found; otherwise, null.</returns>
	public async Task<CategoryDto?> GetByIdAsync(ObjectId id)
	{
		Guard.Against.EmptyObjectId(id, nameof(id));

		try
		{
			Category category = Guard.Against.Null(await _unitOfWork.Category.GetByIdAsync(id));

			_logger.LogInformation($"Returned category with id: {id}", id);

			CategoryDto ownerResult = category.MapToCategoryDto();

			return ownerResult;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetByIdAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets the category by slug asynchronously.
	/// </summary>
	/// <param name="slug">The slug.</param>
	/// <returns>The category DTO if found; otherwise, null.</returns>
	public async Task<CategoryDto?> GetBySlugAsync(string slug)
	{
		Guard.Against.NullOrWhiteSpace(slug, nameof(slug));

		try
		{
			Category category = Guard.Against.Null(await _unitOfWork.Category.GetBySlugAsync(slug));

			_logger.LogInformation($"Returned category with slug: {slug}", slug);

			CategoryDto ownerResult = category.MapToCategoryDto();

			return ownerResult;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetBySlugAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets all categories asynchronously.
	/// </summary>
	/// <returns>A collection of category DTOs if found; otherwise, null.</returns>
	public async Task<IEnumerable<CategoryDto?>?> GetCategoriesAsync(int count, int page)
	{
		try
		{
			IQueryable<Category> categories = Guard.Against.Null(await _unitOfWork.Category.GetAllAsync(count, page));

			_logger.LogInformation("Returned categories");

			List<CategoryDto> ownerResult = new();

			foreach (Category category in categories)
			{
				ownerResult.Add(category.MapToCategoryDto());
			}

			return ownerResult;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetCategoriesAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets the queryable categories asynchronously.
	/// </summary>
	/// <returns>A queryable collection of category DTOs if found; otherwise, null.</returns>
	public async Task<IQueryable<CategoryDto?>?> GetQuerableCategoriesAsync(int count, int page)
	{
		try
		{
			IQueryable<Category> categories = Guard.Against.Null(await _unitOfWork.Category.GetAllAsync(count, page));

			_logger.LogInformation("Returned IQueryable categories");

			List<CategoryDto> results = new();

			foreach (Category category in categories)
			{
				results.Add(category.MapToCategoryDto());
			}

			return (IQueryable<CategoryDto?>?)results.AsQueryable();
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside QueryableCategoriesAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Creates a new category asynchronously.
	/// </summary>
	/// <param name="model">The category DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> CreateCategoryAsync(CategoryDto model)
	{
		Guard.Against.Null(model, nameof(model));

		bool exists = await _unitOfWork.Category.AnyAsync(c => c.Id == model.Id);

		if (exists)
		{
			_logger.LogError("This category already exists.");

			return MethodResult.Failure("This category already exists");
		}

		// Convert to category entity

		Category entity = model.MapToCategory();

		_unitOfWork.Category.Create(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			return MethodResult.Success();
		}

		return MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Updates an existing category asynchronously.
	/// </summary>
	/// <param name="model">The category DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> UpdateCategoryAsync(CategoryDto model)
	{
		bool exists = await _unitOfWork.Category.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			return MethodResult.Failure("This category does not exist");
		}

		Category entity = model.MapToCategory();

		_unitOfWork.Category.Update(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			return MethodResult.Success();
		}

		return MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Deletes an existing category asynchronously.
	/// </summary>
	/// <param name="model">The category DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> DeleteCategoryAsync(CategoryDto model)
	{
		bool exists = await _unitOfWork.Category.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			_logger.LogError("This category does not exist.");
			return MethodResult.Failure("This category does not exist");
		}

		Category entity = model.MapToCategory();

		_unitOfWork.Category.Update(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			_logger.LogInformation("Category has been deleted.");
			return MethodResult.Success();
		}

		_logger.LogError("Unknown error occurred while deleting the category");
		return MethodResult.Failure("Unknown error occurred while deleting the category");
	}
}