// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPostDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Fakes;

public static class FakeBlogPostDto
{

	/// <summary>
	/// Creates a new instance of <see cref="BlogPostDto"/> with fake data.
	/// </summary>
	/// <param name="useSeed">Specifies whether to use a seed for deterministic results.</param>
	/// <returns>A new instance of <see cref="BlogPostDto"/> with populated fake data.</returns>
	public static BlogPostDto GetNewBlogPostDto(bool useSeed = false)
	{
	
		return GenerateFake(useSeed).Generate();
	
	}

	/// <summary>
	/// Generates a list of <see cref="BlogPostDto"/> objects with fake data.
	/// </summary>
	/// <param name="numberRequested">The number of <see cref="BlogPostDto"/> objects to generate.</param>
	/// <param name="useSeed">Specifies whether to use a seed for deterministic results.</param>
	/// <returns>A list of <see cref="BlogPostDto"/> objects with populated fake data.</returns>
	public static List<BlogPostDto> GetBlogPostDtos(int numberRequested, bool useSeed = false)
	{
	
		return GenerateFake(useSeed).Generate(numberRequested);
	
	}


	/// <summary>
	/// Generates a configured <see cref="Faker{T}"/> for creating <see cref="BlogPostDto"/> objects with fake data.
	/// </summary>
	/// <param name="useSeed">Specifies whether to use a seed for deterministic results.</param>
	/// <returns>
	/// A <see cref="Faker{T}"/> instance configured to generate fake <see cref="BlogPostDto"/> objects.
	/// </returns>
	internal static Faker<BlogPostDto> GenerateFake(bool useSeed = false)
	{
	
		const int seed = 621;
	
		var fake = new Faker<BlogPostDto>()
				.RuleFor(f => f.Title, f => f.Lorem.Sentence())
				.RuleFor(x => x.Slug, (_, x) => x.Title.GetSlug())
				.RuleFor(f => f.CreatedOn, f => DateOnly.FromDateTime(f.Date.Recent(2)))
				.RuleFor(f => f.Content, f => f.Lorem.Paragraph())
				.RuleFor(f => f.IsPublished, f => f.Random.Bool(0.1f))
				.RuleFor(x => x.PublishedOn, (f, x) => x.IsPublished ? DateOnly.FromDateTime(f.Date.Recent(2)) : null)
				.RuleFor(f => f.ModifiedOn, f => DateOnly.FromDateTime(f.Date.Recent(2)))
				.RuleFor(f => f.Introduction, f => f.Lorem.Sentence())
				.RuleFor(f => f.Category, FakeCategoryDto.GetNewCategoryDto(true))
				.RuleFor(f => f.Author,
						(_, x) => x.IsPublished ? FakeUserInfoDto.GetNewUserInfoDto(true) : UserInfoDto.Empty);
	
		return useSeed ? fake.UseSeed(seed) : fake;
	
	}

}