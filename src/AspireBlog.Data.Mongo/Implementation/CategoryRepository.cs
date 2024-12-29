// set

namespace AspireBlog.Data.Mongo.Implementation;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
	private readonly BlogDbContext _context;

	public CategoryRepository(BlogDbContext context) : base(context)
	{
		_context = Guard.Against.Null(context, nameof(context));
	}
}