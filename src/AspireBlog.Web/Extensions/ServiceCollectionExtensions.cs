// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     test.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Web
// =============================================

using Ardalis.GuardClauses;

using AspireBlog.Data.Mongo.Context;
using AspireBlog.Data.Mongo.Implementation;
using AspireBlog.Data.Mongo.Repositories;

using static AspireBlog.Abstractions.Constants.ServiceNames;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

namespace AspireBlog.Web.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddDbContextFactory(this WebApplicationBuilder builder)
	{
		Guard.Against.Null(builder, nameof(builder));

		var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");

		builder.Services.AddPooledDbContextFactory<BlogDbContext>(options =>
		{

			Guard.Against.Empty(connectionString, nameof(connectionString));

			var mongoClient = new MongoClient(MongoClientSettings.FromConnectionString(connectionString));
			options.UseMongoDB(mongoClient, MongoDbName);
			
		});

		builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
		builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();

		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}