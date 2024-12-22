// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogDbContextTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Data.Mongo.UnitTests
// =============================================

//  namespace AspireBlog.Data.Mongo.Context;
//
//  [ExcludeFromCodeCoverage]
//  [TestSubject(typeof(BlogDbContext))]
//  public class BlogDbContextTests
//  {
//  	private readonly IMongoDatabase _mongoDatabase;
//
//  	public BlogDbContextTests()
//  	{
//  		var client = new MongoClient("mongodb://localhost:27017");
//  		_mongoDatabase = client.GetDatabase("TestDatabase");
//  	}
//
// 	 [Fact]
// 	 public void BlogDbContext_Should_Create_Instance()
// 	 {
// 	 	// Arrange
// 	 	DbContextOptions<BlogDbContext> options = new DbContextOptionsBuilder<BlogDbContext>()
// 	 		.UseMongoDB(_mongoDatabase.Client, _mongoDatabase.DatabaseNamespace.DatabaseName)
// 	 		.Options;
// 	
// 	 	// Act
// 	 	var context = new BlogDbContext(options);
// 	
// 	 	// Assert
// 	 	context.Should().NotBeNull();
// 	 }
//
// 	 [Fact]
// 	 public void BlogDbContext_Should_Have_DbSets()
// 	 {
// 	 	// Arrange
// 	 	DbContextOptions<BlogDbContext> options = new DbContextOptionsBuilder<BlogDbContext>()
// 	 		.UseMongoDB(_mongoDatabase.Client, _mongoDatabase.DatabaseNamespace.DatabaseName)
// 	 		.Options;
// 	
// 	 	// Act
// 	 	var context = new BlogDbContext(options);
// 	
// 	 	// Assert
// 	 	context.Categories.Should().NotBeNull();
// 	 	context.Users.Should().NotBeNull();
// 	 	context.BlogPosts.Should().NotBeNull();
// 	 }
//
// 	 [Fact]
// 	 public void BlogDbContext_Should_Configure_Logging_In_Debug_Mode()
// 	 {
// 	 	// Arrange
// 	 	var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
// 	
// 	 	// Act
// 	 	var context = new BlogDbContext(optionsBuilder.Options);
// 	 	context.Database.var mongoClient = (MongoClient)_mongoDatabase.Client;
// 	 	mongoClient.Settings.Servers = new[] 
// 	 		{ new MongoServerAddress("localhost", 27017) };
// 	
// 	 	// Assert
// 	 	if (System.Diagnostics.Debugger.IsAttached)
// 	 	{
// 	 		optionsBuilder.Options.FindExtension<CoreOptionsExtension>()
// 	 			.Should().NotBeNull()
// 	 			.And.Subject.As<CoreOptionsExtension>().LoggerFactory.Should().NotBeNull();
// 	 	}
// 	 }
//
// 	[Fact]
// 	public void BlogDbContext_Should_Seed_Data()
// 	{
// 		// Arrange
// 		var options = new DbContextOptionsBuilder<BlogDbContext>()
// 			.UseMongoDB(_mongoDatabase.Client, _mongoDatabase.DatabaseNamespace.DatabaseName)
// 			.Options;
//
// 		// Act
// 		var context = new BlogDbContext(options);
// 		context.Database.EnsureCreated();
//
// 		// Assert
// 		var user = context.Users!.FirstOrDefault(u => u.Email == "matthew.paulosky@outlook.com");
// 		user.Should().NotBeNull();
// 		user!.FirstName.Should().Be("Matthew");
// 		user.LastName.Should().Be("Paulosky");
// 		user.FullName.Should().Be("Matthew Paulosky");
// 		user.Roles.Should().Contain("Admin");
// 	}
// }