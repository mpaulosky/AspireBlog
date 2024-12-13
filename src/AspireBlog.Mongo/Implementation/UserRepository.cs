// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

using Ardalis.GuardClauses;

using AspireBlog.Common.Entities;
using AspireBlog.Common.Models;
using AspireBlog.Mongo.Context;
using AspireBlog.Mongo.Repositories;

namespace AspireBlog.Mongo.Implementation;

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