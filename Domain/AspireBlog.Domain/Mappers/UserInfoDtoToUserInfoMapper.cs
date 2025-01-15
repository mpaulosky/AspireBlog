// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDtoToUserInfoMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Mappers;

public static class UserInfoDtoToUserInfoMapper
{

	public static UserInfo MapToUserInfo(this UserInfoDto userInfoDto)
	{

		return new UserInfo
		{
				UserId = userInfoDto.UserId, Name = userInfoDto.Name, Email = userInfoDto.Email, Roles = userInfoDto.Roles
		};

	}

}