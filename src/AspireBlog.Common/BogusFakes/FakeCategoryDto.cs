// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeCategoryDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

public static class FakeCategoryDto
{
	/// <summary>
	///   Gets a new categoryDto.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>CategoryDto</returns>
	public static CategoryDto GetNewCategoryDto(bool keepId = false, bool useSeed = false)
	{
		
		var categoryDto = FakeData(useSeed);
		
		if (!keepId)
		{
			categoryDto.Id = ObjectId.Empty;
		}
		
		categoryDto.IsArchived = false;
		categoryDto.ArchivedBy = null;
		
		return categoryDto;
		
	}

	/// <summary>
	///   Gets a list of categoryDto.
	/// </summary>
	/// <param name="numberRequested">The number of users.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of CategoryDto</returns>
	public static List<CategoryDto> GetCategoryDtos(int numberRequested, bool useSeed = false)
	{
		
		var categories = new List<CategoryDto>();

		for (var i = 0; i < numberRequested; i++)
		{
			categories.Add(FakeData(useSeed));
		}

		return categories;

	}

	/// <summary>
	///   Generates a fake categoryDto.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker CategoryDto</returns>
	public static CategoryDto FakeData(bool useSeed = false)
	{
		var fakerData = new Faker<CategoryDto>()
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