// set

namespace AspireBlog.Abstractions.Models;

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
			UserId = string.Empty,
			Name = string.Empty,
			Email = null,
			Roles =
			[
			]
		};

		// Assert
		userInfoDto.UserId.Should().Be(string.Empty);
		userInfoDto.Name.Should().Be(string.Empty);
		userInfoDto.Email.Should().BeNull();
		userInfoDto.Roles.Should().BeEmpty();
	}

	[Fact]
	public void UserInfoDto_Should_Set_Properties_Correctly()
	{
		// Arrange
		string id = new("507f1f77bcf86cd799439011");
		const string name = "John Doe";
		const string email = "john.doe@example.com";
		string[] roles = new[] { "Admin", "User" };

		// Act
		var userInfoDto = new UserInfoDto { UserId = id, Name = name, Email = email, Roles = roles };

		// Assert
		userInfoDto.UserId.Should().Be(id);
		userInfoDto.Name.Should().Be(name);
		userInfoDto.Email.Should().Be(email);
		userInfoDto.Roles.Should().BeEquivalentTo(roles);
	}
}