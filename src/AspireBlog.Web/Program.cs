using AspireBlog.Web.Extensions;

using Auth0.AspNetCore.Authentication;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#region Add service defaults.

builder.AddServiceDefaults();

#endregion Add service defaults.

builder.Services.AddCascadingAuthenticationState();

builder.Services
	.AddAuth0WebAppAuthentication(options =>
	{
		options.Domain = builder.Configuration["Auth0:Authority"] ?? "";
		options.ClientId = builder.Configuration["Auth0:ClientId"] ?? "";
	});

// Add Authentication Service
// builder.AddAuthenticationService();

// Add BlogDbContextFactory
builder.RegisterBlogDbContext();

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