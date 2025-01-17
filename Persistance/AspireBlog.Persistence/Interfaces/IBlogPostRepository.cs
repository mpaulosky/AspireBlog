// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IBlogPostRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// ========================================================

namespace AspireBlog.Persistence.Interfaces;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{

	Task<IQueryable<BlogPost>> GetPostsAsync(int count = 10, int page = 0);

	Task<IEnumerable<BlogPost>> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null);

}