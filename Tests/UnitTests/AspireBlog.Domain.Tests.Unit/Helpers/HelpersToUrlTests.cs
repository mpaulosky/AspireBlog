// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     HelpersToUrlTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     HelpersToUrlTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Helpers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Helpers))]
public class HelpersToUrlTests
{

	[Fact]
	public void ToUrl_ShouldReturnCorrectUri_WhenDateAndSlugAreValid()
	{

		// Arrange
		var date = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

		var slug = "test-slug";

		var expectedUri = new Uri("/20250101/test-slug", UriKind.Relative);

		// Act
		var result = slug.ToUrl(date);

		// Assert
		result.Should().Be(expectedUri);

	}

}