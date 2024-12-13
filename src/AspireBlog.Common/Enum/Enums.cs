// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Enums.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

namespace AspireBlog.Common.Enum;

/// <summary>
///   Gender enum
/// </summary>
public enum Gender
{
	Male = 0,
	Female = 1
}

/// <summary>
///   Roles enum
/// </summary>
public enum Roles
{
	Author = 0,
	Admin = 1,
	User = 2
}

/// <summary>
/// Category enum
/// </summary>
public enum CategoryNames
{
	AspNetCore = 0,
	BlazorServer = 1,
	BlazorWasm = 2,
	EntityFrameworkCore = 3,
	NetMaui = 4,
	Other = 5
}