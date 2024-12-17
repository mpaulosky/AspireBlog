namespace AspireBlog.AppHost;

public static class MongoDbExtensions
{

	public static IResourceBuilder<MongoDBDatabaseResource> 
		AddMongoDbService(this IDistributedApplicationBuilder builder)
	{

		IResourceBuilder<MongoDBServerResource> dbServer = builder.AddMongoDB(ServerName)
			.WithDataVolume($"{MongoDbName}-data")
			.WithLifetime(ContainerLifetime.Persistent)
			.WithMongoExpress(config =>
			{
				// config.WithImageTag("latest");
				config.WithLifetime(ContainerLifetime.Persistent);
			});

		var outDb = dbServer.AddDatabase(MongoDbName);

		return (outDb);

	}

}