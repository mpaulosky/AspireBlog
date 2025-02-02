// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
///   Provides mapping functionalities between BlogPostDto and BlogPost entities.
/// </summary>
public static class BlogPostDtoMapper
{

	/// <summary>
	///   Maps a BlogPostDto object to a BlogPost object.
	/// </summary>
	/// <param name="blogPostDto">The BlogPostDto object to map.</param>
	/// <returns>A BlogPost object with mapped properties from the BlogPostDto.</returns>
	public static BlogPost ToBlogPost(this BlogPostDto blogPostDto)
	{

		return new BlogPost
		{
				Slug = blogPostDto.Slug,
				Title = blogPostDto.Title,
				Introduction = blogPostDto.Introduction,
				Content = blogPostDto.Content,
				CreatedOn = blogPostDto.CreatedOn,
				IsPublished = blogPostDto.IsPublished,
				PublishedOn = blogPostDto.PublishedOn,
				ModifiedOn = blogPostDto.ModifiedOn,
				Category = blogPostDto.Category,
				Author = blogPostDto.Author
		};

	}

	/// <summary>
	///   Maps a list of BlogPostDto to a list of BlogPost.
	/// </summary>
	/// <param name="blogPostDtos">The list of BlogPostDto objects to map.</param>
	/// <returns>A list of BlogPost objects.</returns>
	public static List<BlogPost> ToBlogPostList(this List<BlogPostDto> blogPostDtos)
	{

		return blogPostDtos.Select(blogPostDto => blogPostDto.ToBlogPost()).ToList();

	}

	/// <summary>
	///   Merges the properties of a BlogPostDto object into an existing BlogPost entity.
	/// </summary>
	/// <param name="blogPostDto">The BlogPostDto object containing the updated values to merge.</param>
	/// <param name="entity">The existing BlogPost entity that will be updated with the values from the BlogPostDto.</param>
	/// <returns>The updated BlogPost entity with values merged from the BlogPostDto.</returns>
	public static BlogPost MergeToBlogPost(this BlogPostDto blogPostDto, BlogPost entity)
	{

		entity.Slug = blogPostDto.Slug;
		entity.Title = blogPostDto.Title;
		entity.Introduction = blogPostDto.Introduction;
		entity.Content = blogPostDto.Content;
		entity.CreatedOn = blogPostDto.CreatedOn;
		entity.IsPublished = blogPostDto.IsPublished;
		entity.PublishedOn = blogPostDto.PublishedOn;
		entity.ModifiedOn = blogPostDto.ModifiedOn;
		entity.Category = blogPostDto.Category;
		entity.Author = blogPostDto.Author;

		return entity;

	}

}