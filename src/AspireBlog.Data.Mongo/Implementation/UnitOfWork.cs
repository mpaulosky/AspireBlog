// set

namespace AspireBlog.Data.Mongo.Implementation;

public class UnitOfWork : IUnitOfWork
{
	private readonly BlogDbContext _context;

	public UnitOfWork(IDbContextFactory<BlogDbContext> context)
	{
		_context = Guard.Against.Null(context.CreateDbContext(), nameof(BlogDbContext));

		BlogPost = new BlogPostRepository(_context);
		Category = new CategoryRepository(_context);
		User = new UserRepository(_context);
	}

	public IBlogPostRepository BlogPost { get; }
	public ICategoryRepository Category { get; }
	public IUserRepository User { get; }

	public async Task<int> CompleteAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}