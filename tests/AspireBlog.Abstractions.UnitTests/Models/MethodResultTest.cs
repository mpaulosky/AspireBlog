// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MethodResultTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions.UnitTests
// =============================================

namespace AspireBlog.Abstractions.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(MethodResult))]
public class MethodResultTest
{
	[Fact]
	public void MethodResult_Success_ReturnsTrueStatus()
	{
		// Act
		var result = MethodResult.Success();
		
		// Assert
		result.Status.Should().BeTrue();
		result.ErrorMessage.Should().BeNull();

	}
	
	[Fact]
	public void MethodResult_Failure_ReturnsFalseStatusAndErrorMessage()
	{
		// Arrange
		const string errorMessage = "An error occurred";
		
		// Act
		var result = MethodResult.Failure(errorMessage);
		
		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().Be(errorMessage);

	}

	[Fact]
	public void MethodResult_DefaultConstructor_ReturnsFalseStatusAndNullErrorMessage()
	{
		
		// Act
		var result = new MethodResult();
		
		// Assert
		result.Status.Should().BeFalse();
		result.ErrorMessage.Should().BeNull();
		
	}
}