// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// ========================================================

namespace AspireBlog.Persistence.Implementation;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{

	public BlogPostRepository(BlogDbContext context) : base(context) { }

	public async Task<IQueryable<BlogPost>> GetPostsAsync(int count = 10, int page = 0)
	{

		var query = await Context.BlogPosts.AsNoTracking().OrderByDescending(bp => bp.CreatedOn).ToListAsync();

		// Ensure valid argument values
		if (count >= 0 || page >= 0)
		{

			// Apply pagination: Skip previous results and take the current page's results
			query = query.Skip(page * count).Take(count).ToList();

		}

		return query.AsQueryable();

	}

	public async Task<IEnumerable<BlogPost>> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null)
	{

		var query = await Context.BlogPosts.AsNoTracking()
				.OrderByDescending(bp => bp.CreatedOn)
				.Include(blogPost => blogPost.Category).ToListAsync();

		if (query.Count > 0 && !string.IsNullOrWhiteSpace(categorySlug))
		{

			query = query.Where(bp => bp.Category.Slug == categorySlug).ToList();

		}

		if (query.Count != 0 && publishedOnly)
		{

			query = query.Where(bp => bp.IsPublished).ToList();

		}

		return query;

	}

}