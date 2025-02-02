// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceUpdateAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceUpdateAsyncTests
{

	private readonly BlogPostService _service;

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	public BlogPostServiceUpdateAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_logger = Substitute.For<ILogger<BlogPostService>>();
		_service = new BlogPostService(_unitOfWork, _logger);

	}


	[Fact]
	public async Task UpdateAsync_ShouldReturnFailure_WhenBlogPostDoesNotExist()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost();
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(false);

		// Act
		var result = await _service.UpdateAsync(blogPost);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("This blogPost does not exist");
		_logger.Received(1).LogError("This blogPost does not exist.");

	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnSuccess_WhenBlogPostIsUpdated()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost();
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.UpdateAsync(blogPost);

		// Assert
		result.Status.Should().BeTrue();
		_logger.Received(0).LogError("BlogPost has been updated.");

	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnFailure_WhenUnknownErrorOccurs()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost();
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.UpdateAsync(blogPost);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("Unknown error occurred while saving the blog post.");
		_logger.Received(1).LogError("Unknown error occurred while saving the blog post.");

	}

}