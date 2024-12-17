// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ServiceNames.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBLog.Abstractions
// =============================================

namespace AspireBlog.Abstractions.Constants;

/// <summary>
///   Constants for referencing the services in the application
/// </summary>
public static class ServiceNames
{

	public const string ServerName = "posts-server";

	public const string MongoDbName = "posts-database";

	public const string OutputCache = "output-cache";

	public const string WebApp = "web-frontend";

}