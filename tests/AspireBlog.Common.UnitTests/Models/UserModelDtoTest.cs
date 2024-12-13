// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserModelDtoTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserModelDto))]
public class UserModelDtoTest
{

	[Fact]
	public void UserModelDto_Should_Have_Default_Values()
	{
		
		// Arrange & Act
		var userModelDto = new UserModelDto();

		// Assert
		userModelDto.Id.Should().Be(ObjectId.Empty);
		userModelDto.Name.Should().BeNull();
		userModelDto.Email.Should().BeNull();
		userModelDto.Roles.Should().BeNull();
		
	}

	[Fact]
	public void UserModelDto_Should_Set_Properties_Correctly()
	{
		
		// Arrange
		var id = new ObjectId("507f1f77bcf86cd799439011");
		const string name = "John Doe";
		const string email = "john.doe@example.com";
		var roles = new[] { "Admin", "User" };

		// Act
		var userModelDto = new UserModelDto { Id = id, Name = name, Email = email, Roles = roles };

		// Assert
		userModelDto.Id.Should().Be(id);
		userModelDto.Name.Should().Be(name);
		userModelDto.Email.Should().Be(email);
		userModelDto.Roles.Should().BeEquivalentTo(roles);
		
	}
	
}