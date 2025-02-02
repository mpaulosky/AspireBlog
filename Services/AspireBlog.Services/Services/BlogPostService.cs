// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services
// =======================================================

namespace AspireBlog.Services.Services;

/// <summary>
///   Provides services for managing blog posts.
///   Implements <see cref="IBlogPostService" />.
/// </summary>
public class BlogPostService : IBlogPostService
{

	private readonly ILogger<BlogPostService> _logger;

	private readonly IUnitOfWork _unitOfWork;

	/// <summary>
	///   Initializes a new instance of the <see cref="BlogPostService" /> class.
	/// </summary>
	/// <param name="unitOfWork">Instance of <see cref="IUnitOfWork" /> for database operations.</param>
	/// <param name="logger">Instance of <see cref="ILogger{BlogPostService}" /> for logging.</param>
	public BlogPostService(IUnitOfWork unitOfWork, ILogger<BlogPostService> logger)
	{

		_unitOfWork = unitOfWork;

		_logger = logger;

	}

	/// <summary>
	///   Adds a new blog post to the database.
	/// </summary>
	/// <param name="entity">The blog post to add.</param>
	/// <returns>
	///   A <see cref="MethodResult" /> indicating the success or failure of the operation.
	///   Returns failure if the blog post already exists or if an error occurs while saving.
	/// </returns>
	public async Task<MethodResult> AddAsync(BlogPost entity)
	{

		var exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Slug == entity.Slug);

		if (exists)
		{

			_logger.LogError("This blogPost already exists.");

			return MethodResult.Failure("This blogPost already exists.");

		}

		await _unitOfWork.BlogPost.AddAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result == 0)
		{

			_logger.LogError("Unknown error occurred while saving the blog post.");

			return MethodResult.Failure("Unknown error occurred while saving the blog post.");

		}

		_logger.LogInformation("BlogPost has been saved.");

		return MethodResult.Success();

	}

	/// <summary>
	///   Adds a new list of blog post to the database.
	/// </summary>
	/// <param name="entities">The blog posts to add.</param>
	/// <returns>
	///   A <see cref="MethodResult" /> indicating the success or failure of the operation.
	///   Returns failure if a blog post already exists or if an error occurs while saving.
	/// </returns>
	public async Task<MethodResult> AddRangeAsync(IEnumerable<BlogPost> entities)
	{

		var blogPosts = entities.ToList();

		var expected = blogPosts.Count();

		await _unitOfWork.BlogPost.AddRangeAsync(blogPosts);

		var result = await _unitOfWork.CompleteAsync();

		if (result < expected)
		{

			_logger.LogError("Unknown error occurred while saving the blog posts.");

			return MethodResult.Failure("Unknown error occurred while saving the blog posts.");

		}

		_logger.LogInformation("BlogPosts have been saved.");

		return MethodResult.Success();

	}

	/// <summary>
	///   Retrieves a blog post by its slug.
	/// </summary>
	/// <param name="slug">The slug of the blog post to retrieve.</param>
	/// <returns>
	///   The blog post as a <see cref="BlogPostDto" /> if found; otherwise, <c>null</c>.
	///   Logs an error if the slug is invalid or if the blog post is not found.
	/// </returns>
	public async Task<BlogPostDto?> GetBySlugAsync(string slug)
	{

		if (string.IsNullOrEmpty(slug))
		{

			_logger.LogError("Slug is required.");

			return null;

		}

		var blogPost = await _unitOfWork.BlogPost.FindFirstAsync(bp => bp.Slug == slug);

		if (blogPost == null)
		{

			_logger.LogError("BlogPost not found.");

			return null;

		}

		_logger.LogInformation("Successfully retrieved blogPost.");

		var blogPostDto = blogPost.ToBlogPostDto();

		return blogPostDto;

	}

	/// <summary>
	///   Retrieves all blog posts.
	/// </summary>
	/// <returns>A collection of all blog posts, or <c>null</c> if none exist.</returns>
	public async Task<IEnumerable<BlogPost>?> GetAllAsync()
	{

		var blogPosts = (await _unitOfWork.BlogPost.GetAllAsync()).ToList();

		if (blogPosts.Count == 0)
		{

			_logger.LogError("No blogPosts exist.");

			return null;

		}

		_logger.LogInformation("Returned all blogPosts.");

		return blogPosts;

	}

	/// <summary>
	///   Retrieves a paginated list of blog posts.
	/// </summary>
	/// <param name="count">The number of blog posts to retrieve.</param>
	/// <param name="page">The page number to retrieve.</param>
	/// <returns>An <see cref="IQueryable{BlogPost}" /> containing the requested blog posts.</returns>
	public async Task<IQueryable<BlogPost>?> GetPostsAsync(int count = 10, int page = 1)
	{

		var query = (await _unitOfWork.BlogPost.GetAllAsync()).AsQueryable().OrderByDescending(bp => bp.CreatedOn).ToList();

		if (query.Count == 0)
		{

			_logger.LogError("No blogPosts exist.");

			return null;

		}

		// Apply pagination: Skip previous results and take the current page's results
		var posts = query.Skip(page * count).Take(count).ToList();

		_logger.LogInformation("Returned paginated blogPosts.");

		return posts.AsQueryable();

	}

	/// <summary>
	///   Retrieves blog posts based on filtering criteria.
	/// </summary>
	/// <param name="publishedOnly">Whether to retrieve only published blog posts.</param>
	/// <param name="categorySlug">Optional category slug to filter by category.</param>
	/// <returns>A collection of filtered blog posts.</returns>
	public async Task<IEnumerable<BlogPost>?> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null)
	{

		var query = (await _unitOfWork.BlogPost.GetAllAsync())
				.OrderByDescending(bp => bp.CreatedOn)
				.ToList();

		if (query.Count == 0)
		{

			_logger.LogError("No blogPosts exist.");

			return null;

		}

		if (!string.IsNullOrWhiteSpace(categorySlug))
		{

			query = query.Where(bp => bp.Category.Slug == categorySlug).ToList();

		}

		if (publishedOnly)
		{

			query = query.Where(bp => bp.IsPublished).ToList();

		}

		_logger.LogInformation("Returned filtered blogPosts.");

		return query;

	}

	/// <summary>
	///   Removes a blog post from the database.
	/// </summary>
	/// <param name="entity">The blog post to remove.</param>
	/// <returns>
	///   A <see cref="MethodResult" /> indicating the success or failure of the operation.
	///   Logs whether the removal was successful or failed.
	/// </returns>
	public async Task<MethodResult> RemoveAsync(BlogPost entity)
	{

		var exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Slug == entity.Slug);

		if (!exists)
		{

			_logger.LogError("This blogPost does not exist.");

			return MethodResult.Failure("This blogPost does not exist");

		}

		await _unitOfWork.BlogPost.RemoveAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result > 0)
		{

			_logger.LogInformation("BlogPost has been removed.");

			return MethodResult.Success();

		}

		_logger.LogError("Unknown error occurred while removing the blogPost.");

		return MethodResult.Failure("Unknown error occurred while removing the blogPost");

	}

	/// <summary>
	///   Updates an existing blog post in the database.
	/// </summary>
	/// <param name="entity">The updated blog post entity.</param>
	/// <returns>
	///   A <see cref="MethodResult" /> indicating the success or failure of the update operation.
	///   Logs whether the update operation was successful or failed.
	/// </returns>
	public async Task<MethodResult> UpdateAsync(BlogPost entity)
	{

		var exists = await _unitOfWork.BlogPost.AnyAsync(c => c.Slug == entity.Slug);

		if (!exists)
		{

			_logger.LogError("This blogPost does not exist.");

			return MethodResult.Failure("This blogPost does not exist");

		}

		await _unitOfWork.BlogPost.UpdateAsync(entity);

		var result = await _unitOfWork.CompleteAsync();

		if (result > 0)
		{

			_logger.LogInformation("BlogPost has been updated.");

			return MethodResult.Success();

		}

		_logger.LogError("Unknown error occurred while saving the blog post.");

		return MethodResult.Failure("Unknown error occurred while saving the blog post.");

	}

}