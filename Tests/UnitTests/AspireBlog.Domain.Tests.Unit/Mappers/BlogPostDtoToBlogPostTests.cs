// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoToBlogPostTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostDtoMapper))]
public class BlogPostDtoToBlogPostTests
{

	[Fact]
	public void ToBlogPost_ShouldMapPropertiesCorrectly()
	{

		// Arrange
		var blogPostDto = new BlogPostDto
		{
				Slug = "test-slug",
				Title = "Test Title",
				Introduction = "Test Introduction",
				Content = "Test Content",
				CreatedOn = DateTimeOffset.UtcNow,
				IsPublished = true,
				PublishedOn = DateTimeOffset.UtcNow,
				ModifiedOn = DateTimeOffset.UtcNow,
				Category = FakeCategoryDto.GetNewCategoryDto(true, true),
				Author = FakeUserInfoDto.GetNewUserInfoDto(true, true)
		};

		// Act
		var result = blogPostDto.ToBlogPost();

		// Assert
		result.Slug.Should().Be(blogPostDto.Slug);
		result.Title.Should().Be(blogPostDto.Title);
		result.Introduction.Should().Be(blogPostDto.Introduction);
		result.Content.Should().Be(blogPostDto.Content);
		result.CreatedOn.Should().Be(blogPostDto.CreatedOn);
		result.IsPublished.Should().Be(blogPostDto.IsPublished);
		result.PublishedOn.Should().Be(blogPostDto.PublishedOn);
		result.ModifiedOn.Should().Be(blogPostDto.ModifiedOn);
		result.Category.Should().Be(blogPostDto.Category);
		result.Author.Should().Be(blogPostDto.Author);

	}

}