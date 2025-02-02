// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeCategory.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Fakes;

/// <summary>
/// Provides fake data generation methods for the <see cref="Category"/> entity.
/// </summary>
public class FakeCategory
{

	/// <summary>
	/// Generates a new fake <see cref="Category"/> object.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A single fake <see cref="Category"/> object.</returns>
	public static Category GetNewCategory(bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate();

	}

	/// <summary>
	/// Generates a list of fake <see cref="Category"/> objects.
	/// </summary>
	/// <param name="numberRequested">The number of <see cref="Category"/> objects to generate.</param>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A list of fake <see cref="Category"/> objects.</returns>
	public static List<Category> GetCategories(int numberRequested, bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate(numberRequested);

	}

	/// <summary>
	/// Generates a Faker Category instance configured to generate fake Category objects.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A configured Faker Category instance.</returns>
	internal static Faker<Category> GenerateFake(bool useSeed = false)
	{

		const int seed = 621;

		var fake = new Faker<Category>()
				.RuleFor(x => x.CategoryName, f => f.Commerce.ProductName())
				.RuleFor(x => x.Slug, (f, x) => x.CategoryName.GetSlug());

		return useSeed ? fake.UseSeed(seed) : fake;

	}

}