// set

namespace AspireBlog.Abstractions.Constants;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ServiceNames))]
public class ServiceNamesTests
{
	[Fact]
	public void ServerName_ShouldBe_PostsServer()
	{
		ServiceNames.ServerName.Should().Be("posts-server");
	}

	[Fact]
	public void MongoDbName_ShouldBe_PostsDatabase()
	{
		ServiceNames.MongoDbName.Should().Be("posts-database");
	}

	[Fact]
	public void OutputCache_ShouldBe_OutputCache()
	{
		ServiceNames.OutputCache.Should().Be("output-cache");
	}

	[Fact]
	public void WebApp_ShouldBe_WebFrontend()
	{
		ServiceNames.WebApp.Should().Be("web-frontend");
	}
}