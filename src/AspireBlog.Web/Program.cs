WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Add service defaults.

builder.AddServiceDefaults();

#endregion Add service defaults.

// TODO: Add authentication fix errors
// Issue URL: https://github.com/mpaulosky/AspireBlog/issues/19

builder.Services
	.AddAuth0WebAppAuthentication(options =>
	{
		options.Domain = builder.Configuration["Auth0:Authority"] ?? "";
		options.ClientId = builder.Configuration["Auth0:ClientId"] ?? "";
	});

builder.Services.AddCascadingAuthenticationState();

// Add BlogDbContextFactory

builder.AddMongoDBClient(MongoDbName);

builder.RegisterBlogDbContextFactory();

// Register Redis Output Cache
builder.RegisterRedisOutputCache();

// Register Implementations of the repositories
builder.RegisterImplementations();

// Register the services
builder.RegisterServices();

// Register the application services
builder.RegisterApplicationServices();

WebApplication app = builder.Build();

app.AddAppSettings();

app.Run();