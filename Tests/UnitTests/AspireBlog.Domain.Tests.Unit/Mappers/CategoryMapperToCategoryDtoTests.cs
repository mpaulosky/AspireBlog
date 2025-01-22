// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryMapperToCategoryDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryMapper))]
public class CategoryMapperToCategoryDtoTests
{

	[Fact]
	public void ToCategoryDto_With_Valid_Category_ShouldReturnACategoryDto()
	{

		// Arrange
		var category = new Category { Slug = "tech", CategoryName = "Technology" };

		// Act
		var result = category.ToCategoryDto();

		// Assert
		result.Should().NotBeNull();
		result.Slug.Should().Be(category.Slug);
		result.CategoryName.Should().Be(category.CategoryName);

	}

}