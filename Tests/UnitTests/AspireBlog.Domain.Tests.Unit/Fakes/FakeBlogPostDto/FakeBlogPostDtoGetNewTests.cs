// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPostDto))]
public class FakeBlogPostDtoGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewBlogPostDto_With_UseSeedTrue_ShouldReturnBlogPostDto(bool useSeed)
	{

		// Arrange
		var etc = FakeBlogPostDto.GetNewBlogPostDto(useSeed);

		// Act
		var result = FakeBlogPostDto.GetNewBlogPostDto(useSeed);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo(etc);
		}
		else
		{
			result.Should().NotBeEquivalentTo(etc);
		}

	}

}