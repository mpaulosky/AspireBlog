namespace Aspire.Common.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(User))]
public class UserTests
{
	[Fact]
	public void User_Should_Have_Default_Id()
	{
		// Arrange
		var user = new User();

		// Act & Assert
		user.Id.Should().Be(ObjectId.Empty);
	}

	[Fact]
	public void User_Should_Require_FirstName()
	{
		// Arrange
		var user = new User { FirstName = null };

		// Act
		var validationResults = ValidateModel(user);

		// Assert
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(User.FirstName)));
	}

	[Fact]
	public void User_Should_Require_Email()
	{
		// Arrange
		var user = new User { Email = null };

		// Act
		var validationResults = ValidateModel(user);

		// Assert
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(User.Email)));
	}

	[Fact]
	public void User_Should_Require_Roles()
	{
		// Arrange
		var user = new User { Roles = null };

		// Act
		var validationResults = ValidateModel(user);

		// Assert
		validationResults.Should().ContainSingle(vr => vr.MemberNames.Contains(nameof(User.Roles)));
	}

	private IList<ValidationResult> ValidateModel(User user)
	{
		var validationResults = new List<ValidationResult>();
		var validationContext = new ValidationContext(user);
		Validator.TryValidateObject(user, validationContext, validationResults, true);
		return validationResults;
	}
}