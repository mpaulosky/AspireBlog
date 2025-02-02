// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostsFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPosts))]
public class FakeBlogPostFakeDataTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void FakeData_WithUseSeed_ShouldReturnAListOfBlogPosts(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeBlogPosts.GenerateFake(useSeed).Generate(count);

		// Act
		var result = FakeBlogPosts.GenerateFake(useSeed).Generate(count);

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