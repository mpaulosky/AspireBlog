// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoMergeToCategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoMergeToCategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryDto))]
public class CategoryDtoMergeToCategoryTests
{

	[Fact]
	public void MergeToCategory_With_ValidCategoryDto_ShouldMergeToCategory()
	{

		// Arrange
		var categoryDto = new CategoryDto { Slug = "merged-slug", CategoryName = "Merged Category" };
		var existingCategory = new Category { Slug = "original-slug", CategoryName = "Original Category" };

		// Act
		var result = categoryDto.MergeToCategory(existingCategory);

		// Assert
		result.Should().NotBeNull();
		result.Slug.Should().Be(categoryDto.Slug);
		result.CategoryName.Should().Be(categoryDto.CategoryName);

	}

}