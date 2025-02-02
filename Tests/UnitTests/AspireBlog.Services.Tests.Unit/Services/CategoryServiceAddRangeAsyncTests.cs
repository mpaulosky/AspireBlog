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
[TestSubject(typeof(CategoryService))]
public class CategoryServiceAddRangeTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	private readonly CategoryService _service;

	public CategoryServiceAddRangeTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<CategoryService>>();

		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task AddRange_ShouldReturnSuccess_WhenCategorysAreAdded()
	{

		// Arrange
		const int count = 3;
		var blogPosts = FakeCategory.GetCategories(count);
		_unitOfWork.CompleteAsync().Returns(count);

		// Act
		var result = await _service.AddRangeAsync(blogPosts);

		// Assert
		result.Status.Should().Be(true);
		_logger.Received(1).LogInformation("Categories have been saved.");

	}

	[Fact]
	public async Task AddRange_ShouldReturnFailure_WhenCompleteAsyncFails()
	{

		// Arrange
		const int count = 3;
		var blogPosts = FakeCategory.GetCategories(count);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.AddRangeAsync(blogPosts);

		// Assert
		result.Status.Should().Be(false);

		result.ErrorMessage
				.Should()
				.Be("Unknown error occurred while saving the categories.");

		_logger
				.Received(1)
				.LogError("Unknown error occurred while saving the categories.");

	}

}