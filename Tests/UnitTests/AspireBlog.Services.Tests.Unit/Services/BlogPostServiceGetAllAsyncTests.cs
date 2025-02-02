// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceGetAllAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceGetAllAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	private readonly BlogPostService _service;

	public BlogPostServiceGetAllAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<BlogPostService>>();

		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task GetAllAsync_Should_ReturnAllBlogPosts_When_BlogPostsExist()
	{

		// Arrange
		var blogPosts = FakeBlogPosts.GetBlogPosts(3);

		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = (await _service.GetAllAsync()).ToList();

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(blogPosts.Count);
		result.Should().BeEquivalentTo(blogPosts);
		_logger.Received(1).LogInformation("Returned all blogPosts.");

	}

	[Fact]
	public async Task GetAllAsync_Should_ReturnNull_When_NoBlogPostsExist()
	{

		// Arrange
		_unitOfWork.BlogPost.GetAllAsync().Returns([]);

		// Act
		var result = await _service.GetAllAsync();

		// Assert
		result.Should().BeNull();
		_logger.Received(1).LogError("No blogPosts exist.");

	}

}