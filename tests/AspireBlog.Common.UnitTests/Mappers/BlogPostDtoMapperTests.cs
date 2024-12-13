// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDtoMapperTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostDtoMapper))]
public class BlogPostDtoMapperTests
{
	[Fact]
	public void MapToBlogPostDtoTest()
	{
		// Arrange
		BlogPost? blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		var result = blogPost.MapToBlogPostDto();

		// Assert
		result.Should().NotBeNull();
		result.Id.Should().Be(blogPost.Id);
		result.Title.Should().Be(blogPost.Title);
		result.Slug.Should().Be(blogPost.Slug);
		result.Content.Should().Be(blogPost.Content);
		result.Author.Should().Be(blogPost.Author);
		result.Category.Should().Be(blogPost.Category);
		result.CreatedOn.Should().Be(blogPost.CreatedOn);
		result.IsPublished.Should().Be(blogPost.IsPublished);
		result.ModifiedOn.Should().Be(blogPost.ModifiedOn);
		result.PublishedOn.Should().Be(blogPost.PublishedOn);
		result.ModifiedOn.Should().Be(blogPost.ModifiedOn);
	}

	[Fact]
	public void MapToBlogPostDto_Null_BlogPost_ThrowsArgumentNullException()
	{
		// Arrange
		BlogPost? blogPost = null;

		// Act
		Action act = () => (blogPost ?? throw new ArgumentNullException()).MapToBlogPostDto();

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*Value cannot be null.*");
	}

	[Fact(DisplayName = "MapToBlogPostDto Should Throw Exception For Null Or Empty Title")]
	public void MapToBlogPostDto_Should_Throw_Exception_For_Null_Title()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		blogPost.Title = string.Empty;

		Action act = () => blogPost.MapToBlogPostDto();

		act.Should().Throw<ArgumentException>().WithMessage("*Title*");
	}

	[Fact(DisplayName = "MapToBlogPostDto Should Throw Exception For Null Or Empty Slug")]
	public void MapToBlogPost_Should_Throw_Exception_For_Null_Slug()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		blogPost.Slug = string.Empty;

		Action act = () => blogPost.MapToBlogPostDto();

		act.Should().Throw<ArgumentException>().WithMessage("*Slug*");
	}

	[Fact(DisplayName = "Merge Should Throw Exception For Null Or Empty Content")]
	public void Merge_Should_Throw_Exception_For_Null_Content()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		blogPost.Content = string.Empty;

		Action act = () => blogPost.MapToBlogPostDto();

		act.Should().Throw<ArgumentException>().WithMessage("*Content*");
	}

	[Fact(DisplayName = "MapToBlogPostDto Should Throw Exception For Null Or Empty Introduction")]
	public void MapToBlogPost_Should_Throw_Exception_For_Null_Introduction()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		blogPost.Introduction = string.Empty;

		Action act = () => blogPost.MapToBlogPostDto();

		act.Should().Throw<ArgumentException>().WithMessage("*Introduction*");
	}

	[Fact(DisplayName = "MapToBlogPostDto Should Throw Exception For Null Or Empty CreatedOn")]
	public void MapToBlogPost_Should_Throw_Exception_For_Null_CreatedOn()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		blogPost.CreatedOn = null;

		Action act = () => blogPost.MapToBlogPostDto();

		act.Should().Throw<InvalidOperationException>().WithMessage("Nullable object must have a value.");
	}
}