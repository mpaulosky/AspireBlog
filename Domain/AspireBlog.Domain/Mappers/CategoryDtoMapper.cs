// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
///   Provides extension methods to map between <see cref="CategoryDto" /> and <see cref="Category" />.
/// </summary>
public static class CategoryDtoMapper
{

	/// <summary>
	///   Maps a CategoryDto to a Category.
	/// </summary>
	/// <param name="categoryDto">The CategoryDto object to map.</param>
	/// <returns>A Category object.</returns>
	public static Category ToCategory(this CategoryDto categoryDto)
	{

		return new Category { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName };

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

	/// <summary>
	///   Merges data from a CategoryDto into an existing Category entity.
	/// </summary>
	/// <param name="categoryDto">The CategoryDto object containing the updated data.</param>
	/// <param name="entity">The existing Category entity to be updated.</param>
	/// <returns>A new Category object with merged data.</returns>
	public static Category MergeToCategory(this CategoryDto categoryDto, Category entity)
	{

		return new Category { Slug = categoryDto.Slug, CategoryName = categoryDto.CategoryName };

	}

}