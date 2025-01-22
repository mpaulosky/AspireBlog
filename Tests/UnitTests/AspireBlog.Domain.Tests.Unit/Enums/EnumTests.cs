// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     EnumTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Enums;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(System.Enum))]
public class EnumTests
{

	[Theory]
	[InlineData(Gender.Male, 0)]
	[InlineData(Gender.Female, 1)]
	public void GenderEnum_ShouldHaveCorrectValues(Gender gender, int expectedValue)
	{
		((int)gender).Should().Be(expectedValue);
	}

	[Theory]
	[InlineData(Roles.Author, 0)]
	[InlineData(Roles.Admin, 1)]
	[InlineData(Roles.User, 2)]
	public void RolesEnum_ShouldHaveCorrectValues(Roles role, int expectedValue)
	{
		((int)role).Should().Be(expectedValue);
	}

	[Theory]
	[InlineData(CategoryNames.AspNetCore, 0)]
	[InlineData(CategoryNames.BlazorServer, 1)]
	[InlineData(CategoryNames.BlazorWasm, 2)]
	[InlineData(CategoryNames.EntityFrameworkCore, 3)]
	[InlineData(CategoryNames.NetMaui, 4)]
	[InlineData(CategoryNames.Other, 5)]
	public void CategoryNamesEnum_ShouldHaveCorrectValues(CategoryNames category, int expectedValue)
	{
		((int)category).Should().Be(expectedValue);
	}
}