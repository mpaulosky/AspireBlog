// set

namespace AspireBlog.Data.Mongo.Repositories;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
	Task<BlogPost?> GetPostBySlugAsync(string slug);

	Task<IEnumerable<BlogPost>> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null);
}