// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UnitOfWork.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// =======================================================

namespace AspireBlog.Persistence.Implementation;

public class UnitOfWork : IUnitOfWork
{

	private readonly BlogDbContext _context;

	public UnitOfWork(IDbContextFactory<BlogDbContext> context)
	{

		_context = context.CreateDbContext();

		BlogPost = new BlogPostRepository(_context);

		Category = new CategoryRepository(_context);

	}

	//public IBlogPostRepository BlogPost { get; }

	public IBlogPostRepository BlogPost { get; }

	public ICategoryRepository Category { get; }

	public async Task<int> CompleteAsync()
	{

		return await _context.SaveChangesAsync();

	}

	public void Dispose()
	{

		_context.Dispose();

	}

}