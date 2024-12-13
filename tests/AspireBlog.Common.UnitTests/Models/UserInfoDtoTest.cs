// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfoDtoTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfoDto))]
public class UserInfoDtoTest
{
	
		[Fact]
		public void UserInfoDto_Should_Have_Default_Values()
		{
			// Arrange & Act
			var userInfoDto = new UserInfoDto
			{
				Id = default,
				Name = null,
				Email = null,
				Roles =
				[
				]
			};

			// Assert
			userInfoDto.Id.Should().Be(ObjectId.Empty);
			userInfoDto.Name.Should().BeNull();
			userInfoDto.Email.Should().BeNull();
			userInfoDto.Roles.Should().BeEmpty();
		}

		[Fact]
		public void UserInfoDto_Should_Set_Properties_Correctly()
		{
			// Arrange
			var id = new ObjectId("507f1f77bcf86cd799439011");
			const string name = "John Doe";
			const string email = "john.doe@example.com";
			var roles = new[] { "Admin", "User" };

			// Act
			var userInfoDto = new UserInfoDto
			{
				Id = id,
				Name = name,
				Email = email,
				Roles = roles
			};

			// Assert
			userInfoDto.Id.Should().Be(id);
			userInfoDto.Name.Should().Be(name);
			userInfoDto.Email.Should().Be(email);
			userInfoDto.Roles.Should().BeEquivalentTo(roles);
		}
		
}