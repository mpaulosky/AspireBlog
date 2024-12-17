namespace AspireBlog.Abstractions.Models;

[ExcludeFromCodeCoverage]
public readonly record struct LoggedInUser(ObjectId UserId, string DisplayName)
{
	public readonly bool IsEmpty => UserId == ObjectId.Empty;
}