// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryGetNewTests.cs
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
public class FakeCategoryGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewCategory_WithUseSeed_ShouldReturnACategory(bool useSeed)
	{

		// Arrange
		var expected = FakeCategory.GetNewCategory(useSeed);

		// Act
		var result = FakeCategory.GetNewCategory(useSeed);

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