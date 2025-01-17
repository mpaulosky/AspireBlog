// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostToBlogPostDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

public static class BlogPostToBlogPostDtoMapper
{

	public static BlogPostDto ToBlogPostDto(this BlogPost blogPost)
	{

		Guard.Against.Null(blogPost, nameof(blogPost));

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
	///   Maps a list of BlogPost to a list of BlogPostDto.
	/// </summary>
	/// <param name="blogPosts">The list of BlogPosts objects to map.</param>
	/// <returns>A list of BlogPostDto objects.</returns>
	public static List<BlogPostDto> ToBlogPostDtoList(this List<BlogPost> blogPosts)
	{

		return blogPosts.Select(blogPost => blogPost.ToBlogPostDto()).ToList();

	}

}