// set

namespace AspireBlog.Abstractions.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUser))]
public class FakeUserTests
{
	[Fact(DisplayName = "GetNewUser Should Return User Without Id When KeepId Is False")]
	public void GetNewUser_Should_Return_User_Without_Id_When_KeepId_Is_False()
	{
		// Act
		User? user = FakeUser.GetNewUser();

		// Assert
		user.Id.Should().Be(ObjectId.Empty);
	}

	[Fact(DisplayName = "GetNewUser Should Return User With Id When KeepId Is True")]
	public void GetNewUser_Should_Return_User_With_Id_When_KeepId_Is_True()
	{
		// Act
		User? user = FakeUser.GetNewUser(true);

		// Assert
		user.Id.Should().NotBe(ObjectId.Empty);
	}

	[Fact(DisplayName = "GetNewUser Should Return Same User When UseSeed Is True")]
	public void GetNewUser_Should_Return_Same_User_When_UseSeed_Is_True()
	{
		// Act
		User? user1 = FakeUser.GetNewUser(useSeed: true);
		User? user2 = FakeUser.GetNewUser(useSeed: true);

		// Assert
		user1.Should().BeEquivalentTo(user2);
	}

	[Fact(DisplayName = "GetUserDtos Should Return List Of Users With Correct Count")]
	public void GetUserDtos_Should_Return_List_Of_Users_With_Correct_Count()
	{
		// Arrange
		const int numberRequested = 5;

		// Act
		List<User>? users = FakeUser.GetUserDtos(numberRequested);

		// Assert
		users.Should().HaveCount(numberRequested);
	}

	[Theory(DisplayName = "GetUserDtos Should Return Different Users When UseSeed Is False")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	public void GetUserDtos_Should_Return_Different_Users_When_UseSeed_Is_False(int countRequested, bool useSeed)
	{
		// Act
		List<User>? users1 = FakeUser.GetUserDtos(countRequested, useSeed);
		List<User>? users2 = FakeUser.GetUserDtos(countRequested, useSeed);

		// Assert
		users1.Should().NotBeEquivalentTo(users2);
	}

	[Theory(DisplayName = "GetUserDtos Should Return Same Users When UseSeed Is True")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetUserDtos_Should_Return_Same_Users_When_UseSeed_Is_True(int countRequested, bool useSeed)
	{
		// Act
		List<User>? users1 = FakeUser.GetUserDtos(countRequested, useSeed);
		List<User>? users2 = FakeUser.GetUserDtos(countRequested, useSeed);

		// Assert
		users1.Should().NotBeEquivalentTo(users2);
	}

	[Fact]
	public void FakeData_Should_Return_Valid_User()
	{
		// Act
		User? user = FakeUser.FakeData();

		// Assert
		user.Should().NotBeNull();
		user.FirstName.Should().NotBeNullOrEmpty();
		user.LastName.Should().NotBeNullOrEmpty();
		user.FullName.Should().Be($"{user.FirstName} {user.LastName}");
		user.Email.Should().Contain(user.FirstName, user.LastName);
		user.Roles.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public void FakeData_ShouldReturnDifferentUser_WhenUseSeedIsTrue()
	{
		// Act
		User? user1 = FakeUser.FakeData(true);
		User? user2 = FakeUser.FakeData(true);

		// Assert
		user1.Id.Should().NotBe(user2.Id);
		user1.FirstName.Should().BeEquivalentTo(user2.FirstName);
		user1.LastName.Should().BeEquivalentTo(user2.LastName);
		user1.FullName.Should().BeEquivalentTo(user2.FullName);
		user1.Email.Should().BeEquivalentTo(user2.Email);
	}

	[Fact]
	public void FakeData_Should_Return_Different_User_When_UseSeed_Is_False()
	{
		// Act
		User? user1 = FakeUser.FakeData();
		User? user2 = FakeUser.FakeData();

		// Assert
		user1.Id.Should().NotBeSameAs(user2.Id);
		user1.FirstName.Should().NotBeEquivalentTo(user2.FirstName);
		user1.LastName.Should().NotBeEquivalentTo(user2.LastName);
		user1.FullName.Should().NotBeEquivalentTo(user2.FullName);
		user1.Email.Should().NotBeEquivalentTo(user2.Email);
	}

	[Fact]
	public void FakeData_ShouldAssignDifferentIdsToDifferentUsers()
	{
		// Act
		User? user1 = FakeUser.FakeData();
		User? user2 = FakeUser.FakeData();

		// Assert
		user1.Id.Should().NotBe(user2.Id);
	}
}