// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceAddAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceAddAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	private readonly BlogPostService _service;

	public BlogPostServiceAddAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<BlogPostService>>();

		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task AddAsync_ShouldReturnSuccess_WhenBlogPostIsAdded()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(false);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(true);
		_logger.Received().LogInformation("BlogPost has been saved.");

	}

	[Fact]
	public async Task AddAsync_ShouldReturnFailure_WhenCompleteAsyncFails()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(false);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(false);
		result.ErrorMessage.Should().Be("Unknown error occurred while saving the blog post.");
		_logger.Received().LogError("Unknown error occurred while saving the blog post.");

	}

	[Fact]
	public async Task AddAsync_ShouldReturnFailure_WhenBlogPostAlreadyExists()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(true);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(false);
		result.ErrorMessage.Should().Be("This blogPost already exists.");
		_logger.Received().LogError("This blogPost already exists.");

	}

}