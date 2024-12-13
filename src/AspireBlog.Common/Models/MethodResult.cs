namespace AspireBlog.Common.Models;

public record struct MethodResult(bool Status, string? ErrorMessage = null)
{
	public static MethodResult Success()
	{
		return new MethodResult(true);
	}

	public static MethodResult Failure(string errorMessage)
	{
		return new MethodResult(false, errorMessage);
	}
}