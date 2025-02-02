// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDtoGetNewTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfoDto))]
public class FakeUserInfoDtoGetNewTests
{

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUserInfoDto_WithUseSeed_ShouldReturnAUserInfoDto(bool useSeed)
	{

		// Arrange
		var expected = FakeUserInfoDto.GetNewUserInfoDto(useSeed);

		// Act
		var result = FakeUserInfoDto.GetNewUserInfoDto(useSeed);

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