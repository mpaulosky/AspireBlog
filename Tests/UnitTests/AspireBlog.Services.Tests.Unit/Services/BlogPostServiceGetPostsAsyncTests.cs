// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostServiceGetPostsAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPostService))]
public class BlogPostServiceGetPostsAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<BlogPostService> _logger;

	private readonly BlogPostService _service;

	public BlogPostServiceGetPostsAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_logger = Substitute.For<ILogger<BlogPostService>>();
		_service = new BlogPostService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnPaginatedBlogPosts()
	{

		// Arrange
		const int count = 5;
		const int page = 1;
		var blogPosts = FakeBlogPosts.GetBlogPosts(15).AsQueryable();
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = await _service.GetPostsAsync(5);

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(count);
		_logger.Received(1).LogInformation("Returned paginated blogPosts.");

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnEmpty_When_NoBlogPostsExist()
	{

		// Arrange
		const int count = 5;
		const int page = 1;
		var blogPosts = Enumerable.Empty<BlogPost>().AsQueryable();
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = await _service.GetPostsAsync(count);

		// Assert
		result.Should().BeNull();
		_logger.Received(1).LogError("No blogPosts exist.");

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnFilteredBlogPosts_When_PublishedOnlyIsTrue()
	{

		// Arrange
		const int expectedCount = 7;
		var blogPosts = FakeBlogPosts.GetBlogPosts(15, true);
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = (await _service.GetPostsAsync(true)).ToList();

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(expectedCount);
		_logger.Received(1).LogInformation("Returned filtered blogPosts.");

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnFilteredBlogPosts_When_CategorySlugIsProvided()
	{

		// Arrange
		var blogPost1 = FakeBlogPosts.GetNewBlogPost();
		var blogPost2 = FakeBlogPosts.GetNewBlogPost();
		var blogPost3 = FakeBlogPosts.GetNewBlogPost();
		var categorySlug = blogPost1.Category.Slug;
		var blogPosts = new List<BlogPost> { blogPost1, blogPost2, blogPost3 };
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = (await _service.GetPostsAsync(false, categorySlug)).ToList();

		// Assert
		result.Should().NotBeNull();
		result[0].Should().BeEquivalentTo(blogPost1);
		_logger.Received(1).LogInformation("Returned filtered blogPosts.");

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnFilteredBlogPosts_When_PublishedOnlyAndCategorySlugAreProvided()
	{

		// Arrange
		var blogPost1 = FakeBlogPosts.GetNewBlogPost();
		blogPost1.IsPublished = true;
		var blogPost2 = FakeBlogPosts.GetNewBlogPost();
		var blogPost3 = FakeBlogPosts.GetNewBlogPost();
		var categorySlug = blogPost1.Category.Slug;
		var blogPosts = new List<BlogPost> { blogPost1, blogPost2, blogPost3 };
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = (await _service.GetPostsAsync(true, categorySlug)).ToList();

		// Assert
		result.Should().NotBeNull();
		result[0].Should().BeEquivalentTo(blogPost1);
		_logger.Received(1).LogInformation("Returned filtered blogPosts.");

	}

	[Fact]
	public async Task GetPostsAsync_Should_ReturnNull_When_NoBlogPostsMatchCriteria()
	{

		// Arrange
		List<BlogPost> blogPosts = [];
		_unitOfWork.BlogPost.GetAllAsync().Returns(blogPosts);

		// Act
		var result = await _service.GetPostsAsync(true, "non-existent-category");

		// Assert
		result.Should().BeNull();
		_logger.Received(1).LogError("No blogPosts exist.");

	}

}