// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserDtoTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Models;
[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserDto))]
public class UserDtoTest
{
	
	[Fact]
	public void UserDto_Should_Have_Default_Values()
	{
		
		// Arrange & Act
		var userDto = new UserDto();

		// Assert
		userDto.Id.Should().Be(ObjectId.Empty);
		userDto.FirstName.Should().BeNull();
		userDto.LastName.Should().BeNull();
		userDto.FullName.Should().BeNull();
		userDto.Email.Should().BeNull();
		userDto.Roles.Should().BeNull();
		
	}

	[Fact]
	public void UserDto_Should_Set_Properties_Correctly()
	{
		
		// Arrange
		var id = new ObjectId("507f1f77bcf86cd799439011");
		const string firstName = "John";
		const string lastName = "Doe";
		const string fullName = "John Doe";
		const string email = "john.doe@example.com";
		var roles = new[] { "Admin", "User" };

		// Act
		var userDto = new UserDto
		{
			
			Id = id,
			FirstName = firstName,
			LastName = lastName,
			FullName = fullName,
			Email = email,
			Roles = roles
			
		};

		// Assert
		userDto.Id.Should().Be(id);
		userDto.FirstName.Should().Be(firstName);
		userDto.LastName.Should().Be(lastName);
		userDto.FullName.Should().Be(fullName);
		userDto.Email.Should().Be(email);
		userDto.Roles.Should().BeEquivalentTo(roles);
		
	}
	
}