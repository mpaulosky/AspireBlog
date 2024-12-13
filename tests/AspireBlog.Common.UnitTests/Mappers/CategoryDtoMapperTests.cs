// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CategoryDtoMapperTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryDtoMapper))]
public class CategoryDtoMapperTests
{
	[Fact]
	public void MapToCategoryDto_ValidCategory_ReturnsCategoryDto()
	{
		// Arrange
		var category = new Category
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Tech",
			Slug = "tech",
			IsArchived = true,
			ArchivedBy = new UserDto
			{
				Id = ObjectId.GenerateNewId(),
				FirstName = "John",
				LastName = "Doe",
				FullName = "John Doe",
				Email = "john.doe@test.com"
			}
		};

		// Act
		var result = category.MapToCategoryDto();

		// Assert
		result.Id.Should().Be(category.Id);
		result.CategoryName.Should().Be(category.CategoryName);
		result.Slug.Should().Be(category.Slug);
		result.IsArchived.Should().Be(category.IsArchived);
		result.ArchivedBy.Should().Be(category.ArchivedBy);
	}

	[Fact]
	public void MapToCategoryDto_NullCategory_ThrowsArgumentNullException()
	{
		// Arrange
		Category? category = null;

		// Act
		Action act = () => (category ?? throw new ArgumentNullException()).MapToCategoryDto();

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*Value cannot be null.*");
	}

	[Fact]
	public void MapToCategoryDto_EmptyCategoryId_ThrowsArgumentException()
	{
		// Arrange
		var category = new Category
		{
			Id = ObjectId.Empty,
			CategoryName = "Tech",
			Slug = "tech",
			IsArchived = true,
			ArchivedBy = new UserDto
			{
				Id = ObjectId.GenerateNewId(),
				FirstName = "John",
				LastName = "Doe",
				FullName = "John Doe",
				Email = "john.doe@test.com"
			}
		};

		// Act
		Action act = () => category.MapToCategoryDto();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Id*");
	}

	[Fact]
	public void MapToCategoryDto_NullCategoryName_ThrowsArgumentException()
	{
		// Arrange
		var category = new Category
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = string.Empty,
			Slug = "tech",
			IsArchived = true,
			ArchivedBy = new UserDto
			{
				Id = ObjectId.GenerateNewId(),
				FirstName = "John",
				LastName = "Doe",
				FullName = "John Doe",
				Email = "john.doe@test.com"
			}
		};

		// Act
		Action act = () => category.MapToCategoryDto();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*CategoryName*");
	}

	[Fact]
	public void MapToCategoryDto_NullSlug_ThrowsArgumentException()
	{
		// Arrange
		var category = new Category
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Tech",
			Slug = string.Empty,
			IsArchived = true,
			ArchivedBy = new UserDto
			{
				Id = ObjectId.GenerateNewId(),
				FirstName = "John",
				LastName = "Doe",
				FullName = "John Doe",
				Email = "john.doe@test.com"
			}
		};

		// Act
		Action act = () => category.MapToCategoryDto();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Slug*");
	}
}