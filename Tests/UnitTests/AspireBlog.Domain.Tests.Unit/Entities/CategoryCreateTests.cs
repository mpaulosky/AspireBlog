// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryCreateTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryCreateTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Category))]
public class CategoryCreateTests
{

	[Fact]
	public void Category_When_Created_ShouldReturnAValidCategory()
	{

		//Arrange
		var slug = "aspnet-core";

		var categoryName = "ASP.NET Core";

		//Act
		var actual = new Category { Slug = "aspnet-core", CategoryName = "ASP.NET Core" };

		//Assert
		actual.Slug.Should().Be(slug);

		actual.CategoryName.Should().Be(categoryName);

	}

}