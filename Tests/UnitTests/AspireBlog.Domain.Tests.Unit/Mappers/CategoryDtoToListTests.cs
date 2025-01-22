// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoToListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryDto))]
public class CategoryDtoToListTests
{

	[Fact]
	public void ToCategoryList_With_ValidCategoryDtos_ShouldMapToCategoryList()
	{

		// Arrange
		var categoryDtos = FakeCategoryDto.GetCategoriesDto(2, true, true);

		// Act
		var result = categoryDtos.ToCategoryList();

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(2);
		result[0].Slug.Should().BeEquivalentTo(categoryDtos[0].Slug);
		result[0].CategoryName.Should().BeEquivalentTo(categoryDtos[0].CategoryName);
		result[1].Slug.Should().BeEquivalentTo(categoryDtos[1].Slug);
		result[1].CategoryName.Should().BeEquivalentTo(categoryDtos[1].CategoryName);

	}

}