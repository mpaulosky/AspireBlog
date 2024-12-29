// set

namespace AspireBlog.Abstractions.BogusFakes;

public class FakeUserInfoDto
{
	/// <summary>
	///   Gets a new userInfoDto.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>userInfoDto</returns>
	public static UserInfoDto UserInfoDto(bool keepId = false, bool useSeed = false)
	{
		UserInfoDto userInfoDto = FakeData(useSeed);

		if (!keepId)
		{
			userInfoDto.UserId = string.Empty;
		}

		return userInfoDto;
	}

	/// <summary>
	///   Gets a list of userInfoDto.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of UserInfoDto</returns>
	public static List<UserInfoDto> GetUserInfoDtos(int numberRequested, bool useSeed = false)
	{
		var usersInfoDtos = new List<UserInfoDto>();

		for (int i = 0; i < numberRequested; i++)
		{
			usersInfoDtos.Add(FakeData(useSeed));
		}

		return usersInfoDtos;
	}

	/// <summary>
	///   Generates a fake userInfoDto.
	/// </summary>
	/// <param name="useSeed">bool whether to use a seed other than 0</param>
	/// <returns>A Faker UserInfoDto</returns>
	private static UserInfoDto FakeData(bool useSeed = false)
	{
		Faker<UserInfoDto>? fakerData = new Faker<UserInfoDto>()
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