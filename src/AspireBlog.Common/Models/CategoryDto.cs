// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CategoryDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

namespace AspireBlog.Common.Models;

/// <summary>
///   Data Transfer Object for Category entity.
/// </summary>
public class CategoryDto
{
	private string? _categoryName;

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
	public ObjectId Id { get; set; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the name of the category.
	/// </summary>
	/// <value>
	///   The name of the category.
	/// </value>
	[BsonElement("category_name")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(120)]
	[Required]
	public string? CategoryName
	{
		get => _categoryName;
		init
		{
			_categoryName = value;
			if (_categoryName != null)
			{
				Slug = string.IsNullOrEmpty(Slug) ? Uri.EscapeDataString(_categoryName.ToLowerInvariant()) : Slug;
			}
		}
	}
	
	[Required]
	[MaxLength(125)]
	public string? Slug { get; init; }

	/// <summary>
	///   Gets or sets a value indicating whether this <see cref="Category" /> is archived.
	/// </summary>
	/// <value>
	///   <c>true</c> if archived; otherwise, <c>false</c>.
	/// </value>
	[BsonElement("archived")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsArchived { get; set; }

	/// <summary>
	///   Gets or sets who archived the record.
	/// </summary>
	/// <value>
	///   Who archived the record.
	/// </value>
	public UserDto? ArchivedBy { get; set; } = new();
}