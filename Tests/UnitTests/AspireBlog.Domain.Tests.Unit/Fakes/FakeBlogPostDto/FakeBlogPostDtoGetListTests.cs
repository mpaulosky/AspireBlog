// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPostDto))]
public class FakeBlogPostDtoGetListTests
{

	[Fact]
	public void GetBlogPostDtos_WithUseSeedAndCount_ShouldReturnListOfBlogPostDto()
	{

		// Arrange
		const int count = 5;
		const bool useSeed = true;
		var expected = FakeBlogPostDto.GetBlogPostDtos(count, useSeed);

		// Act
		var result = FakeBlogPostDto.GetBlogPostDtos(count, useSeed);

		// Assert
		result.Should().BeEquivalentTo(expected);

	}

	[Fact]
	public void GetBlogPostDtos_WithCount_ShouldReturnListOfBlogPostDto()
	{

		// Arrange
		const int count = 5;
		var expected = FakeBlogPostDto.GetBlogPostDtos(count);

		// Act
		var result = FakeBlogPostDto.GetBlogPostDtos(count);

		// Assert
		result.Should().NotBeEquivalentTo(expected);

	}

}