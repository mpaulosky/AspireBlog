using System.Diagnostics.CodeAnalysis;

using AspireBlog.Common.Constants;

using FluentAssertions;

using JetBrains.Annotations;

namespace Aspire.Common.Constants;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ServiceNames))]
public class ServiceNamesTests
{
	[Test]
	public void ServerName_ShouldBe_PostsServer()
	{
		ServiceNames.ServerName.Should().Be("posts-server");
	}

	[Test]
	public void MongoDbName_ShouldBe_PostsDatabase()
	{
		ServiceNames.MongoDbName.Should().Be("posts-database");
	}

	[Test]
	public void Migration_ShouldBe_DatabaseMigration()
	{
		ServiceNames.Migration.Should().Be("database-migration");
	}

	[Test]
	public void OutputCache_ShouldBe_OutputCache()
	{
		ServiceNames.OutputCache.Should().Be("output-cache");
	}

	[Test]
	public void WebApp_ShouldBe_WebFrontend()
	{
		ServiceNames.WebApp.Should().Be("web-frontend");
	}

	[Test]
	public void WebUI_ShouldBe_WebUI()
	{
		ServiceNames.WebUI.Should().Be("web-ui");
	}
}
