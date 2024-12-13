// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeCategory.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakeCategories class
/// </summary>
public static class FakeCategory
{
	
	/// <summary>
	///   Gets a new category.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>Category</returns>
	public static Category GetNewCategory(bool keepId = false, bool useSeed = false)
	{
		
		var category = FakeData(useSeed);

		if (!keepId)
		{
			category.Id = ObjectId.Empty;
		}
		
		category.IsArchived = false;
		category.ArchivedBy = null;

		return category;
		
	}

	/// <summary>
	///   Gets a list of categories.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">bool whether to use a seed other than 0</param>
	/// <returns>A List of Categories</returns>
	public static List<Category> GetCategories(int numberRequested, bool useSeed = false)
	{
		
		var categories = new List<Category>();

		for (var i = 0; i < numberRequested; i++)
		{
			categories.Add(FakeData(useSeed));
		}

		return categories;
		
	}

	/// <summary>
	///   Generates a fake category.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker Category</returns>
	public static Category FakeData(bool useSeed = false)
	{
		var fakerData = new Faker<Category>()
			.RuleFor(x => x.Id, ObjectId.GenerateNewId())
			.RuleFor(x => x.CategoryName, f =>
			{
				var category = f.PickRandom<CategoryNames>();
				return category switch
				{
					CategoryNames.AspNetCore => "ASP.NET Core",
					CategoryNames.BlazorServer => "Blazor Server",
					CategoryNames.BlazorWasm => "Blazor WASM",
					CategoryNames.EntityFrameworkCore => "Entity Framework Core (EF Core)",
					CategoryNames.NetMaui => ".NET MAUI",
					_ => "Other"
				};
			})
			.RuleFor(x => x.IsArchived, f => f.Random.Bool(0.1f))
			.RuleFor(x => x.ArchivedBy, (f, x) => x.IsArchived ? FakeUserDto.GetNewUserDto(true, true) : null);

		
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