// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.ModelsTests;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfoDto))]
public class UserInfoDtoTests
{

	[Fact]
	public void Empty_ShouldReturnEmptyUserInfoDto()
	{

		// Act
		var result = UserInfoDto.Empty;

		// Assert
		result.UserId.Should().BeEmpty();
		result.UserId.Should().BeEmpty();
		result.Email.Should().BeEmpty();
		result.Roles.Should().BeEmpty();

	}

}