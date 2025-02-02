// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfo))]
public class FakeUserInfoGetListTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void GetUserInfos_WithUseSeed_ShouldReturnsAListOfUserInfo(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeUserInfo.GetUserInfos(count, useSeed);

		// Act
		var result = FakeUserInfo.GetUserInfos(count, useSeed);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo(expected, options => options.Excluding(x => x.UserId));
		}
		else
		{
			result.Should().NotBeEquivalentTo(expected);
		}

	}

}