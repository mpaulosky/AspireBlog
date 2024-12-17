using AspireBlog.Abstractions.Helpers;

namespace AspireBlog.Data.Mongo.Context;

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

		modelBuilder.Entity<Category>()
			.HasData(

				new Category
				{

					Id = ObjectId.GenerateNewId(),
					CategoryName = "ASP.NET Core",
					Slug = Helpers.GetSlug("ASP.NET Core"),
					IsArchived = false,
					ArchivedBy = null

				},
				new Category
				{

					Id = ObjectId.GenerateNewId(),
					CategoryName = "Blazor Server",
					Slug = Helpers.GetSlug("Blazor Server"),
					IsArchived = false,
					ArchivedBy = null

				}

			);

		modelBuilder.Entity<BlogPost>()
			.HasData(

				new BlogPost
				{

					Id = ObjectId.GenerateNewId(),
					Title = "First Blog Post",
					Content = "This is the content of the first blog post.",
					Slug = Helpers.GetSlug("First Blog Post"),
					Introduction = "This is the introduction to the first blog post.",
					CreatedOn = DateTime.UtcNow,
					IsPublished = true,
					PublishedOn = DateTime.UtcNow,
					ModifiedOn = null,
					Author = new User
					{

						Id = ObjectId.GenerateNewId(),
						Email = "matthew.paulosky@outlook.com",
						FirstName = "Matthew",
						LastName = "Paulosky",
						FullName = "Matthew Paulosky",
						Roles = ["Admin"]

					}.MapToUserDto(),
					Category = new Category
					{

						Id = ObjectId.GenerateNewId(),
						CategoryName = "ASP.NET Core",
						Slug = Helpers.GetSlug("ASP.NET Core"),
						IsArchived = false,
						ArchivedBy = null

					}.MapToCategoryDto()

				},
				new BlogPost
				{

					Id = ObjectId.GenerateNewId(),
					Title = "Second Blog Post",
					Content = "This is the content of the second blog post.",
					Slug = Helpers.GetSlug("Second Blog Post"),
					Introduction = "This is the introduction to the second blog post.",
					CreatedOn = DateTime.UtcNow,
					IsPublished = true,
					PublishedOn = DateTime.UtcNow,
					ModifiedOn = null,
					Author = new User
					{

						Id = ObjectId.GenerateNewId(),
						Email = "matthew.paulosky@outlook.com",
						FirstName = "Matthew",
						LastName = "Paulosky",
						FullName = "Matthew Paulosky",
						Roles = ["Admin"]

					}.MapToUserDto(),
					Category = new Category
					{

						Id = ObjectId.GenerateNewId(),
						CategoryName = "Blazor Server",
						Slug = Helpers.GetSlug("Blazor Server"),
						IsArchived = false,
						ArchivedBy = null

					}.MapToCategoryDto()

				}

			);

	}

}