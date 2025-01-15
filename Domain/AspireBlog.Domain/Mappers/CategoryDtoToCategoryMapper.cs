// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoToCategoryMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

public static class CategoryDtoToCategoryMapper
{

	public static Category MapToCategory(this CategoryDto categoryDto)
	{

		Guard.Against.Null(categoryDto, nameof(categoryDto));

		return new Category { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName, };

	}

	public static Category MergeToCategory(this CategoryDto categoryDto, Category entity)
	{

		return new Category() { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName, };

	}

}