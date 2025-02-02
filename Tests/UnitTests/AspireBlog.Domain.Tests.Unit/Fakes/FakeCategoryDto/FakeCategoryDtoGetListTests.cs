// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategoryDto))]
public class FakeCategoryDtoGetListTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void GetCategoriesDto_WithUseSeed_ShouldReturnAListOfCategoryDto(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeCategoryDto.GetCategoriesDto(count, useSeed);

		// Act
		var result = FakeCategoryDto.GetCategoriesDto(count, useSeed);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo(expected);
		}
		else
		{
			result.Should().NotBeEquivalentTo(expected);
		}

	}

}