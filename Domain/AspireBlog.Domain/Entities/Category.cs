// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Category.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Entities;

[Serializable]
[Collection("categories")]
public class Category
{

	[Key, Required, MaxLength(300)]
	public required string Slug { get; set; } = string.Empty;

	[Required, MaxLength(200)]
	public required string CategoryName { get; set; } = string.Empty;

	public static readonly Category Empty = new()
	{
			Slug = string.Empty, CategoryName = string.Empty, 
	};

}