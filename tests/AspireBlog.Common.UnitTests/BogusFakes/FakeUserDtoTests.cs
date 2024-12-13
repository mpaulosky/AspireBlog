// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserDto))]
public class FakeUserDtoTests
{
	
	[Fact(DisplayName = "GetNewUserDto Should Return User Without Id When KeepId Is False")]
	public void GetNewUserDto_Should_Return_User_Without_Id_When_KeepId_Is_False()
	{
		
		// Act
		var user = FakeUserDto.GetNewUserDto(keepId: false);

		// Assert
		user.Id.Should().Be(ObjectId.Empty);
		
	}

	[Fact(DisplayName = "GetNewUserDto Should Return User With Id When KeepId Is True")]
	public void GetNewUserDto_Should_Return_User_With_Id_When_KeepId_Is_True()
	{
		
		// Act
		var user = FakeUserDto.GetNewUserDto(keepId: true);

		// Assert
		user.Id.Should().NotBe(ObjectId.Empty);
		
	}

	[Fact(DisplayName = "GetNewUserDto Should Return different User When UseSeed Is False")]
	public void GetNewUserDto_Should_Return_Different_User_When_UseSeed_Is_False()
	{

		// Act
		var user1 = FakeUserDto.GetNewUserDto(useSeed: false);
		var user2 = FakeUserDto.GetNewUserDto(useSeed: false);

		// Assert

		user1.Id.Should().Be(ObjectId.Empty);
		user1.FirstName.Should().NotBeEquivalentTo(user2.FirstName);
		user1.LastName.Should().NotBeEquivalentTo(user2.LastName);
		user1.FullName.Should().NotBeEquivalentTo(user2.FullName);
		user1.Email.Should().NotBeEquivalentTo(user2.Email);
		
	}

	[Fact(DisplayName = "GetNewUserDto Should Return Same User When UseSeed Is True")]
	public void GetNewUserDto_Should_Return_Same_User_When_UseSeed_Is_True()
	{
		// Act
		var user1 = FakeUserDto.GetNewUserDto(useSeed: true);
		var user2 = FakeUserDto.GetNewUserDto(useSeed: true);

		// Assert
		user1.Should().BeEquivalentTo(user2);
	}

	[Fact(DisplayName = "GetUserDtos Should Return List Of Users With Correct Count")]
	public void GetUserDtos_Should_Return_List_Of_Users_With_Correct_Count()
	{
		// Arrange
		const int numberRequested = 5;

		// Act
		var users = FakeUserDto.GetUserDtos(numberRequested, useSeed: false);

		// Assert
		users.Should().HaveCount(numberRequested);
	}

	[Theory(DisplayName = "GetUserDtos Should Return Different Users When UseSeed Is False")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	public void GetUserDtos_Should_Return_Different_Users_When_UseSeed_Is_False(int countRequested, bool useSeed)
	{
		// Act
		var users = FakeUserDto.GetUserDtos(countRequested, useSeed);

		// Assert
		foreach (var user in users)
		{
			user.Id.Should().NotBe(ObjectId.Empty);
			user.FirstName.Should().NotBeNull();
			user.LastName.Should().NotBeNull();
			user.FullName.Should().NotBeNull();
			user.Email.Should().NotBeNull();
		}
	}

	[Theory(DisplayName = "GetUserDtos Should Return Same Users When UseSeed Is True")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetUserDtos_Should_Return_Same_Users_When_UseSeed_Is_True(int countRequested, bool useSeed)
	{
		
		// Act
		var users1 = FakeUserDto.GetUserDtos(countRequested, useSeed);
		var users2 = FakeUserDto.GetUserDtos(countRequested, useSeed);

		// Assert
		for (int i = 0; i < users1.Count; i++)
		{
			
			users1[i].Id.Should().NotBeSameAs(users2[i].Id);
			users1[i].FirstName.Should().BeEquivalentTo(users2[i].FirstName);
			users1[i].LastName.Should().BeEquivalentTo(users2[i].LastName);
			users1[i].FullName.Should().BeEquivalentTo(users2[i].FullName);
			users1[i].Email.Should().BeEquivalentTo(users2[i].Email);
			
		}
		
	}
}