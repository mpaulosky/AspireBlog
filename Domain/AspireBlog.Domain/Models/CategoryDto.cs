// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Models;

public class CategoryDto
{

	public required string Slug { get; init; }

	public required string CategoryName { get; init; }

	public static readonly CategoryDto Empty = new() { Slug = string.Empty, CategoryName = string.Empty };

}