// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostsGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostsGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPosts))]
public class FakeBlogPostsGetListTests
{

	[Theory]
	[InlineData(true, 5)]
	[InlineData(false, 5)]
	public void GetBlogPosts_With_UseSeedTrue_ShouldReturnBlogPost(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeBlogPosts.GetBlogPosts(count, useSeed);

		// Act
		var result = FakeBlogPosts.GetBlogPosts(count, useSeed);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo(expected, options => options.Excluding(x => x.Author.UserId));
		}
		else
		{
			result.Should().NotBeEquivalentTo(expected);
		}

	}

}