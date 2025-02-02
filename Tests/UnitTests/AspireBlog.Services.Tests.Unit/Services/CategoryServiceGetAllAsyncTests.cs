// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryServiceGetAllAsyncTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Services.Tests.Unit
// =======================================================

namespace AspireBlog.Services.Services;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CategoryService))]
public class CategoryServiceGetAllAsyncTests
{

	private readonly IUnitOfWork _unitOfWork;

	private readonly ILogger<CategoryService> _logger;

	private readonly CategoryService _service;

	public CategoryServiceGetAllAsyncTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();

		_logger = Substitute.For<ILogger<CategoryService>>();

		_service = new CategoryService(_unitOfWork, _logger);

	}

	[Fact]
	public async Task GetAllAsync_Should_ReturnAllCategorys_When_CategorysExist()
	{

		// Arrange
		var categories = FakeCategory.GetCategories(3);

		_unitOfWork.Category.GetAllAsync().Returns(categories);

		// Act
		var result = (await _service.GetAllAsync()).ToList();

		// Assert
		result.Should().NotBeNull();
		result.Should().HaveCount(categories.Count);
		result.Should().BeEquivalentTo(categories);
		_logger.Received(1).LogInformation("Returned all the categories.");

	}

	[Fact]
	public async Task GetAllAsync_Should_ReturnNull_When_NoCategoriesExist()
	{

		// Arrange
		_unitOfWork.Category.GetAllAsync().Returns([]);

		// Act
		var result = await _service.GetAllAsync();

		// Assert
		result.Should().BeNull();
		_logger.Received(1).LogError("No categories exist.");

	}

}