// set

namespace AspireBlog.Abstractions.BogusFakes;

/// <summary>
///   Tests for FakeUserInfo class
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfo))]
public class FakeUserInfoTests
{
	[Fact]
	public void GetNewUserInfo_Should_Return_UserInfo_With_Default_Id()
	{
		// Act
		UserInfo result = FakeUserInfo.GetNewUserInfo();

		// Assert
		result.UserId.Should().Be(string.Empty);
	}

	[Fact]
	public void GetNewUserInfo_Should_Return_UserInfo_With_Generated_Id_When_KeepId_Is_True()
	{
		// Act
		UserInfo result = FakeUserInfo.GetNewUserInfo(true);

		// Assert
		result.UserId.Should().NotBeEmpty();
	}

	[Fact]
	public void GetUserInfos_Should_Return_List_Of_UserInfos()
	{
		// Arrange
		const int numberRequested = 5;

		// Act
		List<UserInfo> result = FakeUserInfo.GetUserInfos(numberRequested);

		// Assert
		result.Should().HaveCount(numberRequested);
	}

	[Fact]
	public void FakeData_Should_Return_UserInfo_With_Valid_Properties()
	{
		// Act
		UserInfo result = FakeUserInfo.GetNewUserInfo();

		// Assert
		result.Name.Should().NotBeNullOrEmpty();
		result.Email.Should().NotBeNullOrEmpty();
		result.Roles.Should().NotBeNull();
	}
}