// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     test.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserModelMapper))]
public class UserModelMapperTests
{
	
	[Fact]
	public void MapToUserModel_Valid_User_Info_Returns_UserModel()
	{
		
		// Arrange
		var userInfo = new UserInfo
		{
			Id = ObjectId.GenerateNewId(),
			Email = "test@example.com",
			Name = "Test User",
			Roles = ["Admin", "User"]
		};

		// Act
		var result = userInfo.MapToUserModel();

		// Assert
		result.Id.Should().Be(userInfo.Id);
		result.Email.Should().Be(userInfo.Email);
		result.Name.Should().Be(userInfo.Name);
		result.Roles.Should().BeEquivalentTo(userInfo.Roles);
		
	}

	[Fact]
	public void MapToUserModel_Valid_UserModelDto_Returns_UserModel()
	{
		// Arrange
		var userModelDto = new UserModelDto
		{
			Id = ObjectId.GenerateNewId(),
			Email = "test@example.com",
			Name = "Test User",
			Roles = ["Admin", "User"]
		};

		// Act
		var result = userModelDto.MapToUserModel();

		// Assert
		result.Id.Should().Be(userModelDto.Id);
		result.Email.Should().Be(userModelDto.Email);
		result.Name.Should().Be(userModelDto.Name);
		result.Roles.Should().BeEquivalentTo(userModelDto.Roles);
		
	}
	
}