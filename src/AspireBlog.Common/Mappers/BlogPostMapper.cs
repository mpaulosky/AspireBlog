// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Common
// =============================================

namespace AspireBlog.Common.Mappers;

/// <summary>
///   Provides methods to map BlogPostDto to BlogPost.
/// </summary>
public static class BlogPostMapper
{
	/// <summary>
	///   Maps BlogPostDto to BlogPost.
	/// </summary>
	/// <param name="blogPostDto">The BlogPostDto object to map.</param>
	/// <returns>A BlogPost object.</returns>
	public static BlogPost MapToBlogPost(this BlogPostDto blogPostDto)
	{
		
		Guard.Against.Null(blogPostDto, nameof(blogPostDto));
		
		return new BlogPost
		{
			Id = Guard.Against.EmptyObjectId(blogPostDto.Id, nameof(blogPostDto.Id)),
			Title = Guard.Against.NullOrWhiteSpace(blogPostDto.Title),
			Slug = Guard.Against.NullOrWhiteSpace(blogPostDto.Slug),
			Introduction = Guard.Against.NullOrWhiteSpace(blogPostDto.Introduction),
			Content = Guard.Against.NullOrWhiteSpace(blogPostDto.Content),
			CreatedOn = blogPostDto.CreatedOn,
			IsPublished = blogPostDto.IsPublished,
			PublishedOn = blogPostDto.PublishedOn,
			ModifiedOn = blogPostDto.ModifiedOn,
			Author = blogPostDto.Author,
			Category = blogPostDto.Category
		};
		
	}

	public static BlogPost? Merge(this BlogPostDto? blogPostDto, BlogPost? entity)
	{
		
		Guard.Against.Null(blogPostDto, nameof(blogPostDto));
		Guard.Against.Null(entity, nameof(entity));
		
		entity.Id = Guard.Against.EmptyObjectId(blogPostDto.Id, nameof(blogPostDto.Id));
		entity.Title = Guard.Against.NullOrWhiteSpace(blogPostDto.Title);
		entity.Slug = Guard.Against.NullOrWhiteSpace(blogPostDto.Slug);
		entity.Introduction = Guard.Against.NullOrWhiteSpace(blogPostDto.Introduction);
		entity.Content = Guard.Against.NullOrWhiteSpace(blogPostDto.Content);
		entity.CreatedOn = blogPostDto.CreatedOn;
		entity.IsPublished = blogPostDto.IsPublished;
		entity.PublishedOn = blogPostDto.PublishedOn;
		entity.ModifiedOn = blogPostDto.ModifiedOn;
		entity.Author = blogPostDto.Author;
		entity.Category = blogPostDto.Category;
		return entity;
		
	}
}