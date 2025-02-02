// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ServiceNames.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Constants;

public class ServiceNames
{

	public string ServerName { get; } = "posts-server";

	public string MongoDbName { get; } = "posts-database";

	public string OutputCache { get; } = "output-cache";

	public string WebApp { get; } = "web-frontend";

	public string CategoryCacheName { get; } = "CategoryData";

	public string BlogPostCacheName { get; } = "BlogPostData";

}