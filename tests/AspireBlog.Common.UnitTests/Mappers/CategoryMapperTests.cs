// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CategoryMapperTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryMapper))]
public class CategoryMapperTests
{
	[Fact]
	public void MapToCategory_ValidCategoryDto_ReturnsCategory()
	{
		// Arrange
		var categoryDto = new CategoryDto
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
		var result = categoryDto.MapToCategory();

		// Assert
		result.Id.Should().Be(categoryDto.Id);
		result.CategoryName.Should().Be(categoryDto.CategoryName);
		result.Slug.Should().Be(categoryDto.Slug);
		result.IsArchived.Should().Be(categoryDto.IsArchived);
		result.ArchivedBy.Should().BeEquivalentTo(categoryDto.ArchivedBy);
	}

	[Fact]
	public void MapToCategory_NullCategoryDto_ThrowsArgumentNullException()
	{
		// Arrange
		CategoryDto? categoryDto = null;

		// Act
		Action act = () => (categoryDto ?? throw new ArgumentNullException()).MapToCategory();

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.");
	}

	[Fact]
	public void MapToCategory_EmptyCategoryId_ThrowsArgumentException()
	{
		// Arrange
		var categoryDto = new CategoryDto
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
		Action act = () => categoryDto.MapToCategory();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Id*");
	}

	[Fact]
	public void MapToCategory_NullCategoryName_ThrowsArgumentException()
	{
		// Arrange
		var categoryDto = new CategoryDto
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
		Action act = () => categoryDto.MapToCategory();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*CategoryName*");
	}

	[Fact]
	public void MapToCategory_NullSlug_ThrowsArgumentException()
	{
		// Arrange
		var categoryDto = new CategoryDto
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Tech",
			Slug = null,
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
		Action act = () => categoryDto.MapToCategory();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Slug*");
	}

	[Fact]
	public void MapToCategory_NullArchivedBy_ThrowsArgumentNullException()
	{
		// Arrange
		var categoryDto = new CategoryDto
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Tech",
			Slug = "tech",
			IsArchived = false,
			ArchivedBy = null
		};

		// Act
		Action act = () => categoryDto.MapToCategory();

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*ArchivedBy*");
	}
	
	[Fact]
	public void Merge_ShouldMapCategoryDtoToCategory()
	{
		// Arrange
		var categoryDto = new CategoryDto
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Test Category",
			Slug = "test-category",
			IsArchived = false,
			ArchivedBy = null
		};
		var category = new Category();

		// Act
		var result = categoryDto.Merge(category);

		// Assert
		result.Id.Should().Be(categoryDto.Id);
		result.CategoryName.Should().Be(categoryDto.CategoryName);
		result.Slug.Should().Be(categoryDto.Slug);
		result.IsArchived.Should().Be(categoryDto.IsArchived);
		result.ArchivedBy.Should().BeNull();
	}

	[Fact]
	public void Merge_ShouldSetArchivedBy_WhenIsArchivedIsTrue()
	{
		// Arrange
		var archivedBy = FakeUserDto.GetNewUserDto(true, true);
		var categoryDto = new CategoryDto
		{
			Id = ObjectId.GenerateNewId(),
			CategoryName = "Test Category",
			Slug = "test-category",
			IsArchived = true,
			ArchivedBy = archivedBy
		};
		var category = new Category();

		// Act
		var result = categoryDto.Merge(category);

		// Assert
		result.Id.Should().Be(categoryDto.Id);
		result.CategoryName.Should().Be(categoryDto.CategoryName);
		result.Slug.Should().Be(categoryDto.Slug);
		result.IsArchived.Should().BeTrue();
		result.ArchivedBy.Should().Be(archivedBy);
	}
}