// set

#region

using System.Web;

#endregion

namespace AspireBlog.Abstractions.Helpers;

public static class Helpers
{
	public static string GetSlug(this string? item)
	{
		Guard.Against.NullOrEmpty(item, nameof(item));

		string? slug = item.ToLower().Replace(" ", "-");

		// UrlEncode the slug
		slug = HttpUtility.UrlEncode(slug);

		return slug;
	}

	public static Uri ToUrl(DateTime? date, string? slug)
	{
		Guard.Against.Null(date, nameof(date));
		Guard.Against.NullOrEmpty(slug, nameof(slug));

		string formatedDate = date.Value.ToString("yyyyMMdd") ?? string.Empty;

		return new Uri($"/{formatedDate}/{slug}", UriKind.Relative);
	}
}