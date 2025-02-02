// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.ModelsTests;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfo))]
public class UserInfoTests
{

	[Fact]
	public void Empty_ShouldReturnEmptyUserInfo()
	{

		// Act
		var result = UserInfo.Empty;

		// Assert
		result.UserId.Should().BeEmpty();
		result.UserId.Should().BeEmpty();
		result.Email.Should().BeEmpty();
		result.Roles.Should().BeEmpty();

	}

}