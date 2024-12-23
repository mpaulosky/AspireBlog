// set

namespace AspireBlog.Abstractions.Models;

public class UserInfoDto
{
	public required string UserId { get; set; }
	public required string Name { get; set; }
	public required string? Email { get; set; }
	public required string[] Roles { get; set; }
}