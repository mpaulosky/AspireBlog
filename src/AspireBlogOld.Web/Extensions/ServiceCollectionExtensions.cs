// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     test.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Web
// =============================================

namespace AspireBlog.Web.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddDbContextFactory(this IServiceCollection services)
	{
		services.AddPooledDbContextFactory<BlogDbContext>(options =>
			options.UseSqlite("Data Source=TodoApp.db"));

		//This is needed for running the migrations
		services.AddDbContext<TodoDataContext>(options => options.UseSqlite("Data Source=TodoApp.db"));

		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}