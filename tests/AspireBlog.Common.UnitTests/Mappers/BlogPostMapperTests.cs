// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostMapperTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostMapper))]
public class BlogPostMapperTests
{
	[Fact(DisplayName = "MapToBlogPost Should Map All Properties Correctly")]
	public void MapToBlogPost_Should_Map_All_Properties_Correctly()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		// Act
		var blogPost = blogPostDto.MapToBlogPost();

		// Assert
		blogPost.Id.Should().Be(blogPostDto.Id);
		blogPost.Title.Should().Be(blogPostDto.Title);
		blogPost.Slug.Should().Be(blogPostDto.Slug);
		blogPost.Introduction.Should().Be(blogPostDto.Introduction);
		blogPost.Content.Should().Be(blogPostDto.Content);
		blogPost.CreatedOn.Should().Be(blogPostDto.CreatedOn);
		blogPost.IsPublished.Should().Be(blogPostDto.IsPublished);
		blogPost.PublishedOn.Should().Be(blogPostDto.PublishedOn);
		blogPost.ModifiedOn.Should().Be(blogPostDto.ModifiedOn);
		blogPost.Author.Should().Be(blogPostDto.Author);
		blogPost.Category.Should().Be(blogPostDto.Category);
	}

	[Fact(DisplayName = "MapToBlogPostDto Should Map All Properties Correctly")]
	public void MapToBlogPostDto_Should_Throws_ArgumentNullException_When_BlogPost_Is_Null()
	{
		// Arrange
		BlogPost? blogPost = null;

		// Act
		Action act = () => blogPost.MapToBlogPostDto();

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*Value cannot be null.*");
	}

	[Fact(DisplayName = "MapToBlogPost Should Throw ArgumentException When Id Is ObjectId Empty")]
	public void MapToBlogPost_Should_Throw_ArgumentException_When_Id_Is_ObjectId_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Title = string.Empty;

		// Act
		Action act = () => blogPostDto.MapToBlogPost();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Title*");
	}

	[Fact(DisplayName = "MapToBlogPost Should Throw ArgumentException When Title Is String Empty")]
	public void MapToBlogPost_Should_Throw_ArgumentException_When_Title_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Title = string.Empty;

		// Act
		Action act = () => blogPostDto.MapToBlogPost();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Title*");
	}

	[Fact(DisplayName = "MapToBlogPost Should Throw ArgumentException When Slug Is String Empty")]
	public void MapToBlogPost_Should_Throw_ArgumentException_When_Slug_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Slug = string.Empty;

		// Act
		Action act = () => blogPostDto.MapToBlogPost();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Slug*");
	}

	[Fact(DisplayName = "MapToBlogPost Should Throw ArgumentException When Introduction Is String Empty")]
	public void MapToBlogPost_Should_Throw_Exception_When_Introduction_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Introduction = string.Empty;

		// Act
		Action act = () => blogPostDto.MapToBlogPost();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Introduction*");
	}

	[Fact(DisplayName = "Merge Should Update All Properties Correctly")]
	public void Merge_Should_Update_All_Properties_Correctly()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		blogPostDto.Merge(blogPost);

		// Assert
		blogPost.Id.Should().Be(blogPostDto.Id);
		blogPost.Title.Should().Be(blogPostDto.Title);
		blogPost.Slug.Should().Be(blogPostDto.Slug);
		blogPost.Introduction.Should().Be(blogPostDto.Introduction);
		blogPost.Content.Should().Be(blogPostDto.Content);
		blogPost.CreatedOn.Should().Be(blogPostDto.CreatedOn);
		blogPost.IsPublished.Should().Be(blogPostDto.IsPublished);
		blogPost.PublishedOn.Should().Be(blogPostDto.PublishedOn);
		blogPost.ModifiedOn.Should().Be(blogPostDto.ModifiedOn);
		blogPost.Author.Should().Be(blogPostDto.Author);
		blogPost.Category.Should().Be(blogPostDto.Category);
	}

	[Fact(DisplayName = "Merge Should Throws ArgumentNullException When BlogPostDto Is Null")]
	public void Merge_Should_Throws_ArgumentNullException_When_BlogPostDto_Is_Null()
	{
		// Arrange
		BlogPostDto? blogPostDto = null;

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*Value cannot be null.*");
	}

	[Fact(DisplayName = "Merge Should Throws ArgumentNullException When BlogPost Is Null")]
	public void Merge_Should_Throws_ArgumentNullException_When_BlogPost_Is_Null()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		BlogPost? blogPost = null;

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentNullException>().WithMessage("*Value cannot be null.*");
	}

	[Fact(DisplayName = "Merge Should Throw ArgumentException When Id Is ObjectId Empty")]
	public void Merge_Should_Throw_ArgumentException_When_Id_Is_ObjectId_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Title = string.Empty;

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Title*");
	}

	[Fact(DisplayName = "Merge Should Throw ArgumentException When Title Is String Empty")]
	public void Merge_Should_Throw_ArgumentException_When_Title_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Title = string.Empty;

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Title*");
	}

	[Fact(DisplayName = "Merge Should Throw ArgumentException When Slug Is String Empty")]
	public void Merge_Should_Throw_ArgumentException_When_Slug_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Slug = string.Empty;

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Slug*");
	}

	[Fact(DisplayName = "Merge Should Throw ArgumentException When Introduction Is String Empty")]
	public void Merge_Should_Throw_Exception_When_Introduction_Is_String_Empty()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		blogPostDto.Introduction = string.Empty;

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Introduction*");
	}

	[Fact(DisplayName = "Merge Should Throw Exception For Null Or Empty Content")]
	public void Merge_Should_Throw_Exception_For_Null_Content()
	{
		// Arrange
		var blogPostDto = FakeBlogPostDto.GetNewBlogPostDto(true);

		var blogPost = FakeBlogPost.GetNewBlogPost(true);

		blogPostDto.Content = string.Empty;

		// Act
		Action act = () => blogPostDto.Merge(blogPost);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Content*");
	}
}