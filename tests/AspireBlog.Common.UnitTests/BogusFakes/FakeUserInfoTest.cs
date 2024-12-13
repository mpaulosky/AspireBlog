// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserInfoTest.cs
// Author :        Matthew Paulosky
// Company :       mpaulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

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
		var result = FakeUserInfo.GetNewUserInfo();

		// Assert
		result.Id.Should().Be(ObjectId.Empty);
		
	}

	[Fact]
	public void GetNewUserInfo_Should_Return_UserInfo_With_Generated_Id_When_KeepId_Is_True()
	{
		
		// Act
		var result = FakeUserInfo.GetNewUserInfo(keepId: true);

		// Assert
		result.Id.Should().NotBe(ObjectId.Empty);
		
	}

	[Fact]
	public void GetUserInfos_Should_Return_List_Of_UserInfos()
	{
		
		// Arrange
		const int numberRequested = 5;

		// Act
		var result = FakeUserInfo.GetUserInfos(numberRequested);

		// Assert
		result.Should().HaveCount(numberRequested);
		
	}

	[Fact]
	public void FakeData_Should_Return_UserInfo_With_Valid_Properties()
	{
		
		// Act
		var result = FakeUserInfo.GetNewUserInfo();

		// Assert
		result.Name.Should().NotBeNullOrEmpty();
		result.Email.Should().NotBeNullOrEmpty();
		result.Roles.Should().NotBeNull();
		
	}
	
}