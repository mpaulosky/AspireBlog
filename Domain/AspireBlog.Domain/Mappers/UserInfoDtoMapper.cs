// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDtoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

/// <summary>
/// Provides utility methods for mapping between <see cref="UserInfoDto"/> and <see cref="UserInfo"/> objects.
/// </summary>
public static class UserInfoDtoMapper
{

	/// <summary>
	/// Maps a <see cref="UserInfoDto"/> object to a new <see cref="UserInfo"/> object.
	/// </summary>
	/// <param name="userInfoDto">The <see cref="UserInfoDto"/> instance to be mapped.</param>
	/// <returns>A new instance of <see cref="UserInfo"/> with properties populated from the <see cref="UserInfoDto"/>.</returns>
	public static UserInfo ToUserInfo(this UserInfoDto userInfoDto)
	{

		return new UserInfo
		{

				UserId = userInfoDto.UserId, Name = userInfoDto.Name, Email = userInfoDto.Email, Roles = userInfoDto.Roles

		};

	}

}