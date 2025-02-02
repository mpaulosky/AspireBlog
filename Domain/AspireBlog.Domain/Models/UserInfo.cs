// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Models;

public class UserInfo
{

	public required string UserId { get; set; }

	public required string Name { get; set; }

	public required string Email { get; set; }

	public required string[] Roles { get; set; }

	public static readonly UserInfoDto Empty = new()
	{
			UserId = string.Empty, Name = string.Empty, Email = string.Empty, Roles = []
	};

}