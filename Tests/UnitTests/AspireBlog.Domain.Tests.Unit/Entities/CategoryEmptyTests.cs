// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryEmptyTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryEmptyTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Category))]
public class CategoryEmptyTests
{

	[Fact]
	public void Empty_Category_ShouldReturnACategoryWithEmptyValues()
	{

		//Arrange
		var expected = Category.Empty;

		//Act
		var actual = Category.Empty;

		//Assert
		actual.Should().BeEquivalentTo(expected);

	}

}