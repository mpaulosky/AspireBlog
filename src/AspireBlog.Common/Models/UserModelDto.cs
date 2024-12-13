// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

namespace AspireBlog.Common.Models;

/// <summary>
///   Data Transfer Object for User entity.
/// </summary>
public class UserModelDto
{
	/// <summary>
	///   Gets or sets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	[BsonId]
	[BsonElement("_id")]
	[Key]
	[Required]
	public ObjectId Id { get; init; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the name of the user.
	/// </summary>
	/// <value>
	///   The name of the user.
	/// </value>
	[BsonElement("name")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(50)]
	public string? Name { get; init; }

	/// <summary>
	///   Gets or sets the email of the user.
	/// </summary>
	/// <value>
	///   The email of the user.
	/// </value>
	[BsonElement("email")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(100)]
	public string? Email { get; init; }

	/// <summary>
	///   Gets or sets the roles of the user.
	/// </summary>
	/// <value>
	///   The roles of the user.
	/// </value>
	[BsonElement("roles")]
	[Required]
	public string[]? Roles { get; init; }
}