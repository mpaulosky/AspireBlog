// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Data.Mongo.Implementation;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	private readonly BlogDbContext _context;

	public UserRepository(BlogDbContext context) : base(context)
	{
		_context = Guard.Against.Null(context, nameof(context));
	}

	public LoggedInUser? LoginUser(LoginModel model)
	{
		// Check if the category already exists
		bool exists = _context.Users!.Any(c => c.Email == model.Username);

		if (exists)
		{
			// Login success
			User dbUser = _context.Users!.First(c => c.Email == model.Username);
			return new LoggedInUser(dbUser.Id, $"{dbUser.FirstName} {dbUser.LastName}".Trim());
		}

		// Login failed
		return null;
	}
}