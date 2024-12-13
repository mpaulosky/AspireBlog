// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserModel.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakeUser class
/// </summary>
public static class FakeUserModel
{
	
	/// <summary>
	///   Gets a new user.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>UserModel</returns>
	public static UserModel GetNewUser(bool keepId = false, bool useSeed = false)
	{
		
		var user = FakeData(useSeed);

		if (!keepId)
		{
			user.Id = ObjectId.Empty;
		}

		return user;
		
	}

	/// <summary>
	///   Gets a list of users.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of UserModels</returns>
	public static List<UserModel> GetUsers(int numberRequested, bool useSeed = false)
	{
		
		var users = new List<UserModel>();

		for (var i = 0; i < numberRequested; i++)
		{
			users.Add(FakeData(useSeed));
		}

		return users;
		
	}

	/// <summary>
	///   Generates a fake user.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker UserModel</returns>
	private static UserModel FakeData(bool useSeed)
	{
		
		var fakerData = new Faker<UserModel>()
			.RuleFor(x => x.Id, ObjectId.GenerateNewId())
			.RuleFor(x => x.Name, f => f.Name.FullName())
			.RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
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