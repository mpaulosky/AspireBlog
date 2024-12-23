// set

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
			UserId = string.Empty,
			Name = string.Empty,
			Email = null,
			Roles =
			[
			]
		};

		// Assert
		userInfo.UserId.Should().Be(string.Empty);
		userInfo.Name.Should().Be(string.Empty);
		userInfo.Email.Should().BeNull();
		userInfo.Roles.Should().BeEmpty();
	}

	[Fact]
	public void UserInfo_Should_Set_Properties_Correctly()
	{
		// Arrange
		string id = new("507f1f77bcf86cd799439011");
		const string name = "John Doe";
		const string email = "john.doe@example.com";
		string[] roles = new[] { "Admin", "User" };

		// Act
		var userInfo = new UserInfo { UserId = id, Name = name, Email = email, Roles = roles };

		// Assert
		userInfo.UserId.Should().Be(id);
		userInfo.Name.Should().Be(name);
		userInfo.Email.Should().Be(email);
		userInfo.Roles.Should().BeEquivalentTo(roles);
	}
}