// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
///   Provides mapping functionality for converting between BlogPost entities
///   and BlogPostDto models.
/// </summary>
public static class BlogPostMapper
{

	/// <summary>
	///   Maps a <see cref="BlogPost" /> entity to a <see cref="BlogPostDto" /> model.
	/// </summary>
	/// <param name="blogPost">The blog post entity to be mapped.</param>
	/// <returns>A <see cref="BlogPostDto" /> model containing the mapped data from the input entity.</returns>
	public static BlogPostDto ToBlogPostDto(this BlogPost blogPost)
	{

		return new BlogPostDto
		{
				Slug = blogPost.Slug,
				Title = blogPost.Title,
				Introduction = blogPost.Introduction,
				Content = blogPost.Content,
				CreatedOn = blogPost.CreatedOn,
				IsPublished = blogPost.IsPublished,
				PublishedOn = blogPost.PublishedOn,
				ModifiedOn = blogPost.ModifiedOn,
				Author = blogPost.Author,
				Category = blogPost.Category
		};

	}

	/// <summary>
	///   Maps a list of <see cref="BlogPost" /> entities to a list of <see cref="BlogPostDto" /> models.
	/// </summary>
	/// <param name="blogPosts">The list of blog post entities to be mapped.</param>
	/// <returns>A list of <see cref="BlogPostDto" /> models containing the mapped data from the input entities.</returns>
	public static List<BlogPostDto> ToBlogPostDtoList(this List<BlogPost> blogPosts)
	{

		return blogPosts.Select(blogPost => blogPost.ToBlogPostDto()).ToList();

	}

}