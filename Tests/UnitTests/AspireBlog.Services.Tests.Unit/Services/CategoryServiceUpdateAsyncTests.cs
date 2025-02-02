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
[TestSubject(typeof(CategoryService))]
public class CategoryServiceUpdateAsyncTests
{

	private readonly CategoryService _service;

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	public CategoryServiceUpdateAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_logger = Substitute.For<ILogger<CategoryService>>();
		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnFailure_WhenCategoryDoesNotExist()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory();
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

		// Act
		var result = await _service.UpdateAsync(category);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("This category does not exist.");
		_logger.Received(1).LogError("This category does not exist.");

	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnSuccess_WhenCategoryIsUpdated()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory();
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.UpdateAsync(category);

		// Assert
		result.Status.Should().BeTrue();
		_logger.Received(0).LogError("Category has been updated.");

	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnFailure_WhenUnknownErrorOccurs()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory();
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.UpdateAsync(category);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("Unknown error occurred while saving the category.");
		_logger.Received(1).LogError("Unknown error occurred while saving the category.");

	}

}