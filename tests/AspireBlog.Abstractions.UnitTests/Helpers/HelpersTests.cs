// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     t.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions.UnitTests
// =============================================

namespace AspireBlog.Abstractions.Helpers;

public class HelpersTests
{
	[Fact]
	public void GetSlug_ShouldReturnSlug_WhenValidStringIsProvided()
	{
		// Arrange
		var input = "Hello World";
		var expected = "hello-world";

		// Act
		var result = Helpers.GetSlug(input);

		// Assert
		result.Should().Be(expected);
	}

	[Fact]
	public void GetSlug_ShouldThrowArgumentException_WhenNullOrEmptyStringIsProvided()
	{
		// ArrangeS
		string? input = null;

		// Act
		Action act = () => Helpers.GetSlug(input);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'item')");
	}

	[Fact]
	public void ToUrl_ShouldReturnUri_WhenValidDateAndSlugAreProvided()
	{
		// Arrange
		var date = new DateTime(2024, 1, 1);
		var slug = "hello-world";
		var expected = new Uri("/20240101/hello-world", UriKind.Relative);

		// Act
		var result = Helpers.ToUrl(date, slug);

		// Assert
		result.Should().Be(expected);
	}

	[Fact]
	public void ToUrl_ShouldThrowArgumentException_WhenDateIsOutOfRange()
	{
		// Arrange
		DateTime? date = null;
		const string slug = "hello-world";

		// Act
		Action act = () => Helpers.ToUrl(date, slug);

		// Assert
		act.Should().Throw<ArgumentException>()
			.WithMessage("Value cannot be null. (Parameter 'date')");
	}

	[Fact]
	public void ToUrl_ShouldThrowArgumentException_WhenSlugIsNullOrEmpty()
	{
		// Arrange
		var date = new DateTime(2024, 1, 1);
		string? slug = null;

		// Act
		Action act = () => Helpers.ToUrl(date, slug);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'slug')");
	}
}