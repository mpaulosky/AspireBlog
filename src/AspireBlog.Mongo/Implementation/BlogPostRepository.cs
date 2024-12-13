// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  BlazingBlog
// =============================================

using AspireBlog.Common.Entities;
using AspireBlog.Mongo.Context;
using AspireBlog.Mongo.Repositories;

namespace AspireBlog.Mongo.Implementation;

public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
	private readonly BlogDbContext _context;

	public BlogPostRepository(BlogDbContext context) : base(context)
	{
		_context = context;
	}
}