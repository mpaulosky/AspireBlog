// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategory))]
public class FakeCategoryGetListTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void GetCategories_WithUseSeed_ShouldReturnACategory(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeCategory.GetCategories(count, useSeed);

		// Act
		var result = FakeCategory.GetCategories(count, useSeed);

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