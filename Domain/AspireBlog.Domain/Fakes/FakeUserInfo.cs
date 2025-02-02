// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Fakes;

/// <summary>
/// Provides fake data generation methods for the <see cref="UserInfo"/> entity.
/// </summary>
public static class FakeUserInfo
{

	/// <summary>
	/// Generates a new fake <see cref="UserInfo"/> object.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A single fake <see cref="UserInfo"/> object.</returns>
	public static UserInfo GetNewUserInfo(bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate();

	}

	/// <summary>
	/// Generates a list of fake <see cref="UserInfo"/> objects.
	/// </summary>
	/// <param name="numberRequested">The number of <see cref="UserInfo"/> objects to generate.</param>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A list of fake <see cref="UserInfo"/> objects.</returns>
	public static List<UserInfo> GetUserInfos(int numberRequested, bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate(numberRequested);

	}

	/// <summary>
	/// Generates a configured <see cref="Faker{T}"/> for creating fake <see cref="UserInfo"/> objects.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A configured <see cref="Faker{UserInfo}"/> instance.</returns>
	internal static Faker<UserInfo> GenerateFake(bool useSeed = false)
	{

		const int seed = 621;

		var fake = new Faker<UserInfo>()
				.RuleFor(x => x.UserId, ObjectId.GenerateNewId().ToString())
				.RuleFor(x => x.Name, f => f.Name.FullName())
				.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
				.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);

		return useSeed ? fake.UseSeed(seed) : fake;

	}

}