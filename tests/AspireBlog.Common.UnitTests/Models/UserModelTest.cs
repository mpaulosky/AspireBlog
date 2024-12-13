// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserModelTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Models;

[TestSubject(typeof(UserModel))]
public class UserModelTests
{
	
	[Fact]
	public void UserModel_Should_Have_Default_Values()
	{
		// Arrange & Act
		var userModel = new UserModel();

		// Assert
		userModel.Id.Should().Be(ObjectId.Empty);
		userModel.Name.Should().BeNull();
		userModel.Email.Should().BeNull();
		userModel.Roles.Should().BeNull();
	}

	[Fact]
	public void UserModel_Should_Set_Properties_Correctly()
	{
		// Arrange
		var id = new ObjectId("507f1f77bcf86cd799439011");
		const string name = "John Doe";
		const string email = "john.doe@example.com";
		var roles = new[] { "Admin", "User" };

		// Act
		var userModel = new UserModel { Id = id, Name = name, Email = email, Roles = roles };

		// Assert
		userModel.Id.Should().Be(id);
		userModel.Name.Should().Be(name);
		userModel.Email.Should().Be(email);
		userModel.Roles.Should().BeEquivalentTo(roles);
	}
}