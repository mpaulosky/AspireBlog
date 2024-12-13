// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Common
// =============================================

namespace AspireBlog.Common.Mappers;

/// <summary>
///   Provides methods to map BlogPost related entities to BlogPostDto.
/// </summary>
public static class BlogPostDtoMapper
{
	/// <summary>
	///   Maps BlogPost to BlogPostDto.
	/// </summary>
	/// <param name="blogPost">The BlogPost entity to map.</param>
	/// <returns>A BlogPostDto object.</returns>
	public static BlogPostDto MapToBlogPostDto(this BlogPost? blogPost)
	{
		
		Guard.Against.Null(blogPost, nameof(blogPost));
		
		return new BlogPostDto
		{
			Id = Guard.Against.EmptyObjectId(blogPost.Id, nameof(blogPost.Id)),
			Title = Guard.Against.NullOrWhiteSpace(blogPost.Title),
			Slug = Guard.Against.NullOrWhiteSpace(blogPost.Slug),
			Introduction = Guard.Against.NullOrWhiteSpace(blogPost.Introduction),
			Content = Guard.Against.NullOrWhiteSpace(blogPost.Content),
			CreatedOn = Guard.Against.OutOfSQLDateRange((DateTime)blogPost.CreatedOn!, nameof(blogPost.CreatedOn)),
			IsPublished = blogPost.IsPublished,
			PublishedOn = blogPost.PublishedOn,
			ModifiedOn = blogPost.ModifiedOn,
			Author = blogPost.Author,
			Category = blogPost.Category
		};
		
	}
}