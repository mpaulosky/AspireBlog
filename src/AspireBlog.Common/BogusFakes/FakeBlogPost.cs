// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPost.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
///   FakePost class
/// </summary>
public static class FakeBlogPost
{
	/// <summary>
	///   Gets a new BlogPost.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>BlogPost</returns>
	public static BlogPost GetNewBlogPost(bool keepId = false, bool useSeed = false)
	{
		var post = Guard.Against.Null(FakeData(useSeed), nameof(FakeData));

		if (!keepId)
		{
			post.Id = ObjectId.Empty;
		}
		
		post.IsPublished = false;
		post.PublishedOn = null;

		return post;
	}

	/// <summary>
	///   Gets a list of posts.
	/// </summary>
	/// <param name="numberRequested">The number of posts.</param>
	/// <param name="useSeed">bool whether to use a seed other than 0</param>
	/// <returns>A List of BlogPosts</returns>
	public static List<BlogPost> GetBlogPosts(int numberRequested, bool useSeed)
	{
		var posts = new List<BlogPost>();

		for (var i = 0; i < numberRequested; i++)
		{
			posts.Add(Guard.Against.Null(FakeData(useSeed), nameof(FakeData)));
		}

		return posts;
	}

	/// <summary>
	///   Generates a fake post.
	/// </summary>
	/// <param name="useSeed">If true use seed to generate the same data each request</param>
	/// <returns>A Faker BlogPost</returns>
	private static BlogPost FakeData(bool useSeed)
	{
		var fakerData = new Faker<BlogPost>()
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