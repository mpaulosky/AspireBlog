// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserInfo.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.Models;

/// <summary>
///   Represents a user in the system.
/// </summary>
public class UserInfo
{
	/// <summary>
	///   Gets or sets the unique identifier for the user.
	/// </summary>
	public required ObjectId Id { get; set; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the name of the user.
	/// </summary>
	public required string? Name { get; init; }

	/// <summary>
	///   Gets or sets the email of the user.
	/// </summary>
	public required string? Email { get; init; }

	/// <summary>
	///   Gets or sets the roles assigned to the user.
	/// </summary>
	public required string[]? Roles { get; init; }
}