// set

namespace AspireBlog.Data.Mongo.Repositories;

public interface IGenericRepository<T> where T : class
{
	Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

	Task<T> GetByIdAsync(ObjectId id);

	Task<T> GetBySlugAsync(string slug);

	Task<IQueryable<T>> GetAllAsync(int count, int page);

	Task<IEnumerable<T>> GetAllAsync();

	Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate);

	Task<T> FirstAsync(Expression<Func<T, bool>> predicate);


	void Create(T entity);

	void Update(T entity);

	void Delete(T entity);

	void AddRange(IEnumerable<T> entities);

	void RemoveRange(IEnumerable<T> entities);
}