// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostToDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostToDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostMapper))]
public class BlogPostToDtoTests
{

	[Fact]
	public void ToBlogPostDto_ShouldMapPropertiesCorrectly()
	{

		// Arrange
		var blogPost = new BlogPost
		{
				Slug = "test-slug",
				Title = "Test Title",
				Introduction = "Test Introduction",
				Content = "Test Content",
				CreatedOn = DateOnly.FromDateTime(DateTime.Now),
				IsPublished = true,
				PublishedOn = DateOnly.FromDateTime(DateTime.Now),
				ModifiedOn = DateOnly.FromDateTime(DateTime.Now),
				Category = FakeCategoryDto.GetNewCategoryDto(true),
				Author = FakeUserInfoDto.GetNewUserInfoDto(true)
		};

		// Act
		var result = blogPost.ToBlogPostDto();

		// Assert
		result.Slug.Should().Be(blogPost.Slug);
		result.Title.Should().Be(blogPost.Title);
		result.Introduction.Should().Be(blogPost.Introduction);
		result.Content.Should().Be(blogPost.Content);
		result.CreatedOn.Should().Be(blogPost.CreatedOn);
		result.IsPublished.Should().Be(blogPost.IsPublished);
		result.PublishedOn.Should().Be(blogPost.PublishedOn);
		result.ModifiedOn.Should().Be(blogPost.ModifiedOn);
		result.Category.Should().Be(blogPost.Category);
		result.Author.Should().Be(blogPost.Author);

	}

}