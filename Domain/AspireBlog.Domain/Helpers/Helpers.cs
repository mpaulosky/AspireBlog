// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Helpers.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Helpers;

public static class Helpers
{

	public static string GetSlug(this string? item)
	{

		Guard.Against.NullOrEmpty(item, nameof(item));

		var slug = item.ToLower().Replace(" ", "-");

		// UrlEncode the slug
		slug = HttpUtility.UrlEncode(slug);

		return slug;

	}

	public static Uri ToUrl(DateTimeOffset date, string slug)
	{

		return new Uri($"/{date.UtcDateTime:yyyyMMdd}/{slug}", UriKind.Relative);

	}

}