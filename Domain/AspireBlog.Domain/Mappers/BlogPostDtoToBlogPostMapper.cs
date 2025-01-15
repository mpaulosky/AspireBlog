// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoToBlogPostMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

public static class BlogPostDtoToBlogPostMapper
{

	public static BlogPost ToBlogPost(this BlogPostDto blogPostDto)
	{

		Guard.Against.Null(blogPostDto, nameof(blogPostDto));

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

	public static BlogPost MergeToBlogPost(this BlogPostDto blogPostDto, BlogPost entity)
	{

		Guard.Against.Null(blogPostDto, nameof(blogPostDto));
		Guard.Against.Null(entity, nameof(entity));

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