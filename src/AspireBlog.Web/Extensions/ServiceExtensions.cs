// set

#region

using Ardalis.GuardClauses;

using AspireBlog.Data.Mongo.Context;
using AspireBlog.Data.Mongo.Implementation;
using AspireBlog.Data.Mongo.Repositories;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

using static AspireBlog.Abstractions.Constants.ServiceNames;

#endregion

namespace AspireBlog.Web.Extensions;

public static class ServiceExtensions
{
	public static void AddDbContextFactory(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		string? connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
		Guard.Against.Empty(connectionString, nameof(connectionString));

		builder.Services.AddPooledDbContextFactory<BlogDbContext>(options =>
		{
			var mongoClient = new MongoClient(MongoClientSettings.FromConnectionString(connectionString));
			options.UseMongoDB(mongoClient, MongoDbName);
		});

		// builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
		// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
		// builder.Services.AddScoped<IUserRepository, UserRepository>();

		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}