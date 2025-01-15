// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     FakeBlogPosts.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Fakes;

public static class FakeBlogPosts
{

	public static BlogPost GetNewBlogPost(bool keepId = false, bool useSeed = false)
	{

		const int count = 1;

		return FakeData(count, keepId, useSeed).First();

	}

	public static List<BlogPost> GetUserInfoDtos(int numberRequested, bool useSeed = false)
	{

		return FakeData(numberRequested, true, useSeed);

	}

	private static List<BlogPost> FakeData(int count, bool keepId = false , bool useSeed = false)
	{

			const int seed = 621;

		var faker = new Faker<BlogPost>()
				.RuleFor(f => f.Title, f => f.Lorem.Sentence())
				.RuleFor(x => x.Slug, (f, x) => keepId ? string.Empty : x.Title.GetSlug())
				.RuleFor(f => f.CreatedOn, f => f.Date.Past())
				.RuleFor(f => f.Content, f => f.Lorem.Paragraph())
				.RuleFor(f => f.IsPublished, f => f.Random.Bool(0.1f))
				.RuleFor(x => x.PublishedOn, (f, x) => x.IsPublished ? f.Date.Past() : DateTimeOffset.MinValue)
				.RuleFor(f => f.ModifiedOn, f => f.Date.Recent())
				.RuleFor(f => f.Introduction, f => f.Lorem.Sentence())
				.RuleFor(f => f.Category, FakeCategoryDto.GetNewCategoryDto(true, true))
				.RuleFor(f => f.Author, (f, x) => x.IsPublished ? UserInfoDto.Empty : FakeUserInfoDto.GetNewUserInfoDto(true, true));

		return useSeed ? faker.Generate(count) : faker.UseSeed(seed).Generate(count);

	}

}