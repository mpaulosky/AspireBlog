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

	public static Category ToCategory(this CategoryDto categoryDto)
	{

		Guard.Against.Null(categoryDto, nameof(categoryDto));

		return new Category { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName, };

	}

	/// <summary>
	///   Maps a list of CategoryDto to a list of Category.
	/// </summary>
	/// <param name="categoryDtos">The list of CategoryDto objects to map.</param>
	/// <returns>A list of Category objects.</returns>
	public static List<Category> ToCategoryList(this List<CategoryDto> categoryDtos)
	{

		return categoryDtos.Select(categoryDto => categoryDto.ToCategory()).ToList();

	}

	public static Category MergeToCategory(this CategoryDto categoryDto, Category entity)
	{

		return new Category() { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName, };

	}

}