// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoMapperToDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoMapperToDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfoMapper))]
public class UserInfoMapperToDtoTests
{

	[Fact]
	public void ToUserInfoDto()
	{

		//Arrange
		var userInfo = FakeUserInfo.GetNewUserInfo(true);

		//Act
		var result = userInfo.ToUserInfoDto();

		//Assert
		result.Should().NotBeNull();
		result.Should().BeOfType<UserInfoDto>();
		result.UserId.Should().Be(userInfo.UserId);
		result.Name.Should().Be(userInfo.Name);
		result.Email.Should().Be(userInfo.Email);
		result.Roles.Should().BeEquivalentTo(userInfo.Roles);

	}

}