// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoFakeDataTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace

namespace AspireBlog.Domain.Fakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeUserInfo))]
public class FakeUserInfoFakeDataTests
{

	[Theory]
	[InlineData(true, 3)]
	[InlineData(false, 3)]
	public void FakeData_WithUseSeed_ShouldReturnAUserInfo(bool useSeed, int count)
	{

		// Arrange
		var expected = FakeUserInfo.GenerateFake(useSeed).Generate(count);

		// Act
		var result = FakeUserInfo.GenerateFake(useSeed).Generate(count);

		// Assert
		if (useSeed)
		{
			result.Should().BeEquivalentTo(expected, options => options.Excluding(x => x.UserId));
		}
		else
		{
			result.Should().NotBeEquivalentTo(expected);
		}

	}

}