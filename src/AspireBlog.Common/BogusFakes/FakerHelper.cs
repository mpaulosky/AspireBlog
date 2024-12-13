// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakerHelper.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : Auth0Blog
// Project Name :  Blogs.Common
// =============================================

namespace AspireBlog.Common.BogusFakes;

/// <summary>
/// Provides helper methods for generating fake data.
/// </summary>
public static class FakerHelper
{
	/// <summary>
	/// Gets a random seed value.
	/// </summary>
	/// <returns>A random integer between 10 and <see cref="int.MaxValue"/>.</returns>
	public static int GetSeedValue()
	{
		return Random.Shared.Next(10, int.MaxValue);
	}
}