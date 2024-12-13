// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserDtoMapperTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserDtoMapper))]
public class UserDtoMapperTests
{
	[Fact]
	public void MapToUserDto_ValidUser_ReturnsUserDto()
	{
		// Arrange
		var user = new User
		{
			Id = ObjectId.GenerateNewId(),
			FirstName = "John",
			LastName = "Doe",
			FullName = "John Doe",
			Email = "john.doe@test.com",
			Roles = ["Admin", "User"]
		};

		// Act
		var result = user.MapToUserDto();

		// Assert
		result.Id.Should().Be(user.Id);
		result.FirstName.Should().Be(user.FirstName);
		result.LastName.Should().Be(user.LastName);
		result.FullName.Should().Be(user.FullName);
		result.Email.Should().Be(user.Email);
		result.Roles.Should().BeEquivalentTo(user.Roles);
	}

	[Fact]
	public void MapToUser_ValidUserDto_ReturnsUser()
	{
		// Arrange
		var userDto = new UserDto
		{
			Id = ObjectId.GenerateNewId(),
			FirstName = "John",
			LastName = "Doe",
			FullName = "John Doe",
			Email = "john.doe@test.com",
			Roles = ["Admin", "User"]
		};

		// Act
		var result = userDto.MapToUser();

		// Assert
		result.Id.Should().Be(userDto.Id);
		result.FirstName.Should().Be(userDto.FirstName);
		result.LastName.Should().Be(userDto.LastName);
		result.FullName.Should().Be(userDto.FullName);
		result.Email.Should().Be(userDto.Email);
		result.Roles.Should().BeEquivalentTo(userDto.Roles);
	}
}