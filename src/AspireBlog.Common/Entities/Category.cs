namespace AspireBlog.Common.Entities;

/// <summary>
///   Represents a category in the Aspire Blog.
/// </summary>
public class Category
{
	private string? _categoryName;

	/// <summary>
	///   Gets or sets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	/// <remarks>
	///   The Id is required.
	/// </remarks>
	[BsonId]
	[BsonElement("_id")]
	[Key]
	[Required]
	public ObjectId Id { get; set; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the name of the category.
	/// </summary>
	/// <remarks>
	///   The category name is required and has a maximum length of 100 characters.
	/// </remarks>
	[Required]
	[MaxLength(100)]
	public string? CategoryName
	{
		get => _categoryName;
		set
		{
			_categoryName = value;
			if (_categoryName != null)
			{
				Slug = string.IsNullOrEmpty(Slug) ? Uri.EscapeDataString(_categoryName.ToLowerInvariant()) : Slug;
			}
		}
	}

	/// <summary>
	///   Gets or sets the slug for the category.
	/// </summary>
	/// <remarks>
	///   The slug is a URL-friendly version of the category name and has a maximum length of 125 characters.
	/// </remarks>
	[Required]
	[MaxLength(125)]
	public string? Slug { get; set; }

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
	///   Gets or sets the user who archived the category.
	/// </summary>
	/// <value>
	///   The user who archived the category.
	/// </value>
	public UserDto? ArchivedBy { get; set; } = new();
}