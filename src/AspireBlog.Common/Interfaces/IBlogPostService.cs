namespace AspireBlog.Common.Interfaces;

public interface IBlogPostService
{
	Task<BlogPostDto?> GetByIdAsync(ObjectId id);
	Task<BlogPostDto?> GetBySlugAsync(string slug);
	Task<IEnumerable<BlogPostDto?>?> GetBlogPostsAsync(int count, int page);
	Task<IQueryable<BlogPostDto?>?> GetQuerableBlogPostsAsync(int count, int page);
	Task<MethodResult> CreateBlogPostAsync(BlogPostDto model);
	Task<MethodResult> UpdateBlogPostAsync(BlogPostDto model);
	Task<MethodResult> DeleteBlogPostAsync(BlogPostDto model);
}