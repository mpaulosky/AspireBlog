namespace AspireBlog.Common.Models;

/// <summary>
///   Represents a data transfer object for user information.
/// </summary>
public class UserInfoDto
{
	/// <summary>
	///   Gets or sets the unique identifier for the user.
	/// </summary>
	public required ObjectId Id { get; init; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the name of the user.
	/// </summary>
	public required string? Name { get; init; }

	/// <summary>
	///   Gets or sets the email of the user.
	/// </summary>
	public required string? Email { get; init; }

	/// <summary>
	///   Gets or sets the roles assigned to the user.
	/// </summary>
	public string[]? Roles { get; init; }
}