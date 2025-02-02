// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDtoGetListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfoDto))]
public class FakeUserInfoDtoGetListTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void GetUserInfoDtos_WithUseSeed_ShouldReturnsAListOfUserInfoDto(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeUserInfoDto.GetUserInfoDtos(count, useSeed);

		// Act
		var result = FakeUserInfoDto.GetUserInfoDtos(count, useSeed);

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