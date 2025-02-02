// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPost.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Entities;

[ Serializable]
[ Collection("blog-posts")]
public class BlogPost
{

	[ Key][ Required][ MaxLength(300)] public required string Slug { get; set; } = string.Empty;

	[ Required][ MaxLength(120)] public required string Title { get; set; } = string.Empty;

	[ Required][ MaxLength(250)] public required string Introduction { get; set; } = string.Empty;

	[ Required][ MaxLength(10000)] public required string Content { get; set; } = string.Empty;

	public DateOnly? CreatedOn { get; set; }

	public bool IsPublished { get; set; }

	public DateOnly? PublishedOn { get; set; }

	public DateOnly? ModifiedOn { get; set; }

	[MaxLength(100)] public string ImageUrl { get; set; } = string.Empty;

	public CategoryDto Category { get; set; } = CategoryDto.Empty;

	public UserInfoDto Author { get; set; } = UserInfoDto.Empty;

	public static BlogPost Empty =>
			new()
			{
					Slug = string.Empty,
					Title = string.Empty,
					Introduction = string.Empty,
					ImageUrl = string.Empty,
					Content = string.Empty,
					CreatedOn = null,
					IsPublished = false,
					PublishedOn = null,
					ModifiedOn = null,
					Category = CategoryDto.Empty,
					Author = UserInfoDto.Empty
			};

}