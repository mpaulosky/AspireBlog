// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserInfoDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Models;

public class UserInfoDto
{

	[MaxLength(30)] public required string UserId { get; init; }

	[MaxLength(50)] public required string Name { get; init; }

	[MaxLength(100)] public required string Email { get; init; }

	[MaxLength(50)] public required string[] Roles { get; init; }

	public static readonly UserInfoDto Empty = new()
	{
			UserId = string.Empty, Name = string.Empty, Email = string.Empty, Roles = []
	};

}