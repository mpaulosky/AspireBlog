// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

/// <summary>
///   Unit tests for the FakeBlogPostDto class.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeBlogPostDto))]
public class FakeBlogPostDtoTests
{
	/// <summary>
	///   Tests that GetNewBlogPostDto returns a BlogPostDto with an Id set to ObjectId.Empty
	///   and non-null properties when the keepId parameter is false.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test with keepId false")]
	public void GetNewBlogPostDto_Should_Return_BlogPostDto_Without_An_Id_When_KeepId_Is_False()
	{

		// Act
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(keepId: false, useSeed: false);
		var blogPostDto2 = FakeBlogPostDto.GetNewBlogPostDto(keepId: false, useSeed: false);
		
		// Assert
		blogPostDto.Id.Should().Be(ObjectId.Empty);
		blogPostDto.Should().NotBeEquivalentTo(blogPostDto2);
		blogPostDto.Id.Should().NotBeSameAs(blogPostDto2.Id);
		blogPostDto.Title.Should().NotBeEquivalentTo(blogPostDto2.Title);
		blogPostDto.ImageUrl.Should().NotBeEquivalentTo(blogPostDto2.ImageUrl);
		blogPostDto.Author.Should().NotBeNull();
		blogPostDto.CreatedOn.Should().NotBe(blogPostDto2.CreatedOn);
		blogPostDto.Content.Should().NotBeEquivalentTo(blogPostDto2.Content);
		blogPostDto.ModifiedOn.Should().NotBe(blogPostDto2.ModifiedOn);
		blogPostDto.Slug.Should().NotBeEquivalentTo(blogPostDto2.Slug);
		blogPostDto.Introduction.Should().NotBeEquivalentTo(blogPostDto2.Introduction);
		blogPostDto.Category.Should().NotBeEquivalentTo(blogPostDto2.Category);

	}

	/// <summary>
	///   Tests that GetNewBlogPostDto returns a BlogPostDto with an Id set to ObjectId.Empty
	///   and non-null properties when the keepId parameter is false.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test with keepId false and useSeed false")]
	public void GetNewBlogPostDto_Should_Return_BlogPostDto_Without_An_Id_When_Using_Default_Values()
	{
		
		// Act
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto();
		var blogPostDto2 = FakeBlogPostDto.GetNewBlogPostDto();
		
		// Assert
		blogPostDto.Id.Should().Be(ObjectId.Empty);
		blogPostDto.Should().NotBeEquivalentTo(blogPostDto2);
		blogPostDto.Id.Should().NotBeSameAs(blogPostDto2.Id);
		blogPostDto.Title.Should().NotBeEquivalentTo(blogPostDto2.Title);
		blogPostDto.ImageUrl.Should().NotBeEquivalentTo(blogPostDto2.ImageUrl);
		blogPostDto.Author.Should().NotBeEquivalentTo(blogPostDto2.Author);
		blogPostDto.CreatedOn.Should().NotBe(blogPostDto2.CreatedOn);
		blogPostDto.Content.Should().NotBeEquivalentTo(blogPostDto2.Content);
		blogPostDto.ModifiedOn.Should().NotBe(blogPostDto2.ModifiedOn);
		blogPostDto.Slug.Should().NotBeEquivalentTo(blogPostDto2.Slug);
		blogPostDto.Introduction.Should().NotBeEquivalentTo(blogPostDto2.Introduction);
		blogPostDto.Category.Should().NotBeEquivalentTo(blogPostDto2.Category);
		
	}

	/// <summary>
	///   Tests that GetNewBlogPostDto returns a BlogPostDto with a non-empty Id
	///   when the keepId parameter is true.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test with keepId true")]
	public void GetNewBlogPostDto_Should_Return_BlogPostDto_With_KeptId_True_When_KeepId_True()
	{
		// Arrange

		// Act
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(keepId: true, useSeed: false);
		var blogPostDto2 = FakeBlogPostDto.GetNewBlogPostDto(keepId: true, useSeed: false);

		// Assert
		blogPostDto.Id.Should().NotBe(ObjectId.Empty);
		blogPostDto.Should().NotBeEquivalentTo(blogPostDto2);
		blogPostDto.Id.Should().NotBeSameAs(blogPostDto2.Id);
		blogPostDto.Title.Should().NotBeEquivalentTo(blogPostDto2.Title);
		blogPostDto.ImageUrl.Should().NotBeEquivalentTo(blogPostDto2.ImageUrl);
		blogPostDto.Author.Should().NotBeEquivalentTo(blogPostDto2.Author);
		blogPostDto.CreatedOn.Should().NotBe(blogPostDto2.CreatedOn);
		blogPostDto.Content.Should().NotBeEquivalentTo(blogPostDto2.Content);
		blogPostDto.ModifiedOn.Should().NotBe(blogPostDto2.ModifiedOn);
		blogPostDto.Slug.Should().NotBeEquivalentTo(blogPostDto2.Slug);
		blogPostDto.Introduction.Should().NotBeEquivalentTo(blogPostDto2.Introduction);
		blogPostDto.Category.Should().NotBeEquivalentTo(blogPostDto2.Category);
		
	}

	/// <summary>
	///   Tests that GetNewBlogPostDto returns a BlogPostDto with an Id set to ObjectId.Empty
	///   and non-null properties when the keepId parameter is false.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test with keepId false and useSeed true")]
	public void GetNewBlogPostDto_Should_Return_BlogPostDto_Without_Id_When_When_KeepId_Is_False_And_UseSeed_Is_True()
	{
		// Arrange

		// Act
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(keepId: false, useSeed: true);
		var blogPostDto2 = FakeBlogPostDto.GetNewBlogPostDto(keepId: false, useSeed: true);

		// Assert
		blogPostDto.Id.Should().Be(blogPostDto2.Id);
		blogPostDto.Title.Should().BeEquivalentTo(blogPostDto2.Title);
		blogPostDto.ImageUrl.Should().BeEquivalentTo(blogPostDto2.ImageUrl);
		blogPostDto.Author.Should().BeEquivalentTo(blogPostDto2.Author, options => options
			.Excluding(t => t!.Id));
		blogPostDto.CreatedOn.Should().NotBe(blogPostDto2.CreatedOn);
		blogPostDto.Content.Should().BeEquivalentTo(blogPostDto2.Content);
		blogPostDto.ModifiedOn.Should().NotBe(blogPostDto2.ModifiedOn);
		blogPostDto.Slug.Should().BeEquivalentTo(blogPostDto2.Slug);
		blogPostDto.Introduction.Should().BeEquivalentTo(blogPostDto2.Introduction);
		blogPostDto.Category.Should().BeEquivalentTo(blogPostDto2.Category, options => options
			.Excluding(t => t!.Id));
		blogPostDto.IsPublished.Should().Be(blogPostDto2.IsPublished);
		blogPostDto.PublishedOn.Should().Be(blogPostDto2.PublishedOn);
		
	}

	/// <summary>
	///   Tests that GetNewBlogPostDto returns a BlogPostDto with a non-empty Id
	///   when the keepId parameter is true.
	/// </summary>
	[Fact(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test with keepId true and useSeed true")]
	public void GetNewBlogPostDto_Should_Return_BlogPostDto_With_Id_When_KeepId_Ie_True_And_UseSeed_Is_True()
	{

		// Act
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(keepId: true, useSeed: true);
		var blogPostDto2 = FakeBlogPostDto.GetNewBlogPostDto(keepId: true, useSeed: true);

		// Assert
		blogPostDto.Id.Should().NotBe(blogPostDto2.Id);
		blogPostDto.Title.Should().BeEquivalentTo(blogPostDto2.Title);
		blogPostDto.ImageUrl.Should().BeEquivalentTo(blogPostDto2.ImageUrl);
		blogPostDto.Author.Should().BeEquivalentTo(blogPostDto2.Author, options => options
			.Excluding(t => t!.Id));
		blogPostDto.CreatedOn.Should().NotBe(blogPostDto2.CreatedOn);
		blogPostDto.Content.Should().BeEquivalentTo(blogPostDto2.Content);
		blogPostDto.ModifiedOn.Should().NotBe(blogPostDto2.ModifiedOn);
		blogPostDto.Slug.Should().BeEquivalentTo(blogPostDto2.Slug);
		blogPostDto.Introduction.Should().BeEquivalentTo(blogPostDto2.Introduction);
		blogPostDto.Category.Should().BeEquivalentTo(blogPostDto2.Category, 
			options => options
			.Excluding(t => t!.Id));
		blogPostDto.IsPublished.Should().Be(blogPostDto2.IsPublished);
		blogPostDto.PublishedOn.Should().Be(blogPostDto2.PublishedOn);
		
	}

	[Theory(DisplayName = "FakeBlogPostDto GetBlogPostDtos Test with use new seed")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetBlogPostDtos_With_UseSeed_Should_Return_FakeBlogPostDtos_That_Are_Different_Test(int countRequested,
		bool useSeed)
	{
		// Arrange

		// Act
		var categories = FakeBlogPostDto.GetBlogPostDtos(countRequested, useSeed);

		// Assert
		categories.Count.Should().Be(countRequested);
		categories.Should().NotBeEquivalentTo(FakeBlogPostDto.GetBlogPostDtos(countRequested, useSeed));
	}

	[Fact(DisplayName = "FakeBlogPostDto FakeData Test with useSeed false")]
	public void FakeData_Should_Return_BlogPostDto_With_Valid_Data_When_UseSeed_Is_False()
	{
		// Act
		var blogPostDto = FakeBlogPostDto.FakeData(useSeed: false);

		// Assert
		blogPostDto.Should().NotBeNull();
		blogPostDto.Id.Should().NotBe(ObjectId.Empty);
		blogPostDto.Title.Should().NotBeNullOrEmpty();
		blogPostDto.ImageUrl.Should().NotBeNullOrEmpty();
		blogPostDto.Author.Should().NotBeNull();
		blogPostDto.CreatedOn.Should().BeBefore(DateTime.Now);
		blogPostDto.Content.Should().NotBeNullOrEmpty();
		if (blogPostDto.IsPublished)
		{
			blogPostDto.IsPublished.Should().BeTrue();
			blogPostDto.PublishedOn.Should().BeBefore(DateTime.Now);
		}
		else
		{
			blogPostDto.IsPublished.Should().BeFalse();
			blogPostDto.PublishedOn.Should().BeNull();
		}

		blogPostDto.ModifiedOn.Should().BeBefore(DateTime.Now);
		blogPostDto.Slug.Should().NotBeNullOrEmpty();
		blogPostDto.Introduction.Should().NotBeNullOrEmpty();
		blogPostDto.Category.Should().NotBeNull();
	}

	[Fact(DisplayName = "FakeBlogPostDto FakeData Test with useSeed true")]
	public void FakeData_Should_Return_Same_BlogPostDto_When_UseSeed_Is_True()
	{
		// Act
		var blogPostDto1 = FakeBlogPostDto.FakeData(useSeed: true);
		var blogPostDto2 = FakeBlogPostDto.FakeData(useSeed: true);

		// Assert
		blogPostDto1.Should().NotBeEquivalentTo(blogPostDto2, options => options
			.Excluding(t => t.Id)
			.Excluding(t => t.CreatedOn)
			.Excluding(t => t.PublishedOn)
			.Excluding(t => t.ModifiedOn));
	}
}