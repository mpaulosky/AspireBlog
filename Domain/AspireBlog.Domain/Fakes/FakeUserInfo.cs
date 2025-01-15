// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Fakes;

public  static class FakeUserInfo
{

	public static UserInfo GetNewUserInfo(bool useSeed = false)
	{

		const int count = 1;

		return FakeData(count, useSeed).First();

	}

	public static List<UserInfo> GetCategories(int numberRequested, bool useSeed = false)
	{

		return FakeData(numberRequested, useSeed);

	}

	private static List<UserInfo> FakeData(int count,bool useSeed = false)
	{

		const int seed = 621;

		var faker = new Faker<UserInfo>()
				.RuleFor(x => x.UserId, ObjectId.GenerateNewId().ToString())
				.RuleFor(x => x.Name, f => f.Name.FullName())
				.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
				.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);

		return useSeed ? faker.Generate(count) : faker.UseSeed(seed).Generate(count);

	}

}