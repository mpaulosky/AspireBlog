// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CategoryMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Common
// =============================================

namespace AspireBlog.Common.Mappers;

/// <summary>
///   Provides methods to map CategoryDto to Category.
/// </summary>
public static class CategoryMapper
{
	/// <summary>
	///   Maps CategoryDto to Category.
	/// </summary>
	/// <param name="categoryDto">The CategoryDto object to map.</param>
	/// <returns>A Category object.</returns>
	public static Category MapToCategory(this CategoryDto categoryDto)
	{
		
		Guard.Against.Null(categoryDto, nameof(categoryDto));
		
		return new Category
		{
			Id = Guard.Against.EmptyObjectId(categoryDto!.Id, nameof(categoryDto.Id)),
			CategoryName = Guard.Against.NullOrWhiteSpace(categoryDto.CategoryName),
			Slug = Guard.Against.NullOrWhiteSpace(categoryDto.Slug),
			IsArchived = categoryDto.IsArchived,
			ArchivedBy = Guard.Against.Null(categoryDto.ArchivedBy, nameof(categoryDto.ArchivedBy))
		};
		
	}

	/// <summary>
	///   Merge CategoryDto to Category.
	/// </summary>
	/// <param name="categoryDto">The CategoryDto object to map.</param>
	/// <param name="entity">The Category object to map to.</param>
	/// <returns>A Category object.</returns>
	public static Category Merge(this CategoryDto categoryDto, Category entity)
	{
		
		Guard.Against.Null(categoryDto, nameof(categoryDto));
		Guard.Against.Null(entity, nameof(entity));
		
		entity.Id = Guard.Against.EmptyObjectId(categoryDto!.Id, nameof(categoryDto.Id));
		entity.CategoryName = Guard.Against.NullOrWhiteSpace(categoryDto.CategoryName);
		entity.Slug = Guard.Against.NullOrWhiteSpace(categoryDto.Slug);
		entity.IsArchived = categoryDto.IsArchived;
		entity.ArchivedBy = categoryDto.IsArchived
			? Guard.Against.Null(categoryDto.ArchivedBy, nameof(categoryDto.ArchivedBy))
			: null;
		return entity;
		
	}
	
}