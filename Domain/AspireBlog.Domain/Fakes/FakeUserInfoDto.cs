// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeUserInfoDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Fakes;

/// <summary>
/// Provides methods to generate fake data for the <see cref="UserInfoDto"/> class.
/// </summary>
public static class FakeUserInfoDto
{

	/// <summary>
	/// Generates a new fake <see cref="UserInfoDto"/> object.
	/// </summary>
	/// <param name="useSeed">Determines whether a fixed seed should be used for consistent outputs.</param>
	/// <returns>A single fake <see cref="UserInfoDto"/> object.</returns>
	public static UserInfoDto GetNewUserInfoDto(bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate();

	}

	/// <summary>
	/// Generates a list of fake <see cref="UserInfoDto"/> objects.
	/// </summary>
	/// <param name="numberRequested">The number of <see cref="UserInfoDto"/> objects to generate.</param>
	/// <param name="useSeed">Determines whether a fixed seed should be used for consistent outputs.</param>
	/// <returns>A list of fake <see cref="UserInfoDto"/> objects.</returns>
	public static List<UserInfoDto> GetUserInfoDtos(int numberRequested, bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate(numberRequested);

	}

	/// <summary>
	/// Configures a Faker instance to generate fake <see cref="UserInfoDto"/> objects.
	/// </summary>
	/// <param name="useSeed">Determines whether a fixed seed should be used for consistent outputs.</param>
	/// <returns>A configured <see cref="Faker{T}"/> instance for <see cref="UserInfoDto"/> objects.</returns>
	internal static Faker<UserInfoDto> GenerateFake(bool useSeed = false)
	{

		const int seed = 621;

		var fake = new Faker<UserInfoDto>()
				.RuleFor(x => x.UserId, _ => ObjectId.GenerateNewId().ToString())
				.RuleFor(x => x.Name, f => f.Name.FullName())
				.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
				.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);

		return useSeed ? fake.UseSeed(seed) : fake;

	}

}