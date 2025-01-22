// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
/// Provides functionality to map data between <see cref="UserInfo"/> and <see cref="UserInfoDto"/> objects.
/// </summary>
public static class UserInfoMapper
{

	/// <summary>
	/// Maps a <see cref="UserInfo"/> instance to a <see cref="UserInfoDto"/> instance.
	/// </summary>
	/// <param name="userInfo">The <see cref="UserInfo"/> object to be mapped.</param>
	/// <returns>An instance of <see cref="UserInfoDto"/> containing the mapped data.</returns>
	public static UserInfoDto ToUserInfoDto(this UserInfo userInfo)
	{

		return new UserInfoDto
		{

				UserId = userInfo.UserId, Name = userInfo.Name, Email = userInfo.Email, Roles = userInfo.Roles

		};

	}


}