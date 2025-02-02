// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryMapperToListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryMapperToListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryMapper))]
public class CategoryMapperToListTests
{


	[Fact]
	public void ToCategoryDtoList_ShouldReturnListOfCategoryDtos_WithCorrectData()
	{

		// Arrange
		var categories = FakeCategory.GetCategories(2, true);

		// Act
		var result = categories.ToCategoryDtoList();

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(categories.Count);
		result[0].Slug.Should().BeEquivalentTo(categories[0].Slug);
		result[0].CategoryName.Should().BeEquivalentTo(categories[0].CategoryName);
		result[1].Slug.Should().BeEquivalentTo(categories[1].Slug);
		result[1].CategoryName.Should().BeEquivalentTo(categories[1].CategoryName);

	}

}