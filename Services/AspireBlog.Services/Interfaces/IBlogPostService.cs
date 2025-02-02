// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IBlogPostService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services
// =======================================================

namespace AspireBlog.Services.Interfaces;

public interface IBlogPostService
{

	Task<MethodResult> AddAsync(BlogPost entity);

	Task<MethodResult> AddRangeAsync(IEnumerable<BlogPost> entities);

	Task<BlogPostDto?> GetBySlugAsync(string slug);

	Task<IEnumerable<BlogPost>?> GetAllAsync();

	public Task<IQueryable<BlogPost>?> GetPostsAsync(int count, int page);

	public Task<IEnumerable<BlogPost>?> GetPostsAsync(bool publishedOnly = false, string? categorySlug = null);

	Task<MethodResult> RemoveAsync(BlogPost entity);

	Task<MethodResult> UpdateAsync(BlogPost entity);

}