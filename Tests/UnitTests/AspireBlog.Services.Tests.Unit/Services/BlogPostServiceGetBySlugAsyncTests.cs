// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceGetBySlugAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceGetBySlugAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	private readonly BlogPostService _service;

	public BlogPostServiceGetBySlugAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<BlogPostService>>();

		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnBlogPostDto_WhenBlogPostExists()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.FindFirstAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(blogPost);

		// Act
		var result = await _service.GetBySlugAsync(blogPost.Slug);

		// Assert
		result.Should().NotBeNull();
		result?.Slug.Should().Be(blogPost.Slug);
		_logger.Received().LogInformation("Successfully retrieved blogPost.");

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnNull_WhenBlogPostDoesNotExist()
	{

		// Arrange
		_unitOfWork.BlogPost.FindFirstAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(null as BlogPost);

		// Act
		var result = await _service.GetBySlugAsync("test-slug");

		// Assert
		result.Should().BeNull();
		_logger.Received().LogError("BlogPost not found.");

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnNull_WhenSlugIsNullOrEmpty()
	{

		// Arrange
		//_unitOfWork.BlogPost.GetBySlugAsync("test-slug").Returns(null as BlogPost);

		// Act
		var result = await _service.GetBySlugAsync("");

		// Assert
		result.Should().BeNull();
		_logger.Received().LogError("Slug is required.");

	}

}