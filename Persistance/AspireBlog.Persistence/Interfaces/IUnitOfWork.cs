// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IUnitOfWork.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// ========================================================

namespace AspireBlog.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{

	IBlogPostRepository BlogPost { get; }

	ICategoryRepository Category { get; }

	Task<int> CompleteAsync();

}