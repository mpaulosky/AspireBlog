// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategory.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Fakes;

public class FakeCategory
{

	public static Category GetNewCategory(bool keepId = false, bool useSeed = false)
	{

		const int count = 1;

		return FakeData(count, keepId, useSeed).First();

	}

	public static List<Category> GetCategoriesDto(int numberRequested, bool keepId = false, bool useSeed = false)
	{

		return FakeData(numberRequested, true, useSeed);

	}

	private static List<Category> FakeData(int count, bool keepId = false , bool useSeed = false)
	{

		const int seed = 621;

		var faker = new Faker<Category>()
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
				.RuleFor(x => x.Slug, (f, x) => keepId ? string.Empty : x.CategoryName.GetSlug());

		return useSeed ? faker.Generate(count) : faker.UseSeed(seed).Generate(count);

	}

}