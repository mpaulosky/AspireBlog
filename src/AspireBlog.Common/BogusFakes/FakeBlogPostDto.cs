// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakePostDto class
/// </summary>
public static class FakeBlogPostDto
{
	/// <summary>
	///   Gets a new BlogPostDto
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>BlogPostDto</returns>
	public static BlogPostDto GetNewBlogPostDto(bool keepId = false, bool useSeed = false)
	{
		var postDto = FakeData(useSeed);

		if (!keepId)
		{
			postDto.Id = ObjectId.Empty;
		}

		return postDto;
	}

	/// <summary>
	///   Gets a list of BlogPostDto.
	/// </summary>
	/// <param name="numberRequested">The number of posts.</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A List of BlogPostDto</returns>
	public static List<BlogPostDto> GetBlogPostDtos(int numberRequested, bool useSeed = false)
	{
		var postsDto = new List<BlogPostDto>();

		for (var i = 0; i < numberRequested; i++)
		{
			postsDto.Add(FakeData(useSeed));
		}

		foreach (var postDto in postsDto.Where(p => p.IsPublished == false))
		{
			postDto.PublishedOn = null;
		}

		return postsDto;
	}

	/// <summary>
	///   Generates a fake postDto.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker PostBlogPost</returns>
	public static BlogPostDto FakeData(bool useSeed)
	{
		var fakerData = new Faker<BlogPostDto>()
			.RuleFor(x => x.Id, ObjectId.GenerateNewId())
			.RuleFor(f => f.Title, f => f.Lorem.Sentence())
			.RuleFor(f => f.ImageUrl, f => f.Image.PicsumUrl())
			.RuleFor(f => f.Author, FakeUserDto.GetNewUserDto(true, true))
			.RuleFor(f => f.CreatedOn, f => f.Date.Past())
			.RuleFor(f => f.Content, f => f.Lorem.Paragraph())
			.RuleFor(f => f.IsPublished, f => f.Random.Bool(0.1f))
			.RuleFor(x => x.PublishedOn, (f, x) => x.IsPublished ? f.Date.Past() : null)
			.RuleFor(f => f.ModifiedOn, f => f.Date.Recent())
			.RuleFor(f => f.Introduction, f => f.Lorem.Sentence())
			.RuleFor(f => f.Category, FakeCategoryDto.GetNewCategoryDto(true, true));


		
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