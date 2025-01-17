// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IGenericRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// ========================================================

namespace AspireBlog.Persistence.Interfaces;

public interface IGenericRepository<T> where T : class
{

	Task<MethodResult> AddAsync(T entity);

	Task<MethodResult>  AddRangeAsync(IEnumerable<T> entities);

	Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

	Task<T?> GetBySlugAsync(string slug);

	Task<IEnumerable<T>> GetAllAsync();

	Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

	Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate);
	
	Task<MethodResult>  RemoveAsync(T entity);

	Task<MethodResult>  UpdateAsync(T entity);

}