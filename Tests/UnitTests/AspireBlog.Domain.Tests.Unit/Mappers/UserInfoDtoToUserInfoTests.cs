// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDtoToUserInfoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfoDtoMapper))]
public class UserInfoDtoToUserInfoTests
{

	[Fact]
	public void ToUserIngo_With_Valid_UserInfoDto_ShouldReturnAUserInfo()
	{

		//Arrange
		var userInfoDto = FakeUserInfoDto.GetNewUserInfoDto(true, true);

		//Act
		var result = userInfoDto.ToUserInfo();

		//Assert
		result.Should().NotBeNull();
		result.Should().BeOfType<UserInfo>();
		result.Should().BeEquivalentTo(userInfoDto, options => options.ExcludingMissingMembers());

	}

}