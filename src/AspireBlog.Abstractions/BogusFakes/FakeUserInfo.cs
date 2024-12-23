// set

namespace AspireBlog.Abstractions.BogusFakes;

/// <summary>
///   FakeUserInfo class
/// </summary>
public static class FakeUserInfo
{
	/// <summary>
	///   Gets a new UserInfo.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>UserInfo</returns>
	public static UserInfo GetNewUserInfo(bool keepId = false, bool useSeed = false)
	{
		UserInfo userInfo = FakeData(useSeed);

		if (!keepId)
		{
			userInfo.UserId = string.Empty;
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

		for (int i = 0; i < numberRequested; i++)
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
		Faker<UserInfo>? fakerData = new Faker<UserInfo>()
			.RuleFor(x => x.UserId, ObjectId.GenerateNewId().ToString())
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