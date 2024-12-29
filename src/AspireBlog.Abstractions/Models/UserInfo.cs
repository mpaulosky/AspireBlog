// set

namespace AspireBlog.Abstractions.Models;

/// <summary>
///   Represents a user in the system.
/// </summary>
public class UserInfo
{
	public required string UserId { get; set; }
	public required string Name { get; set; }
	public required string? Email { get; set; }
	public required string[] Roles { get; set; }
}