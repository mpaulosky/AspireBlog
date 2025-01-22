// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ServiceNamesTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Constants;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ServiceNames))]
public class ServiceNamesTests
{

	[Fact]
	public void ShouldReturnServiceName()
	{

		// Arrange
		var serviceNames = new ServiceNames();
		var serverName = "posts-server";
		var mongoDbName = "posts-database";
		var outputCache = "output-cache";
		var webApp = "web-frontend";
		var categoryCacheName = "CategoryData";
		var blogPostCacheName = "BlogPostData";

		// Act
		var actualServerName = serviceNames.ServerName;
		var actualMongoDbName = serviceNames.MongoDbName;
		var actualOutputCache = serviceNames.OutputCache;
		var actualWebApp = serviceNames.WebApp;
		var actualCategoryCacheName = serviceNames.CategoryCacheName;
		var actualBlogPostCacheName = serviceNames.BlogPostCacheName;

		// Assert
		actualServerName.Should().Be(serverName);
		actualMongoDbName.Should().Be(mongoDbName);
		actualOutputCache.Should().Be(outputCache);
		actualWebApp.Should().Be(webApp);
		actualCategoryCacheName.Should().Be(categoryCacheName);
		actualBlogPostCacheName.Should().Be(blogPostCacheName);

	}

}