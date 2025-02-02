// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostsGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPosts))]
public class FakeBlogPostsGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewBlogPost_With_UseSeedTrue_ShouldReturnBlogPost(bool useSeed)
	{

		// Arrange
		var expected = FakeBlogPosts.GetNewBlogPost(useSeed);

		// Act
		var result = FakeBlogPosts.GetNewBlogPost(useSeed);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo<BlogPost>(expected, options => options.Excluding(x => x.Author.UserId));
		}
		else
		{
			result.Should().NotBeEquivalentTo<BlogPost>(expected);
		}

	}

}