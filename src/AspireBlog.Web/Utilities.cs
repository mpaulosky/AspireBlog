// set

namespace AspireBlog.Web;

public static class Utilities
{
	private static readonly string[] ColorClasses = ["primary", "success", "info", "danger", "warning", "dark"];

	public static string GetRandomColorClass()
	{
		return ColorClasses.OrderBy(c => Guid.NewGuid()).First();
	}

	public static string? GetInitials(string? text)
	{
		const string? defaultInitials = "BB";
		if (string.IsNullOrEmpty(text))
		{
			return defaultInitials;
		}

		string[]? parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		if (parts.Length > 1)
		{
			return $"{parts[0][0]}{parts[1][0]}";
		}

		return text.Length > 1 ? text[..2] : text;
	}
}