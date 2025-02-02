// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategoryFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategory))]
public class FakeCategoryFakeDataTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void FakeData_WithUseSeed_ShouldReturnACategory(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeCategory.GenerateFake(useSeed).Generate(count);

		// Act
		var result = FakeCategory.GenerateFake(useSeed).Generate(count);

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