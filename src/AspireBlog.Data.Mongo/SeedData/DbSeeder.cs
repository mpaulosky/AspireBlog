// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     DbSeeder.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Data.Mongo
// =============================================

namespace AspireBlog.Data.Mongo.SeedData;

public class DbSeeder
{
	private readonly IUnitOfWork _unitOfWork;

	protected DbSeeder(IUnitOfWork unitOfWork)
	{
		_unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
	}

	public async Task Seed()
	{
		await SeedUsers();
		await SeedCategories();
		await SeedBlogPosts();
	}

	private async Task SeedUsers()
	{
		if (!await _unitOfWork.User.AnyAsync(_ => true))
		{
			var users = new List<User>
			{
				new User
				{
					Id = ObjectId.GenerateNewId(),
					Email = "matthew.paulosky@outlook.com",
					FirstName = "Matthew",
					LastName = "Paulosky",
					FullName = "Matthew Paulosky",
					Roles = ["Admin"]
				}
			};

			_unitOfWork.User.AddRange(users);
			await _unitOfWork.CompleteAsync();
		}
	}

	private async Task SeedCategories()
	{
		if (!await _unitOfWork.Category.AnyAsync(_ => true))
		{
			var categories = new List<Category>
			{
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
				},
				new Category
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Blazor WebAssembly",
					Slug = Helpers.GetSlug("Blazor WebAssembly"),
					IsArchived = false,
					ArchivedBy = null
				},
				new Category
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "C#",
					Slug = Helpers.GetSlug("C#"),
					IsArchived = false,
					ArchivedBy = null
				},
				new Category
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Entity Framework Core (EF Core)",
					Slug = Helpers.GetSlug("Entity Framework Core (EF Core)"),
					IsArchived = false,
					ArchivedBy = null
				},
				new Category
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = ".NET MAUI",
					Slug = Helpers.GetSlug(".NET MAUI"),
					IsArchived = false,
					ArchivedBy = null
				},
				new Category
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Other",
					Slug = Helpers.GetSlug("Other"),
					IsArchived = false,
					ArchivedBy = null
				}
			};

			_unitOfWork.Category.AddRange(categories);
			await _unitOfWork.CompleteAsync();
		}
	}


	private async Task SeedBlogPosts()
		{
			if (!await _unitOfWork.BlogPost.AnyAsync(_ => true))
			{
				var blogPosts = new List<BlogPost>
				{
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
						Author = (await _unitOfWork.User.FirstAsync(u => u.Email == "matthew.paulosky@outlook.com")).MapToUserDto(),
						Category = (await _unitOfWork.Category.FirstAsync(c => c.CategoryName == "Blazor Server")).MapToCategoryDto()
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
						Author = (await _unitOfWork.User.FirstAsync(u => u.Email == "matthew.paulosky@outlook.com")).MapToUserDto(),
						Category = (await _unitOfWork.Category.FirstAsync(c => c.CategoryName == "Blazor Server")).MapToCategoryDto()
					}
				};

				_unitOfWork.BlogPost.AddRange(blogPosts);
				await _unitOfWork.CompleteAsync();
			}
		}
	}