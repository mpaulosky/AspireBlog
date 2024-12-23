// set

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
				new()
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
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "ASP.NET Core",
					Slug = "ASP.NET Core".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Blazor Server",
					Slug = "Blazor Server".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Blazor WebAssembly",
					Slug = "Blazor WebAssembly".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "C#",
					Slug = "C#".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Entity Framework Core (EF Core)",
					Slug = "Entity Framework Core (EF Core)".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = ".NET MAUI",
					Slug = ".NET MAUI".GetSlug(),
					IsArchived = false,
					ArchivedBy = null
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					CategoryName = "Other",
					Slug = "Other".GetSlug(),
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
				new()
				{
					Id = ObjectId.GenerateNewId(),
					Title = "First Blog Post",
					Content = "This is the content of the first blog post.",
					Slug = "First Blog Post".GetSlug(),
					Introduction = "This is the introduction to the first blog post.",
					CreatedOn = DateTime.UtcNow,
					IsPublished = true,
					PublishedOn = DateTime.UtcNow,
					ModifiedOn = null,
					Author =
						(await _unitOfWork.User.FirstAsync(u => u.Email == "matthew.paulosky@outlook.com")).MapToUserDto(),
					Category =
						(await _unitOfWork.Category.FirstAsync(c => c.CategoryName == "Blazor Server")).MapToCategoryDto()
				},
				new()
				{
					Id = ObjectId.GenerateNewId(),
					Title = "Second Blog Post",
					Content = "This is the content of the second blog post.",
					Slug = "Second Blog Post".GetSlug(),
					Introduction = "This is the introduction to the second blog post.",
					CreatedOn = DateTime.UtcNow,
					IsPublished = true,
					PublishedOn = DateTime.UtcNow,
					ModifiedOn = null,
					Author =
						(await _unitOfWork.User.FirstAsync(u => u.Email == "matthew.paulosky@outlook.com")).MapToUserDto(),
					Category = (await _unitOfWork.Category.FirstAsync(c => c.CategoryName == "Blazor Server"))
						.MapToCategoryDto()
				}
			};

			_unitOfWork.BlogPost.AddRange(blogPosts);
			await _unitOfWork.CompleteAsync();
		}
	}
}