// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     LoginModelTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(LoginModel))]
public class LoginModelTests
{
	[Fact(DisplayName = "LoginModel should be valid with valid data")]
	public void LoginModel_Should_Be_Valid_With_Valid_Data()
	{
		var model = new LoginModel
		{
			Username = "test@example.com",
			Password = "ValidPassword123"
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeTrue();
		validationResults.Should().BeEmpty();
	}

	[Fact(DisplayName = "LoginModel should be invalid with missing username")]
	public void LoginModel_Should_Be_Invalid_With_Missing_Username()
	{
		var model = new LoginModel
		{
			Password = "ValidPassword123"
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeFalse();
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(LoginModel.Username)));
	}

	[Fact(DisplayName = "LoginModel should be invalid with invalid email format")]
	public void LoginModel_Should_Be_Invalid_With_Invalid_Email_Format()
	{
		var model = new LoginModel
		{
			Username = "invalid-email",
			Password = "ValidPassword123"
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeFalse();
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(LoginModel.Username)));
	}

	[Fact(DisplayName = "LoginModel should be invalid with missing password")]
	public void LoginModel_Should_Be_Invalid_With_Missing_Password()
	{
		var model = new LoginModel
		{
			Username = "test@example.com"
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeFalse();
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(LoginModel.Password)));
	}

	[Fact(DisplayName = "LoginModel should be invalid with short password")]
	public void LoginModel_Should_Be_Invalid_With_Short_Password()
	{
		var model = new LoginModel
		{
			Username = "test@example.com",
			Password = "short"
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeFalse();
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(LoginModel.Password)));
	}

	[Fact(DisplayName = "LoginModel should be invalid with long password")]
	public void LoginModel_Should_Be_Invalid_With_Long_Password()
	{
		var model = new LoginModel
		{
			Username = "test@example.com",
			Password = new string('a', 26)
		};

		var validationResults = new List<ValidationResult>();
		var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

		isValid.Should().BeFalse();
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(LoginModel.Password)));
	}
}