// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoMerge.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoMergeTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostDtoMapper))]
public class BlogPostDtoMergeTests
{

	[Fact]
	public void MergeToBlogPost_ShouldMergePropertiesCorrectly()
	{

		// Arrange
		var blogPostDto = new BlogPostDto
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

		var blogPost = BlogPost.Empty;

		// Act
		var result = blogPostDto.MergeToBlogPost(blogPost);

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