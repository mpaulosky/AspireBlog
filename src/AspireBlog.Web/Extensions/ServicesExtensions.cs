using Ardalis.GuardClauses;

using AspireBlog.Common.Interfaces;

using static AspireBlog.Common.Constants.ServiceNames;

using AspireBlog.Mongo.Context;
using AspireBlog.Mongo.Implementation;
using AspireBlog.Mongo.Repositories;
using AspireBlog.Mongo.Services;

using Auth0.AspNetCore.Authentication;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

namespace AspireBlog.Web.Extensions;

public static class ServicesExtensions
{
	public static void RegisterApplicationServices(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		#region Add RazorComponents and InteractiveServerComponents

		builder.Services.AddRazorComponents().AddInteractiveServerComponents();

		#endregion Add RazorComponents and InteractiveServerComponents

		#region Add Logging

		builder.Services.AddLogging(logging =>
		{
			logging.AddConsole();
			logging.AddDebug();
		});

		#endregion Add Logging

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();

		// Add QuickGrid Entity Framework Adapter
		builder.Services.AddQuickGridEntityFrameworkAdapter();

		// Add OutputCache
		builder.Services.AddDatabaseDeveloperPageExceptionFilter();
	}

	public static void AddAuthenticationService(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

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
	}

	public static void RegisterBlogDbContext(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		builder.AddMongoDBClient(MongoDbName);

		builder.Services.AddDbContextFactory<BlogDbContext>(options =>
		{
			var mongoDatabase =
				Guard.Against.Null(builder.Services.BuildServiceProvider().GetRequiredService<IMongoDatabase>());
			options.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
		});
	}

	public static void RegisterRedisOutputCache(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		#region Add OutputCache

		builder.AddRedisOutputCache(OutputCache);

		builder.Services.AddOutputCache(options =>
		{
			options.AddBasePolicy(policy => policy.Tag("ALL")
				.Expire(TimeSpan.FromMinutes(5)));

			options.AddPolicy("Home", policy => policy.Tag("Home")
				.Expire(TimeSpan.FromSeconds(30)));

			options.AddPolicy("BlogPost",
				policy => policy.Tag("BlogPost")
					.SetVaryByRouteValue("slug").Expire(TimeSpan.FromSeconds(30)));

			options.AddPolicy("Categories",
				policy => policy.Tag("Categories")
					.SetVaryByRouteValue("slug").Expire(TimeSpan.FromSeconds(30)));
		});

		#endregion Add OutputCache
	}

	public static void RegisterImplementations(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
		builder.Services.AddTransient<IBlogPostRepository, BlogPostRepository>();
		builder.Services.AddTransient<IUserRepository, UserRepository>();
		builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
	}

	public static void RegisterServices(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		builder.Services.AddSingleton<IBlogPostService, BlogPostService>()
			.AddSingleton<ICategoryService, CategoryService>()
			.AddSingleton<IUserService, UserService>();
	}

	public static void AddAppSettings(this WebApplication app)
	{
		Guard.Against.Null(app, nameof(app));

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");
	}
}