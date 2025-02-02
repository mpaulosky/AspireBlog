// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceAddRangeAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceAddRangeTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	private readonly BlogPostService _service;

	public BlogPostServiceAddRangeTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<BlogPostService>>();

		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task AddRange_ShouldReturnSuccess_WhenBlogPostsAreAdded()
	{

		// Arrange
		const int count = 3;
		var blogPosts = FakeBlogPosts.GetBlogPosts(count);
		_unitOfWork.CompleteAsync().Returns(count);

		// Act
		var result = await _service.AddRangeAsync(blogPosts);

		// Assert
		result.Status.Should().Be(true);
		_logger.Received().LogInformation("BlogPosts have been saved.");

	}

	[Fact]
	public async Task AddRange_ShouldReturnFailure_WhenCompleteAsyncFails()
	{

		// Arrange
		const int count = 3;
		var blogPosts = FakeBlogPosts.GetBlogPosts(count);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.AddRangeAsync(blogPosts);

		// Assert
		result.Status.Should().Be(false);

		result.ErrorMessage
				.Should()
				.Be("Unknown error occurred while saving the blog posts.");

		_logger
				.Received()
				.LogError("Unknown error occurred while saving the blog posts.");

	}

}