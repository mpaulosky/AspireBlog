// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Program.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.UI
// =======================================================

#region

using AspireBlog.UI.Components;
using AspireBlog.Domain.Constants;
using Blazored.SessionStorage;

#endregion

using AspireBlog.Persistence;
using AspireBlog.Persistence.Context;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

builder.Services.AddMemoryCache();

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddDbContextFactory<BlogDbContext>(options =>
{

	var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") ?? throw new InvalidOperationException("Environment variable 'MONGODB_URI' is not set.");
	var databaseName = new ServiceNames().MongoDbName;
	var mongoClient = new MongoClient(MongoClientSettings.FromConnectionString(connectionString));

	options.UseMongoDB(mongoClient, databaseName);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", true);

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

app.Run();