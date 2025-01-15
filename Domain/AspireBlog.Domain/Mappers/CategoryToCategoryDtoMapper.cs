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

	public static Category MapToCategory(this CategoryDto categoryDto)
	{

		return new Category
		{

				Slug = categoryDto.Slug,

				CategoryName = categoryDto.CategoryName,

		};

	}

}