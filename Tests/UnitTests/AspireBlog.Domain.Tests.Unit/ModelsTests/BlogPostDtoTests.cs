// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.ModelsTests;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostDto))]
public class BlogPostDtoTests
{

	[Fact]
	public void Empty_ShouldReturnEmptyBlogPostDto()
	{

		// Act
		var result = BlogPostDto.Empty;

		// Assert
		result.Slug.Should().BeEmpty();
		result.Title.Should().BeEmpty();
		result.Introduction.Should().BeEmpty();
		result.Content.Should().BeEmpty();
		result.CreatedOn.Should().BeNull();
		result.IsPublished.Should().BeFalse();
		result.PublishedOn.Should().BeNull();
		result.ModifiedOn.Should().BeNull();
		result.Category.Should().Be(CategoryDto.Empty);
		result.Author.Should().Be(UserInfoDto.Empty);

	}

}