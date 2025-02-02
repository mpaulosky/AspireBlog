// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceRemoveAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceRemoveAsyncTests
{

	private readonly BlogPostService _service;

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	public BlogPostServiceRemoveAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_logger = Substitute.For<ILogger<BlogPostService>>();
		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnFailure_WhenBlogPostDoesNotExist()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(false);

		// Act
		var result = await _service.RemoveAsync(blogPost);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("This blogPost does not exist");
		_logger.Received().LogError("This blogPost does not exist.");

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnSuccess_WhenBlogPostIsRemoved()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.RemoveAsync(blogPost);

		// Assert
		result.Status.Should().BeTrue();
		_logger.Received().LogInformation("BlogPost has been removed.");

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnFailure_WhenUnknownErrorOccurs()
	{

		// Arrange
		var blogPost = FakeBlogPosts.GetNewBlogPost(true);
		_unitOfWork.BlogPost.AnyAsync(Arg.Any<Expression<Func<BlogPost, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.RemoveAsync(blogPost);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("Unknown error occurred while removing the blogPost");
		_logger.Received().LogError("Unknown error occurred while removing the blogPost.");

	}

}