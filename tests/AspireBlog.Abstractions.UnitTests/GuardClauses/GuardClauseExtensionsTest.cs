// set

namespace AspireBlog.Abstractions.GuardClauses;

[TestSubject(typeof(GuardClauseExtensions))]
[ExcludeFromCodeCoverage]
public class GuardClauseExtensionsTest
{
	[Fact]
	public void EmptyObjectId_ShouldThrowArgumentException_WhenObjectIdIsEmpty()
	{
		// Arrange
		var guardClause = new GuardClause();
		ObjectId emptyObjectId = ObjectId.Empty;
		const string parameterName = "testParameter";

		// Act
		Action act = () => guardClause.EmptyObjectId(emptyObjectId, parameterName);

		// Assert
		act.Should().Throw<ArgumentException>()
			.WithMessage("Required input testParameter was empty. (Parameter 'testParameter')")
			.And.ParamName.Should().Be(parameterName);
	}

	[Fact]
	public void EmptyObjectId_ShouldReturnObjectId_WhenObjectIdIsNotEmpty()
	{
		// Arrange
		var guardClause = new GuardClause();
		var nonEmptyObjectId = new ObjectId("507f1f77bcf86cd799439011");
		string? parameterName = "testParameter";

		// Act
		ObjectId result = guardClause.EmptyObjectId(nonEmptyObjectId, parameterName);

		// Assert
		result.Should().Be(nonEmptyObjectId);
	}

	[Fact]
	public void EmptyObjectId_ShouldThrowCustomException_WhenObjectIdIsEmptyAndExceptionCreatorIsProvided()
	{
		// Arrange
		var guardClause = new GuardClause();
		ObjectId emptyObjectId = ObjectId.Empty;
		string? parameterName = "testParameter";
		Func<Exception> exceptionCreator = () => new InvalidOperationException("Custom exception message");

		// Act
		Action act = () => guardClause.EmptyObjectId(emptyObjectId, parameterName, exceptionCreator: exceptionCreator);

		// Assert
		act.Should().Throw<InvalidOperationException>()
			.WithMessage("Custom exception message");
	}
}

// Dummy implementation of IGuardClause for testing purposes
public class GuardClause : IGuardClause
{
}