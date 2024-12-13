// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakeUserInfo class
/// </summary>
public static class FakeUserInfo
{
	/// <summary>
	///   Gets a new user.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>UserModel</returns>
	public static UserInfo GetNewUserInfo(bool keepId = false, bool useSeed = false)
	{
		var userInfo = FakeData(useSeed);

		if (!keepId)
		{
			userInfo.Id = ObjectId.Empty;
		}

		return userInfo;
	}

	/// <summary>
	///   Gets a list of users.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of UserModels</returns>
	public static List<UserInfo> GetUserInfos(int numberRequested, bool useSeed = false)
	{
		var usersInfos = new List<UserInfo>();

		for (var i = 0; i < numberRequested; i++)
		{
			usersInfos.Add(FakeData(useSeed));
		}

		return usersInfos;
	}

	/// <summary>
	///   Generates a fake user.
	/// </summary>
	/// <param name="useSeed">bool whether to use a seed other than 0</param>
	/// <returns>A Faker UserModel</returns>
	private static UserInfo FakeData(bool useSeed = false)
	{
		var fakerData = new Faker<UserInfo>()
			.RuleFor(x => x.Id, ObjectId.GenerateNewId())
			.RuleFor(x => x.Name, f => f.Name.FullName())
			.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
			.RuleFor(x => x.Roles, f => [f.Random.Enum<Roles>().ToString()]);

		switch (useSeed)
		{
			case true:
				{
					const int seed = 621;
					return fakerData.UseSeed(seed).Generate();
				}
			default:
				return fakerData.UseSeed(0).Generate();
		}
	}
}