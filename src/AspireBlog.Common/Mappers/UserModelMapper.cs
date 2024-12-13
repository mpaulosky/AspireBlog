// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserModelMapper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Common
// =============================================

namespace AspireBlog.Common.Mappers;

/// <summary>
///   Provides methods to map User related entities to UserModel.
/// </summary>
public static class UserModelMapper
{
	
	/// <summary>
	///   Maps UserInfo to UserModel.
	/// </summary>
	/// <param name="userInfo">The UserInfo object to map.</param>
	/// <returns>A UserModel object.</returns>
	public static UserModel MapToUserModel(this UserInfo userInfo)
	{
		
		return new UserModel
		{
			
			Id = userInfo.Id, 
			Email = userInfo.Email, 
			Name = userInfo.Name, 
			Roles = userInfo.Roles
			
		};
		
	}

	/// <summary>
	///   Maps UserModelDto to UserModel.
	/// </summary>
	/// <param name="userModelDto">The UserModelDto object to map.</param>
	/// <returns>A UserModel object.</returns>
	public static UserModel MapToUserModel(this UserModelDto userModelDto)
	{
		
		return new UserModel
		{
			
			Id = userModelDto.Id, 
			Name = userModelDto.Name, 
			Email = userModelDto.Email, 
			Roles = userModelDto.Roles
			
		};
		
	}
	
}