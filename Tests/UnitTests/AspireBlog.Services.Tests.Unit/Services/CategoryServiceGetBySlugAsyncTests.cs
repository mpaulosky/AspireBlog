// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceGetBySlugAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryService))]
public class CategoryServiceGetBySlugAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	private readonly CategoryService _service;

	public CategoryServiceGetBySlugAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<CategoryService>>();

		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnCategoryDto_WhenCategoryExists()
	{

		// Arrange
		var category = FakeCategory.GetNewCategory(true);
		_unitOfWork.Category.FindFirstAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(category);

		// Act
		var result = await _service.GetBySlugAsync(category.Slug);

		// Assert
		result.Should().NotBeNull();
		result?.Slug.Should().Be(category.Slug);
		_logger.Received(1).LogInformation("Successfully retrieved the category.");

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
	{

		// Arrange
		_unitOfWork.Category.FindFirstAsync(Arg.Any<Expression<Func<Category, bool>>>()).Returns(null as Category);

		// Act
		var result = await _service.GetBySlugAsync("test-slug");

		// Assert
		result.Should().BeNull();
		_logger.Received().LogError("Category not found.");

	}

	[Fact]
	public async Task GetBySlugAsync_ShouldReturnNull_WhenSlugIsNullOrEmpty()
	{

		// Arrange
		//_unitOfWork.Category.GetBySlugAsync("test-slug").Returns(null as Category);

		// Act
		var result = await _service.GetBySlugAsync("");

		// Assert
		result.Should().BeNull();
		_logger.Received().LogError("Slug is required.");

	}

}