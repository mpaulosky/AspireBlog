// set

namespace AspireBlog.Abstractions.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserInfoDtoMapper))]
public class UserInfoDtoMapperTests
{
	[Fact]
	public void MapToUserInfo_Valid_User_Returns_UserInfo()
	{
		// Arrange
		var user = new User
		{
			Id = ObjectId.GenerateNewId(),
			Email = "test@example.com",
			FirstName = "Test",
			LastName = "User",
			FullName = "Test User",
			Roles = ["Admin", "User"]
		};

		// Act
		UserInfo result = user.MapToUserInfo();

		// Assert
		result.UserId.Should().Be(user.Id.ToString());
		result.Email.Should().Be(user.Email);
		result.Name.Should().Be(user.FullName);
		result.Roles.Should().BeEquivalentTo(user.Roles);
	}

	[Fact]
	public void MapToUser_Valid_UserDto_Returns_User()
	{
		// Arrange
		var userDto = new UserDto
		{
			Id = ObjectId.GenerateNewId(),
			Email = "test@example.com",
			FirstName = "Test",
			LastName = "User",
			FullName = "Test User",
			Roles = ["Admin", "User"]
		};

		// Act
		User result = userDto.MapToUser();

		// Assert
		result.Id.Should().Be(userDto.Id);
		result.Email.Should().Be(userDto.Email);
		result.FirstName.Should().Be(userDto.FirstName);
		result.LastName.Should().Be(userDto.LastName);
		result.FullName.Should().Be(userDto.FullName);
		result.Roles.Should().BeEquivalentTo(userDto.Roles);
	}
}