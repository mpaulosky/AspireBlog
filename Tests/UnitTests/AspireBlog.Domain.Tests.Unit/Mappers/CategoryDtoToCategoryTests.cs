// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoToCategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoToCategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryDto))]
public class CategoryDtoToCategoryTests
{

	[Fact]
	public void ToCategory_With_ValidCategoryDto_ShoudMapToCategory()
	{

		//Arrange
		var categoryDto = new CategoryDto { Slug = "test-slug", CategoryName = "Test Category" };

		//Act
		var result = categoryDto.ToCategory();

		//Assert
		result.Should().NotBeNull();
		result.Slug.Should().Be(categoryDto.Slug);
		result.CategoryName.Should().Be(categoryDto.CategoryName);

	}

}