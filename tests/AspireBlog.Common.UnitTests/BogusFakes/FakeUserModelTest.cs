// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserModelTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserModel))]
public class FakeUserModelTest
{
	
	[Fact]
	public void GetNewUser_Should_Return_UserModel_With_Default_Id()
	{
		
		// Act
		var result = FakeUserModel.GetNewUser();

		// Assert
		result.Id.Should().Be(ObjectId.Empty);
		
	}
	
	[Fact]
	public void GetNewUser_Should_Return_UserModel_With_Generated_Id_When_KeepId_Is_True()
	{
		
		// Act
		var result = FakeUserModel.GetNewUser(keepId: true);

		// Assert
		result.Id.Should().NotBe(ObjectId.Empty);
		
	}
	
	[Fact]
	public void GetUsers_Should_Return_List_Of_UserModels()
	{
		
		// Arrange
		const int numberRequested = 5;

		// Act
		var result = FakeUserModel.GetUsers(numberRequested);

		// Assert
		result.Should().HaveCount(numberRequested);
		
	}
	
	[Fact]
	public void FakeData_Should_Return_UserModel_With_Valid_Properties()
	{
		
		// Act
		var result = FakeUserModel.GetNewUser();

		// Assert
		result.Id.Should().Be(ObjectId.Empty);
		result.Name.Should().NotBeNullOrEmpty();
		result.Email.Should().NotBeNullOrEmpty();
		result.Roles.Should().NotBeNull();
		
	}
	
	[Fact]
	public void FakeData_Should_Return_UserModel_With_KeepId_And_UseSeed()
	{
		
		// Act
		var result = FakeUserModel.GetNewUser(true, true);
		var result2 = FakeUserModel.GetNewUser(true, true);

		// Assert
		result.Id.Should().NotBe(ObjectId.Empty);
		result.Name.Should().BeEquivalentTo(result2.Name);
		result.Email.Should().BeEquivalentTo(result2.Email);
		result.Roles.Should().NotBeNull();
		
	}

	[Theory(DisplayName = "GetUsers Should Return Different Users When UseSeed Is False")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	public void GetUsers_Should_Return_Different_Users_When_UseSeed_Is_False(int countRequested, bool useSeed)
	{
		
		// Act
		var users1 = FakeUserModel.GetUsers(countRequested, useSeed);
		var users2 = FakeUserModel.GetUsers(countRequested, useSeed);

		// Assert
		users1.Should().NotBeEquivalentTo(users2);
		
	}

	[Theory(DisplayName = "GetUsers Should Return Same Users When UseSeed Is True")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetUsers_Should_Return_Same_Users_When_UseSeed_Is_True(int countRequested, bool useSeed)
	{
		
		// Act
		var users1 = FakeUserModel.GetUsers(countRequested, useSeed);
		var users2 = FakeUserModel.GetUsers(countRequested, useSeed);

		// Assert
		users1.Should().NotBeEquivalentTo(users2);
		
	}

}