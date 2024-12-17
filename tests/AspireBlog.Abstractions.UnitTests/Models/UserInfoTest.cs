// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfoTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions.UnitTests
// =============================================

namespace AspireBlog.Abstractions.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfo))]
public class UserInfoTest
{

	[Fact]
	public void UserInfo_Should_Have_Default_Values()
	{
		
		// Arrange & Act
		var userInfo = new UserInfo
		{
			Id = default,
			Name = null,
			Email = null,
			Roles =
			[
			]
		};

		// Assert
		userInfo.Id.Should().Be(ObjectId.Empty);
		userInfo.Name.Should().BeNull();
		userInfo.Email.Should().BeNull();
		userInfo.Roles.Should().BeEmpty();
		
	}

	[Fact]
	public void UserInfo_Should_Set_Properties_Correctly()
	{
		
		// Arrange
		var id = new ObjectId("507f1f77bcf86cd799439011");
		const string name = "John Doe";
		const string email = "john.doe@example.com";
		var roles = new[] { "Admin", "User" };

		// Act
		var userInfo = new UserInfoDto { Id = id, Name = name, Email = email, Roles = roles };

		// Assert
		userInfo.Id.Should().Be(id);
		userInfo.Name.Should().Be(name);
		userInfo.Email.Should().Be(email);
		userInfo.Roles.Should().BeEquivalentTo(roles);
		
	}
	
}