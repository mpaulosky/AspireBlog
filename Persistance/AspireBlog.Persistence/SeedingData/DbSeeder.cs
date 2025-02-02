// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DbSeeder.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// =======================================================

namespace AspireBlog.Persistence.SeedingData;

public class DbSeeder
{

	private readonly IUnitOfWork _unitOfWork;

	public DbSeeder(IUnitOfWork unitOfWork)
	{

		_unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));

	}

	public async Task Seed()
	{

		await SeedCategories();

		await SeedBlogPosts();

	}

	internal async Task SeedCategories()
	{

		if (!await _unitOfWork.Category.AnyAsync(_ => true))
		{

			var categories = new List<Category>
			{
					new() { CategoryName = "ASP.NET Core", Slug = "ASP.NET Core".GetSlug() },
					new() { CategoryName = "Blazor Server", Slug = "Blazor Server".GetSlug() },
					new() { CategoryName = "Blazor WebAssembly", Slug = "Blazor WebAssembly".GetSlug() },
					new() { CategoryName = "C#", Slug = "C#".GetSlug() },
					new()
					{
							CategoryName = "Entity Framework Core (EF Core)",
							Slug = "Entity Framework Core (EF Core)".GetSlug()
					},
					new() { CategoryName = ".NET MAUI", Slug = ".NET MAUI".GetSlug() },
					new() { CategoryName = "Other", Slug = "Other".GetSlug() }
			};

			await _unitOfWork.Category.AddRangeAsync(categories);

			await _unitOfWork.CompleteAsync();

		}

	}


	internal async Task SeedBlogPosts()
	{
		if (!await _unitOfWork.BlogPost.AnyAsync(_ => true))
		{
			var blogPosts = new List<BlogPost>
			{
					new()
					{
							Title = "First Blog Post",
							Content = "This is the content of the first blog post.",
							Slug = "First Blog Post".GetSlug(),
							Introduction = "This is the introduction to the first blog post.",
							CreatedOn = DateOnly.FromDateTime(DateTime.Now),
							IsPublished = true,
							PublishedOn = DateOnly.FromDateTime(DateTime.Now),
							ModifiedOn = null,
							Author = FakeUserInfoDto.GetNewUserInfoDto(true),
							Category = FakeCategoryDto.GetNewCategoryDto(true)
					},
					new()
					{
							Title = "Second Blog Post",
							Content = "This is the content of the second blog post.",
							Slug = "Second Blog Post".GetSlug(),
							Introduction = "This is the introduction to the second blog post.",
							CreatedOn = DateOnly.FromDateTime(DateTime.Now),
							IsPublished = true,
							PublishedOn = DateOnly.FromDateTime(DateTime.Now),
							ModifiedOn = null,
							Author = FakeUserInfoDto.GetNewUserInfoDto(true),
							Category = FakeCategoryDto.GetNewCategoryDto(true)
					}
			};

			await _unitOfWork.BlogPost.AddRangeAsync(blogPosts);

			await _unitOfWork.CompleteAsync();

		}

	}

}