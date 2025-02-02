// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Models;

public class BlogPostDto
{

	public required string Slug { get; init; }

	public required string Title { get; init; }

	public required string Introduction { get; init; }

	public required string Content { get; init; }

	public DateOnly? CreatedOn { get; init; }

	public bool IsPublished { get; init; }

	public DateOnly? PublishedOn { get; init; }

	public DateOnly? ModifiedOn { get; init; }

	public required CategoryDto Category { get; init; }

	public required UserInfoDto Author { get; init; }

	public static BlogPostDto Empty =>
			new()
			{
					Slug = string.Empty,
					Title = string.Empty,
					Introduction = string.Empty,
					Content = string.Empty,
					CreatedOn = null,
					IsPublished = false,
					PublishedOn = null,
					ModifiedOn = null,
					Category = CategoryDto.Empty,
					Author = UserInfoDto.Empty
			};

}