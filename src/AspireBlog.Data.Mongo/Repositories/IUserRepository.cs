// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IUserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Data.Mongo.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
	LoggedInUser? LoginUser(LoginModel model);
}