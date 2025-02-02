// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     MethodResultTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     MethodResultTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.ModelsTests;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(MethodResult))]
public class MethodResultTests
{

	[Fact]
	public void Success_ShouldReturnMethodResultWithTrueStatus()
	{
		// Act
		var result = MethodResult.Success();

		// Assert
		result.Status.Should().BeTrue();
		result.ErrorMessage.Should().BeNull();
	}

	[Fact]
	public void Failure_WithErrorMessage_ShouldReturnMethodResultWithFalseStatusAndErrorMessage()
	{
		// Arrange
		var errorMessage = "An error occurred";

		// Act
		var result = MethodResult.Failure(errorMessage);

		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be(errorMessage);
	}

	// [Fact]
	// public void Failure_WithFormattedMessage_ShouldReturnMethodResultWithFalseStatusAndFormattedMessage()
	// {
	// 	// Arrange
	// 	var message = "Error {0}";
	// 	var arg = "occurred";
	//
	// 	// Act
	// 	var result = MethodResult.Failure(message, arg);
	//
	// 	// Assert
	// 	result.Status.Should().BeFalse();
	// 	result.ErrorMessage.Should().Be("Error occurred");
	// }

}