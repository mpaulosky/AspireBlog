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

public class BlogPostService : IBlogPostService
{
	private readonly ILogger<BlogPostService> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public BlogPostService(IUnitOfWork unitOfWork, ILogger<BlogPostService> logger)
	{
		_unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
		_logger = Guard.Against.Null(logger, nameof(logger));
	}

	/// <summary>
	///   Gets the blogPost by identifier asynchronously.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns>The blogPostDto if found; otherwise, null.</returns>
	public async Task<BlogPostDto?> GetByIdAsync(ObjectId id)
	{
		Guard.Against.EmptyObjectId(id, nameof(id));

		try
		{
			var blogPost = Guard.Against.Null(await _unitOfWork.BlogPost.GetByIdAsync(id), nameof(BlogPost));

			_logger.LogInformation("Returned blogPost with id: {id}", id);

			BlogPostDto result = blogPost.MapToBlogPostDto();

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetByIdAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets the blogPost by slug asynchronously.
	/// </summary>
	/// <param name="slug">The slug.</param>
	/// <returns>The blogPost DTO if found; otherwise, null.</returns>
	public async Task<BlogPostDto?> GetBySlugAsync(string slug)
	{
		Guard.Against.NullOrWhiteSpace(slug, nameof(slug));

		try
		{
			BlogPost blogPost = Guard.Against.Null(await _unitOfWork.BlogPost.GetBySlugAsync(slug), nameof(BlogPost));

			_logger.LogInformation($"Returned blogPost with slug: {slug}", slug);

			BlogPostDto ownerResult = blogPost.MapToBlogPostDto();

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
	/// <returns>A collection of blogPost DTOs if found; otherwise, null.</returns>
	public async Task<IEnumerable<BlogPostDto?>?> GetBlogPostsAsync(int count, int page)
	{
		try
		{
			var categories =
				Guard.Against.Null(await _unitOfWork.BlogPost.GetAllAsync(count, page), nameof(IQueryable<BlogPost>));

			_logger.LogInformation("Returned categories");

			List<BlogPostDto> ownerResult = new();

			foreach (BlogPost blogPost in categories)
			{
				ownerResult.Add(blogPost.MapToBlogPostDto());
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
	/// <returns>A queryable collection of blogPost DTOs if found; otherwise, null.</returns>
	public async Task<IQueryable<BlogPostDto?>?> GetQuerableBlogPostsAsync(int count, int page)
	{
		try
		{
			var categories = Guard.Against.Null(await _unitOfWork.BlogPost.GetAllAsync(count, page));

			_logger.LogInformation("Returned IQueryable categories");

			List<BlogPostDto> results = [];

			foreach (BlogPost blogPost in categories)
			{
				results.Add(blogPost.MapToBlogPostDto());
			}

			return (IQueryable<BlogPostDto?>?)results.AsQueryable();
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside QueryableCategoriesAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Creates a new blogPost asynchronously.
	/// </summary>
	/// <param name="model">The blogPost DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> CreateBlogPostAsync(BlogPostDto model)
	{
		Guard.Against.Null(model, nameof(model));

		bool exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Id == model.Id);

		if (exists)
		{
			_logger.LogError("This blogPost already exists.");

			return MethodResult.Failure("This blogPost already exists");
		}

		// Convert to blogPost entity

		BlogPost entity = model.MapToBlogPost();

		_unitOfWork.BlogPost.Create(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			return MethodResult.Success();
		}

		return MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Updates an existing blogPost asynchronously.
	/// </summary>
	/// <param name="model">The blogPost DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> UpdateBlogPostAsync(BlogPostDto model)
	{
		bool exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			return MethodResult.Failure("This blogPost does not exist");
		}

		BlogPost entity = model.MapToBlogPost();

		_unitOfWork.BlogPost.Update(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			return MethodResult.Success();
		}

		return MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Deletes an existing blogPost asynchronously.
	/// </summary>
	/// <param name="model">The blogPost DTO.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> DeleteBlogPostAsync(BlogPostDto model)
	{
		bool exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			_logger.LogError("This blogPost does not exist.");
			return MethodResult.Failure("This blogPost does not exist");
		}

		BlogPost entity = model.MapToBlogPost();

		_unitOfWork.BlogPost.Delete(entity);

		if (await _unitOfWork.CompleteAsync() > 0)
		{
			_logger.LogInformation("BlogPost has been deleted.");
			return MethodResult.Success();
		}

		_logger.LogError("Unknown error occurred while deleting the blogPost");
		return MethodResult.Failure("Unknown error occurred while deleting the blogPost");
	}
}