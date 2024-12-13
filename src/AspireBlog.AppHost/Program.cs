using Projects;

var builder = DistributedApplication.CreateBuilder(args);

#region Add Redis Cache

IResourceBuilder<RedisResource> cache = builder.AddRedis(OutputCache);

#endregion

#region Add MongoDB Database

var db = builder.AddMongoDB("db")
	.WithMongoExpress()
	.AddDatabase(MongoDbName);

#endregion

#region Add Web Project

builder.AddProject<AspireBlog_Web>("WebUI").WithReference(cache).WithReference(db);

#endregion

builder.Build().Run();