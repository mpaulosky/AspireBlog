namespace AspireBlog.Common.Models;

/// <summary>
///   Represents a userDto in the Aspire Blog.
/// </summary>
public class UserDto
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
	public ObjectId Id { get; set; } = ObjectId.Empty;

	/// <summary>
	///   Gets or sets the first name of the user.
	/// </summary>
	/// <remarks>
	///   The first name is required and has a maximum length of 25 characters.
	/// </remarks>
	[BsonElement("first-name")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(25)]
	public string? FirstName { get; init; }

	/// <summary>
	///   Gets or sets the last name of the user.
	/// </summary>
	/// <remarks>
	///   The last name has a maximum length of 25 characters.
	/// </remarks>
	[BsonElement("last-name")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(25)]
	public string? LastName { get; init; }

	/// <summary>
	///   Gets or sets the full name of the user.
	/// </summary>
	/// <remarks>
	///   The last name has a maximum length of 50 characters.
	/// </remarks>
	[BsonElement("full-name")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(50)]
	public string? FullName { get; init; }
	
	/// <summary>
	///   Gets or sets the email of the user.
	/// </summary>
	/// <remarks>
	///   The email is required and has a maximum length of 100 characters.
	/// </remarks>
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