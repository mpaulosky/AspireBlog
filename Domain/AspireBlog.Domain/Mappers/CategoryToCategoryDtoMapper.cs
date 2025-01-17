// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryToCategoryDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

public static class CategoryToCategoryDtoMapper
{

	public static CategoryDto ToCategoryDto(this Category category)
	{

		return new CategoryDto
		{

				Slug = category.Slug,

				CategoryName = category.CategoryName,

		};

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