// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DbSeederTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence.Tests.Unit
// =======================================================

namespace AspireBlog.Persistence.SeedingData;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(DbSeeder))]
public class DbSeederTests
{

	private readonly IUnitOfWork _unitOfWork;
	private readonly DbSeeder _dbSeeder;

	public DbSeederTests()
	{

		_unitOfWork = Substitute.For<IUnitOfWork>();
		_dbSeeder = new DbSeeder(_unitOfWork);

	}

	[Fact]
	public async Task Seed_Should_CallSeedCategories_And_SeedBlogPosts()
	{

		// Arrange
		_unitOfWork.Category.AnyAsync(_ => true).Returns(false);
		_unitOfWork.BlogPost.AnyAsync(_ => true).Returns(false);

		// Act
		await _dbSeeder.Seed();

		// Assert
		await _unitOfWork.Category.Received(1).AddRangeAsync(Arg.Any<IEnumerable<Category>>());
		await _unitOfWork.BlogPost.Received(1).AddRangeAsync(Arg.Any<IEnumerable<BlogPost>>());
		await _unitOfWork.Received(2).CompleteAsync();

	}

	[Fact]
	public async Task SeedCategories_ShouldAddCategories_WhenNoneExist()
	{

		// Arrange
		_unitOfWork.Category.AnyAsync(_ => true).Returns(false);

		// Act
		await _dbSeeder.Seed();

		// Assert
		await _unitOfWork.Category.Received(1).AddRangeAsync(Arg.Any<IEnumerable<Category>>());
		await _unitOfWork.Received(2).CompleteAsync();

	}

	[Fact]
	public async Task SeedBlogPosts_ShouldAddBlogPosts_WhenNoneExist()
	{

		// Arrange
		_unitOfWork.BlogPost.AnyAsync(_ => true).Returns(false);

		// Act
		await _dbSeeder.Seed();

		// Assert
		await _unitOfWork.BlogPost.Received(1).AddRangeAsync(Arg.Any<IEnumerable<BlogPost>>());
		await _unitOfWork.Received(2).CompleteAsync();

	}

}