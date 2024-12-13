// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakeUserDto class
/// </summary>
public static class FakeUserDto
{
	/// <summary>
	///   Gets a new user.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>UserDto</returns>
	public static UserDto GetNewUserDto(bool keepId = false, bool useSeed = false)
	{
		var userDto = FakeData(useSeed);

		if (!keepId)
		{
			userDto.Id = ObjectId.Empty;
		}

		return userDto;
	}

	/// <summary>
	///   Gets a list of userDto.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of UserDtos</returns>
	public static List<UserDto> GetUserDtos(int numberRequested, bool useSeed = false)
	{
		var userDtos = new List<UserDto>();

		for (var i = 0; i < numberRequested; i++)
		{
			userDtos.Add(FakeData(useSeed));
		}

		return userDtos;
	}

	/// <summary>
	///   Generates a fake user.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker UserDto</returns>
	private static UserDto FakeData(bool useSeed = false)
	{
		var fakerData = new Faker<UserDto>()
			.RuleFor(x => x.Id, ObjectId.GenerateNewId())
			.RuleFor(x => x.FirstName, f => f.Name.FirstName())
			.RuleFor(x => x.LastName, f => f.Name.LastName())
			.RuleFor(x => x.FullName, (f, user) => $"{user.FirstName} {user.LastName}")
			.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
			.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);
		
		if (useSeed)
		{
			const int seed = 621;
			return fakerData.UseSeed(seed).Generate();
		}
		else
		{
			return fakerData.Generate();
		}
	}
}