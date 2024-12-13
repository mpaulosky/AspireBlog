namespace AspireBlog.Common.Models;

public class LoginModel
{
	[Required]
	[EmailAddress]
	[DataType(DataType.EmailAddress)]
	public string? Username { get; init; }

	[Required, MinLength(10), MaxLength(25), DataType(DataType.Password)] 
	public string? Password { get; set; }
}