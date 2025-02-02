// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategoryDto))]
public class FakeCategoryDtoGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewCategoryDto_WithUseSeed_ShouldReturnACategoryDto(bool useSeed)
	{

		// Arrange
		var expected = FakeCategoryDto.GetNewCategoryDto(useSeed);

		// Act
		var result = FakeCategoryDto.GetNewCategoryDto(useSeed);

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