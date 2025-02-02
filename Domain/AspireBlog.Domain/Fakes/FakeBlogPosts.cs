// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPosts.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Fakes;

/// <summary>
/// Provides fake data generation methods for the <see cref="BlogPost"/> entity.
/// </summary>
public static class FakeBlogPosts
{

	/// <summary>
	/// Generates a new fake <see cref="BlogPost"/> object.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A single fake <see cref="BlogPost"/> object.</returns>
	public static BlogPost GetNewBlogPost(bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate();

	}

	/// <summary>
	/// Generates a list of fake <see cref="BlogPost"/> objects.
	/// </summary>
	/// <param name="numberRequested">The number of <see cref="BlogPost"/> objects to generate.</param>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A list of fake <see cref="BlogPost"/> objects.</returns>
	public static List<BlogPost> GetBlogPosts(int numberRequested, bool useSeed = false)
	{

		return GenerateFake(useSeed).Generate(numberRequested);

	}

	/// <summary>
	/// Generates a Faker instance configured to generate fake <see cref="BlogPost"/> objects.
	/// </summary>
	/// <param name="useSeed">Indicates whether to apply a fixed seed for deterministic results.</param>
	/// <returns>A configured Faker <see cref="BlogPost"/> instance.</returns>
	internal static Faker<BlogPost> GenerateFake(bool useSeed = false)
	{

		const int seed = 621;

		var fake = new Faker<BlogPost>()
				.RuleFor(f => f.Title, f => f.Lorem.Sentence())
				.RuleFor(x => x.Slug, (_, x) => x.Title.GetSlug())
				.RuleFor(f => f.CreatedOn, f => DateOnly.FromDateTime(f.Date.Recent()))
				.RuleFor(f => f.Content, f => f.Lorem.Paragraph())
				.RuleFor(f => f.IsPublished, f => f.Random.Bool())
				.RuleFor(x => x.PublishedOn, (f, x) => x.IsPublished ? DateOnly.FromDateTime(f.Date.Recent()) : null)
				.RuleFor(f => f.ModifiedOn, f => DateOnly.FromDateTime(f.Date.Recent()))
				.RuleFor(f => f.Introduction, f => f.Lorem.Sentence())
				.RuleFor(f => f.Category, FakeCategoryDto.GetNewCategoryDto(useSeed))
				.RuleFor(f => f.Author,
						(_, x) => x.IsPublished ? FakeUserInfoDto.GetNewUserInfoDto(useSeed) : UserInfoDto.Empty);

		return useSeed ? fake.UseSeed(seed) : fake;

	}

}