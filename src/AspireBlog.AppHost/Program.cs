using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

#region Add Redis Cache

IResourceBuilder<RedisResource>? cache = builder.AddRedis("cache");

#endregion

#region Add Web Project

builder.AddProject<AspireBlog_Web>("WebApp")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WaitFor(cache);

#endregion

builder.Build().Run();