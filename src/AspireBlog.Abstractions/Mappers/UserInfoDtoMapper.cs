// set

namespace AspireBlog.Abstractions.Mappers;

/// <summary>
///   Provides methods to map User related entities to UserDto.
/// </summary>
public static class UserInfoDtoMapper
{
	/// <summary>
	///   Maps UserInfo to UserInfoDto
	/// </summary>
	/// <param name="userInfo"></param>
	/// <returns>UserInfoDto</returns>
	public static UserInfoDto MapToUserInfoDto(this UserInfo userInfo)
	{
		return new UserInfoDto
		{
			UserId = userInfo.UserId, Name = userInfo.Name, Email = userInfo.Email, Roles = userInfo.Roles
		};
	}

	/// <summary>
	///   Maps UserInfoDto to UserInfo
	/// </summary>
	/// <param name="userInfoDto"></param>
	/// <returns>UserInfo</returns>
	public static UserInfo MapToUserInfo(this UserInfoDto userInfoDto)
	{
		return new UserInfo
		{
			UserId = userInfoDto.UserId, Name = userInfoDto.Name, Email = userInfoDto.Email, Roles = userInfoDto.Roles
		};
	}

	/// <summary>
	///   Maps User to UserInfoDto
	/// </summary>
	/// <param name="user"></param>
	/// <returns>UserInfoDto</returns>
	public static UserInfoDto MapToUserInfoDto(this User user)
	{
		return new UserInfoDto
		{
			UserId = user.Id.ToString(), Name = user.FullName ?? string.Empty, Email = user.Email, Roles = user.Roles ?? []
		};
	}
}