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
[TestSubject(typeof(CategoryService))]
public class CategoryServiceRemoveAsyncTests
{

	private readonly CategoryService _service;

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	public CategoryServiceRemoveAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_logger = Substitute.For<ILogger<CategoryService>>();
		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnFailure_WhenCategoryDoesNotExist()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(false);

		// Act
		var result = await _service.RemoveAsync(category);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("This category does not exist.");
		_logger.Received().LogError("This category does not exist.");

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnSuccess_WhenCategoryIsRemoved()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(1);

		// Act
		var result = await _service.RemoveAsync(category);

		// Assert
		result.Status.Should().BeTrue();
		_logger.Received().LogInformation("Category has been removed.");

	}

	[Fact]
	public async Task RemoveAsync_ShouldReturnFailure_WhenUnknownErrorOccurs()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.AnyAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(true);
		_unitOfWork.CompleteAsync().Returns(0);

		// Act
		var result = await _service.RemoveAsync(category);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be("Unknown error occurred while removing the category.");
		_logger.Received().LogError("Unknown error occurred while removing the category.");

	}

}