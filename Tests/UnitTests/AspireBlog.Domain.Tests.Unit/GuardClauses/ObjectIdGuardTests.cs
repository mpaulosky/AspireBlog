// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ObjectIdGuardTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ObjectIdGuardTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.GuardClauses;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GuardClauseExtensions))]
public class ObjectIdGuardTests
{

	[Fact]
	public void EmptyObjectId_ShouldThrowArgumentException_WhenObjectIdIsEmpty()
	{
		// Arrange
		var guardClause = Substitute.For<IGuardClause>();
		var emptyObjectId = ObjectId.Empty;
		var parameterName = "testParameter";

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
		var guardClause = Substitute.For<IGuardClause>();
		var nonEmptyObjectId = ObjectId.GenerateNewId();
		var parameterName = "testParameter";

		// Act
		var result = guardClause.EmptyObjectId(nonEmptyObjectId, parameterName);

		// Assert
		result.Should().Be(nonEmptyObjectId);
	}

}