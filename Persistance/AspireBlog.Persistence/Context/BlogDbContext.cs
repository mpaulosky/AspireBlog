// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogDbContext.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// =======================================================

namespace AspireBlog.Persistence.Context;

public class BlogDbContext : DbContext
{

	public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

	public DbSet<Category> Categories { get; set; }

	public virtual DbSet<BlogPost> BlogPosts { get; set; }

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

	}

}