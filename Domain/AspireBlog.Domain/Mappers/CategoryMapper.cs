// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
///   Provides extension methods for mapping Category entities to CategoryDto objects and vice versa.
/// </summary>
public static class CategoryMapper
{

	/// <summary>
	///   Maps a Category object to a CategoryDto object.
	/// </summary>
	/// <param name="category">The Category object to map.</param>
	/// <returns>A CategoryDto object.</returns>
	public static CategoryDto ToCategoryDto(this Category category)
	{

		return new CategoryDto { Slug = category.Slug, CategoryName = category.CategoryName };

	}

	/// <summary>
	///   Maps a list of Category to a list of CategoryDto.
	/// </summary>
	/// <param name="categories">The list of Category objects to map.</param>
	/// <returns>A list of CategoryDto objects.</returns>
	public static List<CategoryDto> ToCategoryDtoList(this List<Category> categories)
	{

		return categories.Select(category => category.ToCategoryDto()).ToList();

	}

}