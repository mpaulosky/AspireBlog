// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IUserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

namespace AspireBlog.Mongo.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
	LoggedInUser? LoginUser(LoginModel model);
}