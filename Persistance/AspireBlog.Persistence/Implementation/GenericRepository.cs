// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GenericRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// =======================================================

namespace AspireBlog.Persistence.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

	public readonly BlogDbContext Context;

	internal GenericRepository(BlogDbContext context)
	{

		Context = context;

	}

	public async Task<MethodResult>  AddAsync(T entity)
	{

		Context.Set<T>().Add(entity);

		return await Task.FromResult(MethodResult.Success());

	}

	public async Task<MethodResult>  AddRangeAsync(IEnumerable<T> entities)
	{

		Context.Set<T>().AddRange(entities);

		return await Task.FromResult(MethodResult.Success());

	}

	public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
	{

		return await Context.Set<T>().AnyAsync(predicate);

	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{

		return await Context.Set<T>().AsNoTracking().ToListAsync();

	}

	public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
	{

		return await Context.Set<T>().Where(predicate).ToListAsync();

	}

	public async Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate)
	{

		return await Context.Set<T>().FirstOrDefaultAsync(predicate);

	}

	public async Task<MethodResult> RemoveAsync(T entity)
	{

		Context.Set<T>().Remove(entity);

		return await Task.FromResult(MethodResult.Success());

	}

	public async Task<MethodResult> UpdateAsync(T entity)
	{

		Context.Set<T>().Update(entity);

		return await Task.FromResult(MethodResult.Success());

	}

}