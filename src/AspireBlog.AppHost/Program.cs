IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

#region Add Redis Cache

var cache = builder.AddRedis("cache");

#endregion

#region Add Web Project

builder.AddProject<Projects.AspireBlog_Web>("WebApp")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WaitFor(cache);


#endregion

builder.Build().Run();