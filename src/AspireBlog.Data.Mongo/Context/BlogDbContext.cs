// set

namespace AspireBlog.Data.Mongo.Context;

public class BlogDbContext : DbContext
{
	public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
	{
	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<BlogPost> BlogPosts { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Add an index to the BlogPost slug column
		modelBuilder.Entity<BlogPost>()
			.HasIndex(p => p.Slug)
			.IsUnique();

		// Add an index to the Category slug column
		modelBuilder.Entity<Category>()
			.HasIndex(p => p.Slug)
			.IsUnique();

		// Add an index to the User Id column
		modelBuilder.Entity<User>()
			.HasIndex(p => p.Id)
			.IsUnique();

		// Add an index to the BlogPost Id column
		modelBuilder.Entity<BlogPost>()
			.HasIndex(p => p.Id)
			.IsUnique();

		// Add an index to the Category Id column
		modelBuilder.Entity<Category>()
			.HasIndex(p => p.Id)
			.IsUnique();
		base.OnModelCreating(modelBuilder);
	}
}