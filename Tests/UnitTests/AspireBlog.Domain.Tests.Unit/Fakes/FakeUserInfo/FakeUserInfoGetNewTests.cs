// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfo))]
public class FakeUserInfoGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUserInfo_WithUseSeed_ShouldReturnAUserInfo(bool useSeed)
	{

		// Arrange
		var expected = FakeUserInfo.GetNewUserInfo(useSeed);

		// Act
		var result = FakeUserInfo.GetNewUserInfo(useSeed);

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