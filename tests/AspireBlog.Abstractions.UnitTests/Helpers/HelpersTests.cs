// set

namespace AspireBlog.Abstractions.Helpers;

public class HelpersTests
{
	[Fact]
	public void GetSlug_ShouldReturnSlug_WhenValidStringIsProvided()
	{
		// Arrange
		string? input = "Hello World";
		string? expected = "hello-world";

		// Act
		string? result = input.GetSlug();

		// Assert
		result.Should().Be(expected);
	}

	[Fact]
	public void GetSlug_ShouldThrowArgumentException_WhenNullOrEmptyStringIsProvided()
	{
		// ArrangeS
		string? input = null;

		// Act
		Action act = () => input.GetSlug();

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'item')");
	}

	[Fact]
	public void ToUrl_ShouldReturnUri_WhenValidDateAndSlugAreProvided()
	{
		// Arrange
		var date = new DateTime(2024, 1, 1);
		string? slug = "hello-world";
		var expected = new Uri("/20240101/hello-world", UriKind.Relative);

		// Act
		Uri? result = Helpers.ToUrl(date, slug);

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