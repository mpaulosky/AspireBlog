// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     Helpers.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Abstractions.Helpers;

public static class Helpers
{

	public static string GetSlug(string? item)
	{

		Guard.Against.NullOrEmpty(item, nameof(item));

		var slug = item.ToLower().Replace(" ", "-");

		// UrlEncode the slug
		slug = System.Web.HttpUtility.UrlEncode(slug);

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