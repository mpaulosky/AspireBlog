// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UnitOfWork.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Data.Mongo.Implementation;

public class UnitOfWork : IUnitOfWork
{
	private readonly BlogDbContext _context;

	public UnitOfWork(IDbContextFactory<BlogDbContext> contextFactory)
	{
		//IDbContextFactory<BlogDbContext> contextFactory = Guard.Against.Null(contextFactory, nameof(contextFactory));
		_context = Guard.Against.Null(contextFactory.CreateDbContext(), nameof(BlogDbContext));

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