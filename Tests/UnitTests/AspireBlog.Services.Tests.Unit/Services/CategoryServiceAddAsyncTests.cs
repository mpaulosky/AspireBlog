// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceAddAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryService))]
public class CategoryServiceAddAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	private readonly CategoryService _service;

	public CategoryServiceAddAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<CategoryService>>();

		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task AddAsync_ShouldReturnSuccess_WhenCategoryIsAdded()
	{

		// Arrange
		var blogPost = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(true);
		_logger.Received().LogInformation("Category has been saved.");

	}

	[Fact]
	public async Task AddAsync_ShouldReturnFailure_WhenCompleteAsyncFails()
	{

		// Arrange
		var blogPost = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(false);
		result.ErrorMessage.Should().Be("Unknown error occurred while saving the category.");
		_logger.Received().LogError("Unknown error occurred while saving the category.");

	}

	[Fact]
	public async Task AddAsync_ShouldReturnFailure_WhenCategoryAlreadyExists()
	{

		// Arrange
		var blogPost = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);

		// Act
		var result = await _service.AddAsync(blogPost);

		// Assert
		result.Status.Should().Be(false);
		result.ErrorMessage.Should().Be("This category already exists.");
		_logger.Received().LogError("This category already exists.");

	}

}