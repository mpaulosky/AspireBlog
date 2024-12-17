// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Data.Mongo
// =============================================

namespace AspireBlog.Data.Mongo.Implementation;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
	private readonly BlogDbContext _context;

	public BlogPostRepository(BlogDbContext context) : base(context)
	{
		_context = context;
	}
}