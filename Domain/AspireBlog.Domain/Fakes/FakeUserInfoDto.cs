// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Fakes;

public static class FakeUserInfoDto
{

	public static UserInfoDto GetNewUserInfoDto(bool keepId = false, bool useSeed = false)
	{

		const int count = 1;

		return FakeData(count, keepId, useSeed).First();

	}

	public static List<UserInfoDto> GetUserInfoDtos(int numberRequested, bool useSeed = false)
	{

		return FakeData(numberRequested, true, useSeed);

	}

	private static List<UserInfoDto> FakeData(int count, bool keepId = false , bool useSeed = false)
	{

		const int seed = 621;

		var faker = new Faker<UserInfoDto>()
				.RuleFor(x => x.UserId, _ => keepId ? ObjectId.Empty.ToString() : ObjectId.GenerateNewId().ToString())
				.RuleFor(x => x.Name, f => f.Name.FullName())
				.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
				.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);

		return useSeed ? faker.Generate(count) : faker.UseSeed(seed).Generate(count);

	}

}