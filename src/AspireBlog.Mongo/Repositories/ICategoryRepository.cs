// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ICategoryRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Common
// =============================================

using AspireBlog.Common.Entities;

namespace AspireBlog.Mongo.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
}