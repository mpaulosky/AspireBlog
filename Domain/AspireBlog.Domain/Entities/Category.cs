// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Category.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

using System.Diagnostics.CodeAnalysis;

namespace AspireBlog.Domain.Entities;

[Serializable]
[Collection("categories")]
public class Category
{

	public Category() { }

	[SetsRequiredMembers]
	public Category(string slug, string categoryName)
	{
		Slug = slug;
		CategoryName = categoryName;
	}

	[Key, Required, MaxLength(300)]
	public required string Slug { get; set; } = string.Empty;

	[Required, MaxLength(200)]
	public required string CategoryName { get; set; } = string.Empty;

	public static readonly Category Empty = new(slug : string.Empty, categoryName : string.Empty);

}