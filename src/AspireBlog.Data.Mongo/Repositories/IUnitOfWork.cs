// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IUnitOfWork.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Data.Mongo.Repositories;

public interface IUnitOfWork : IDisposable
{
	IBlogPostRepository BlogPost { get; }
	IUserRepository User { get; }
	ICategoryRepository Category { get; }
	Task<int> CompleteAsync();
}