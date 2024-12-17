// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CategoryRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Data.Mongo
// =============================================

namespace AspireBlog.Data.Mongo.Implementation;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
	private readonly BlogDbContext _context;

	public CategoryRepository(BlogDbContext context) : base(context)
	{
		_context = Guard.Against.Null(context, nameof(context));
	}
}