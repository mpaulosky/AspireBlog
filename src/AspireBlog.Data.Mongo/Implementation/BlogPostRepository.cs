// set

namespace AspireBlog.Data.Mongo.Implementation;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
	private readonly BlogDbContext _context;

	public BlogPostRepository(BlogDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<BlogPost?> GetPostBySlugAsync(string slug)
	{
		return await _context.BlogPosts
			.Include(bp => bp.Category)
			.AsNoTracking()
			.FirstOrDefaultAsync(bp => bp.IsPublished && bp.Slug == slug);
	}

	public async Task<IEnumerable<BlogPost>> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null)
	{
		IQueryable<BlogPost>? query = _context.BlogPosts.AsNoTracking();

		if (!string.IsNullOrWhiteSpace(categorySlug))
		{
			Category? category = await _context.Categories
				.AsNoTracking()
				.Where(c => c.Slug == categorySlug)
				.FirstOrDefaultAsync();

			Guard.Against.Null(category, nameof(category));

			query = query.Where(bp => bp.Category != null && bp.Category.Id == category.Id);
		}

		if (publishedOnly)
		{
			query = query.Where(bp => bp.IsPublished);
		}

		return await query.ToListAsync();
	}
}