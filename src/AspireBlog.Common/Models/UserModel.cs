namespace AspireBlog.Common.Models;

public class UserModel
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