using AspireBlog.Common.Entities;

using MongoDB.Driver;

using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;

namespace AspireBlog.Mongo.Context;

public class BlogDbContext : DbContext
{
	public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
	{
	}

	public static BlogDbContext Create(IMongoDatabase database) =>
		new(new DbContextOptionsBuilder<BlogDbContext>()
			.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
			.Options);

	public DbSet<Category>? Categories { get; set; }
	public DbSet<User>? Users { get; set; }
	public DbSet<BlogPost>? BlogPosts { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
#if DEBUG
		optionsBuilder.LogTo(Console.WriteLine);
#endif
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<User>()
			.HasData(
				new User
				{
					Id = ObjectId.GenerateNewId(),
					Email = "matthew.paulosky@outlook.com",
					FirstName = "Matthew",
					LastName = "Paulosky",
					FullName = "Matthew Paulosky",
					Roles = ["Admin"]
				}
			);
	}
}