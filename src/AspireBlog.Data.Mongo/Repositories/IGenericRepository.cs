// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IGenericRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Data.Mongo.Repositories;

public interface IGenericRepository<T> where T : class
{
	Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

	Task<T> GetByIdAsync(ObjectId id);

	Task<T> GetBySlugAsync(string slug);

	Task<IQueryable<T>> GetAllAsync(int count, int page);

	Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate);

	void Create(T entity);

	void Update(T entity);

	void Delete(T entity);

	void AddRange(IEnumerable<T> entities);

	void RemoveRange(IEnumerable<T> entities);
}