// set

namespace AspireBlog.Data.Mongo.Repositories;

public interface IUnitOfWork : IDisposable
{
	IBlogPostRepository BlogPost { get; }
	IUserRepository User { get; }
	ICategoryRepository Category { get; }
	Task<int> CompleteAsync();
}