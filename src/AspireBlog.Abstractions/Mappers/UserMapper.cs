// set

namespace AspireBlog.Abstractions.Mappers;

/// <summary>
///   Provides methods to map User related entities to UserDto.
/// </summary>
public static class UserMapper
{
	/// <summary>
	///   Maps User to UserDto
	/// </summary>
	/// <param name="user"></param>
	/// <returns>UserDto</returns>
	public static UserDto MapToUserDto(this User user)
	{
		return new UserDto
		{
			Id = user.Id,
			FirstName = user.FirstName,
			LastName = user.LastName,
			FullName = user.FullName,
			Email = user.Email,
			Roles = user.Roles
		};
	}

	/// <summary>
	///   Maps UserDto to User
	/// </summary>
	/// <param name="userDto"></param>
	/// <returns>User</returns>
	public static User MapToUser(this UserDto userDto)
	{
		return new User
		{
			Id = userDto.Id,
			FirstName = userDto.FirstName,
			LastName = userDto.LastName,
			FullName = userDto.FullName,
			Email = userDto.Email,
			Roles = userDto.Roles
		};
	}

	/// <summary>
	///   Maps User to UserInfo
	/// </summary>
	/// <param name="user"></param>
	/// <returns>UserInfo</returns>
	public static UserInfo MapToUserInfo(this User user)
	{
		return new UserInfo
		{
			UserId = user.Id.ToString(), Name = user.FullName ?? string.Empty, Email = user.Email, Roles = user.Roles ?? []
		};
	}
}