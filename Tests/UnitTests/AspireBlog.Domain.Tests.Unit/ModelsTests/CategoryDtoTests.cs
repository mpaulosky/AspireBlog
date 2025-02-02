// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.ModelsTests;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryDto))]
public class CategoryDtoTests
{

	[Fact]
	public void Empty_ShouldReturnEmptyCategoryDto()
	{

		// Act
		var result = CategoryDto.Empty;

		// Assert
		result.CategoryName.Should().BeEmpty();
		result.Slug.Should().BeEmpty();

	}

}