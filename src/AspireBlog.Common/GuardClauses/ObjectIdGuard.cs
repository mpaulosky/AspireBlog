// Using the same namespace will make sure your code picks up your 
// extensions no matter where they are in your codebase.

namespace AspireBlog.Common.GuardClauses;

public static class GuardClauseExtensions
{
	public static ObjectId EmptyObjectId(this IGuardClause guardClause,
		ObjectId input,
		string parameterName,
		string? message = null,
		Func<Exception>? exceptionCreator = null)
	{
		if (input == ObjectId.Empty)
		{
			Exception? exception = exceptionCreator?.Invoke();

			throw exception ?? new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
		}

		return input;
	}
}