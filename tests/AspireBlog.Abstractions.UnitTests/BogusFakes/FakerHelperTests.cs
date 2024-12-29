// set

namespace AspireBlog.Abstractions.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakerHelper))]
public class FakerHelperTests
{
	[Fact(DisplayName = "GetSeedValue Should Return Value Between 10 And IntMaxValue")]
	public void GetSeedValue_Should_Return_Value_Between_10_And_IntMaxValue()
	{
		// Act
		int seedValue = FakerHelper.GetSeedValue();

		// Assert
		seedValue.Should().BeInRange(10, int.MaxValue);
	}

	[Fact(DisplayName = "GetSeedValue Should Return Different Values On Subsequent Calls")]
	public void GetSeedValue_Should_Return_Different_Values_On_Subsequent_Calls()
	{
		// Act
		int firstSeedValue = FakerHelper.GetSeedValue();
		int secondSeedValue = FakerHelper.GetSeedValue();

		// Assert
		firstSeedValue.Should().NotBe(secondSeedValue);
	}
}