// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     GenericRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

using System.Linq.Expressions;

using Ardalis.GuardClauses;

using AspireBlog.Mongo.Context;
using AspireBlog.Mongo.Repositories;

using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;

namespace AspireBlog.Mongo.Implementation;

/// <summary>
///   A generic repository for performing CRUD operations on entities.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly BlogDbContext _context;

	/// <summary>
	///   Initializes a new instance of the <see cref="GenericRepository{T}" /> class.
	/// </summary>
	/// <param name="context">The database context.</param>
	public GenericRepository(BlogDbContext context)
	{
		_context = Guard.Against.Null(context, nameof(context));
	}

	/// <summary>
	///   Determines whether any entities satisfy the specified predicate.
	/// </summary>
	/// <param name="predicate">The predicate to test.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains true if any entities satisfy the
	///   predicate; otherwise, false.
	/// </returns>
	public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
	{
		return await _context.Set<T>().AnyAsync(predicate);
	}

	/// <summary>
	///   Gets an entity by its identifier.
	/// </summary>
	/// <param name="id">The identifier of the entity.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
	public async Task<T> GetByIdAsync(ObjectId id)
	{
		Guard.Against.Null(id, nameof(id));
		var result = Guard.Against.Null(await _context.Set<T>().FindAsync(id), nameof(T));
		return result;
	}

	/// <summary>
	///   Gets an entity by slug.
	/// </summary>
	/// <param name="slug">The identifier of the entity.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
	public async Task<T> GetBySlugAsync(string slug)
	{
		Guard.Against.NullOrWhiteSpace(slug, nameof(slug));
		// ReSharper disable once EntityFramework.ClientSideDbFunctionCall
		T? result = await _context.Set<T>().FirstOrDefaultAsync(c => EF.Property<string>(c, "slug") == slug);
		return Guard.Against.Null(result, nameof(T));
	}

	/// <summary>
	///   Gets all entities.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a collection of all entities.</returns>
	public async Task<IQueryable<T>> GetAllAsync(int count, int page)
	{
		count = count < 1 ? 10 : count;
		page = page < 1 ? 1 : page;

		IQueryable<T> posts = _context.Set<T>().AsNoTracking();

		if (posts.Any())
		{
			IQueryable<T> result = posts
				// ReSharper disable once EntityFramework.ClientSideDbFunctionCall
				.OrderByDescending(p => EF.Property<DateTime>(p, "CreatedOn"))
				.Skip((page - 1) * count)
				.Take(count)
				.AsQueryable();

			return await Task.FromResult(result);
		}

		return await Task.FromResult(Enumerable.Empty<T>().AsQueryable());
	}

	/// <summary>
	///   Finds entities that satisfy the specified predicate.
	/// </summary>
	/// <param name="predicate">The predicate to test.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains a collection of entities that
	///   satisfy the predicate.
	/// </returns>
	public Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
	{
		var result = _context.Set<T>().Where(predicate).AsNoTracking();
		return Task.FromResult(result);
	}

	/// <summary>
	///   Adds a range of new entities.
	/// </summary>
	/// <param name="entities">The entities to add.</param>
	public void AddRange(IEnumerable<T> entities)
	{
		IEnumerable<T> enumerable = entities.ToList();
		Guard.Against.Null(enumerable, nameof(entities));
		_context.Set<T>().AddRange(enumerable);
	}

	/// <summary>
	///   Removes a range of entities.
	/// </summary>
	/// <param name="entities">The entities to remove.</param>
	public void RemoveRange(IEnumerable<T> entities)
	{
		IEnumerable<T> enumerable = entities.ToList();
		Guard.Against.Null(enumerable, nameof(entities));
		_context.Set<T>().RemoveRange(enumerable);
	}

	/// <summary>
	///   Adds a new entity.
	/// </summary>
	/// <param name="entity">The entity to add.</param>
	public void Create(T entity)
	{
		Guard.Against.Null(entity, nameof(entity));
		_context.Set<T>().Add(entity);
	}

	/// <summary>
	///   Updates an entity.
	/// </summary>
	/// <param name="entity">The entity to update.</param>
	public void Update(T entity)
	{
		Guard.Against.Null(entity, nameof(entity));
		_context.Set<T>().Update(entity);
	}

	/// <summary>
	///   Deletes an entity.
	/// </summary>
	/// <param name="entity">The entity to delete.</param>
	public void Delete(T entity)
	{
		Guard.Against.Null(entity, nameof(entity));
		_context.Set<T>().Remove(entity);
	}
}