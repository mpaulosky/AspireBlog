// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDto.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

namespace AspireBlog.Common.Models;

[Serializable]
public class BlogPostDto
{
	
	private string? _title;

	[BsonId] [BsonElement("_id")] [Key] public ObjectId Id { get; set; } = ObjectId.Empty;

	[Required]
	[MaxLength(120)]
	public string? Title
	{
		get => _title;
		set
		{
			_title = value;
			if (_title != null)
			{
				Slug = string.IsNullOrEmpty(Slug) ? Uri.EscapeDataString(_title.ToLowerInvariant()) : Slug;
			}
		}
	}

	[Required] [MaxLength(150)] public string? Slug { get; set; }

	[Required] [MaxLength(250)] public string? Introduction { get; set; }

	[Required] [MaxLength(10000)] public string? Content { get; set; }

	public DateTime? CreatedOn { get; set; }

	public bool IsPublished { get; set; }

	public DateTime? PublishedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }
	
	[MaxLength(100)] public string? ImageUrl { get; init; }

	public CategoryDto? Category { get; set; }

	public UserDto? Author { get; set; }

}