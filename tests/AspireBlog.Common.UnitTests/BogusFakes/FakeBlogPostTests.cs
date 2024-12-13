// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

/// <summary>
///   Unit tests for the FakeBlogPost class.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPost))]
public class FakeBlogPostTests
{
	/// <summary>
	///   Tests that GetNewBlogPost returns a BlogPost with an Id set to ObjectId.Empty
	///   and non-null properties when the keepId parameter is false.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPost GetNewBlogPost Test with keepId false")]
	public void GetNewBlogPost_Should_Return_BlogPost_Without_An_Id_When_KeepId_Is_False()
	{

		// Act
		var blogPost = FakeBlogPost.GetNewBlogPost(keepId: false, useSeed: false);

		// Assert
		blogPost.Id.Should().Be(ObjectId.Empty);
		blogPost.Title.Should().NotBeNull();
		blogPost.Slug.Should().NotBeNull();
		blogPost.Introduction.Should().NotBeNull();
		blogPost.Content.Should().NotBeNull();
		blogPost.CreatedOn.Should().NotBeNull();
		blogPost.ModifiedOn.Should().NotBeNull();
		blogPost.Author.Should().NotBeNull();
		blogPost.Category.Should().NotBeNull();
		blogPost.IsPublished.Should().Be(false);
		blogPost.PublishedOn.Should().BeNull();

	}

	/// <summary>
	///   Tests that GetNewBlogPost returns a BlogPost with a non-empty Id
	///   when the keepId parameter is true.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPost GetNewBlogPost Test with keepId true")]
	public void GetNewBlogPost_Should_Return_BlogPost_Id_When_KeepId_True()
	{
		
		// Act
		var blogPost = FakeBlogPost.GetNewBlogPost(keepId: true, useSeed: false);

		// Assert
		blogPost.Id.Should().NotBe(ObjectId.Empty);
		blogPost.Title.Should().NotBeNull();
		blogPost.Slug.Should().NotBeNull();
		blogPost.Introduction.Should().NotBeNull();
		blogPost.Content.Should().NotBeNull();
		blogPost.CreatedOn.Should().NotBeNull();
		blogPost.ModifiedOn.Should().NotBeNull();
		blogPost.Author.Should().NotBeNull();
		blogPost.Category.Should().NotBeNull();
		
	}

	/// <summary>
	///   Tests that GetNewBlogPost returns a BlogPost with an Id set to ObjectId.Empty
	///   and non-null properties when the keepId parameter is false.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPost GetNewBlogPost Test with keepId false and useSeed true")]
	public void GetNewBlogPost_Should_Return_BlogPost_Without_Id_When_When_KeepId_Is_False_And_UseSeed_Is_True()
	{

		// Act
		var blogPost = FakeBlogPost.GetNewBlogPost(keepId: false, useSeed: true);

		// Assert
		blogPost.Id.Should().Be(ObjectId.Empty);
		blogPost.Title.Should().NotBeNull();
		blogPost.Slug.Should().NotBeNull();
		blogPost.Introduction.Should().NotBeNull();
		blogPost.Content.Should().NotBeNull();
		blogPost.CreatedOn.Should().NotBeNull();
		blogPost.ModifiedOn.Should().NotBeNull();
		blogPost.Author.Should().NotBeNull();
		blogPost.Category.Should().NotBeNull();
		blogPost.IsPublished.Should().Be(false);
		blogPost.PublishedOn.Should().BeNull();
		
	}

	/// <summary>
	///   Tests that GetNewBlogPost returns a BlogPost with a non-empty Id
	///   when the keepId parameter is true.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPost GetNewBlogPost Test with keepId true and useSeed true")]
	public void GetNewBlogPost_Should_Return_BlogPost_With_Id_When_KeepId_Ie_True_And_UseSeed_Is_True()
	{

		// Act
		var blogPost = FakeBlogPost.GetNewBlogPost(keepId: true, useSeed: true);

		// Assert
		blogPost.Id.Should().NotBe(ObjectId.Empty);
		blogPost.Title.Should().NotBeNull();
		blogPost.Slug.Should().NotBeNull();
		blogPost.Introduction.Should().NotBeNull();
		blogPost.Content.Should().NotBeNull();
		blogPost.CreatedOn.Should().NotBeNull();
		blogPost.ModifiedOn.Should().NotBeNull();
		blogPost.Author.Should().NotBeNull();
		blogPost.Category.Should().NotBeNull();
		blogPost.IsPublished.Should().Be(false);
		blogPost.PublishedOn.Should().BeNull();
		
	}

	[Theory(DisplayName = "FakeBlogPost GetBlogPosts Test with use new seed is false")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	public void GetBlogPosts_With_UseSeed_Is_False_Should_Return_FakeBlogPosts_That_Are_Different_Test(int countRequested,
		bool useSeed)
	{

		// Act
		var categories = FakeBlogPost.GetBlogPosts(countRequested, useSeed);
		var categories2 = FakeBlogPost.GetBlogPosts(countRequested, useSeed);

		// Assert
		categories.Count.Should().Be(countRequested);
		
		for (int i = 0; i < categories.Count; i++)
		{
			
			categories[i].Id.Should().NotBe(categories2[i].Id);
			categories[i].Title.Should().NotBe(categories2[i].Title);
			categories[i].Slug.Should().NotBe(categories2[i].Slug);
			categories[i].Introduction.Should().NotBe(categories2[i].Introduction);
			categories[i].Content.Should().NotBe(categories2[i].Content);
			categories[i].CreatedOn.Should().NotBe(categories2[i].CreatedOn);
			categories[i].ModifiedOn.Should().NotBe(categories2[i].ModifiedOn);
			categories[i].Author.Should().NotBe(categories2[i].Author);
			categories[i].Category.Should().NotBe(categories2[i].Category);
			
		}
		
	}
	
	[Theory(DisplayName = "FakeBlogPost GetBlogPosts Test with use new seed")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetBlogPosts_With_UseSeed_Is_True_Should_Return_FakeBlogPosts_That_Are_Same_Test(int countRequested,
		bool useSeed)
	{

		// Act
		var categories = FakeBlogPost.GetBlogPosts(countRequested, useSeed);
		var categories2 = FakeBlogPost.GetBlogPosts(countRequested, useSeed);

		// Assert
		categories.Count.Should().Be(countRequested);
		
		for (int i = 0; i < categories.Count; i++)
		{
			
			categories[i].Id.Should().NotBe(categories2[i].Id);
			categories[i].Title.Should().BeEquivalentTo(categories2[i].Title);
			categories[i].Slug.Should().BeEquivalentTo(categories2[i].Slug);
			categories[i].Introduction.Should().BeEquivalentTo(categories2[i].Introduction);
			categories[i].Content.Should().BeEquivalentTo(categories2[i].Content);
			categories[i].CreatedOn.Should().NotBe(categories2[i].CreatedOn);
			categories[i].ModifiedOn.Should().NotBe(categories2[i].ModifiedOn);
			categories[i].Author.Should().BeEquivalentTo(categories2[i].Author, options => options
				.Excluding(x => x!.Id));
			categories[i].Category.Should().BeEquivalentTo(categories2[i].Category, options => options
				.Excluding(x => x!.Id));
			
		}
		
	}
	
}