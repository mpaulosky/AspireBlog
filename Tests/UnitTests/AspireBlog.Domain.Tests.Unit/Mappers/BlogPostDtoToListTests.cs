// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoToListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoToListTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Mappers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostDtoMapper))]
public class BlogPostDtoToListTests
{

	[Fact]
	public void ToBlogPostList_ShouldMapAllItemsCorrectly()
	{

		// Arrange
		var blogPostDtos = new List<BlogPostDto>
		{
				new()
				{
						Slug = "test-slug-1",
						Title = "Test Title 1",
						Introduction = "Test Introduction 1",
						Content = "Test Content 1",
						CreatedOn = DateOnly.FromDateTime(DateTime.Now),
						IsPublished = true,
						PublishedOn = DateOnly.FromDateTime(DateTime.Now),
						ModifiedOn = DateOnly.FromDateTime(DateTime.Now),
						Category = FakeCategoryDto.GetNewCategoryDto(true),
						Author = FakeUserInfoDto.GetNewUserInfoDto(true)
				},
				new()
				{
						Slug = "test-slug-2",
						Title = "Test Title 2",
						Introduction = "Test Introduction 2",
						Content = "Test Content 2",
						CreatedOn = DateOnly.FromDateTime(DateTime.Now),
						IsPublished = false,
						PublishedOn = DateOnly.FromDateTime(DateTime.Now),
						ModifiedOn = DateOnly.FromDateTime(DateTime.Now),
						Category = FakeCategoryDto.GetNewCategoryDto(true),
						Author = FakeUserInfoDto.GetNewUserInfoDto(true)
				}
		};

		// Act
		var result = blogPostDtos.ToBlogPostList();

		// Assert
		result.Should().HaveCount(2);
		result[0].Slug.Should().Be(blogPostDtos[0].Slug);
		result[0].Title.Should().Be(blogPostDtos[0].Title);
		result[0].Introduction.Should().Be(blogPostDtos[0].Introduction);
		result[0].Content.Should().Be(blogPostDtos[0].Content);
		result[0].CreatedOn.Should().Be(blogPostDtos[0].CreatedOn);
		result[0].IsPublished.Should().Be(blogPostDtos[0].IsPublished);
		result[0].PublishedOn.Should().Be(blogPostDtos[0].PublishedOn);
		result[0].ModifiedOn.Should().Be(blogPostDtos[0].ModifiedOn);
		result[0].Category.Should().Be(blogPostDtos[0].Category);
		result[0].Author.Should().Be(blogPostDtos[0].Author);

		result[1].Slug.Should().Be(blogPostDtos[1].Slug);
		result[1].Title.Should().Be(blogPostDtos[1].Title);
		result[1].Introduction.Should().Be(blogPostDtos[1].Introduction);
		result[1].Content.Should().Be(blogPostDtos[1].Content);
		result[1].CreatedOn.Should().Be(blogPostDtos[1].CreatedOn);
		result[1].IsPublished.Should().Be(blogPostDtos[1].IsPublished);
		result[1].PublishedOn.Should().Be(blogPostDtos[1].PublishedOn);
		result[1].ModifiedOn.Should().Be(blogPostDtos[1].ModifiedOn);
		result[1].Category.Should().Be(blogPostDtos[1].Category);
		result[1].Author.Should().Be(blogPostDtos[1].Author);

	}

}