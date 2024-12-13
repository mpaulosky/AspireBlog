// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Common
// =============================================

namespace AspireBlog.Common.Mappers;

/// <summary>
///   Provides methods to map User related entities to UserDto.
/// </summary>
public static class UserDtoMapper
{
	/// <summary>
	///   Maps UserModel to UserDto
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
}