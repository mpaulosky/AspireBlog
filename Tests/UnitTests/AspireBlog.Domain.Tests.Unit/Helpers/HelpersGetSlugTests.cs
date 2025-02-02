// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     HelpersGetSlugTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     HelpersGetSlugTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Helpers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Helpers))]
public class HelpersGetSlugTests
{

	[Fact]
	public void GetSlug_ShouldReturnSlug_WhenInputIsValid()
	{

		// Arrange
		var input = "This is a Test";

		var expectedSlug = "this-is-a-test";

		// Act
		var result = input.GetSlug();

		// Assert
		result.Should().Be(expectedSlug);

	}

}