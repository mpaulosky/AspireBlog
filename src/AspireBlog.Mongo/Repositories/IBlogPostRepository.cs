// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IActorRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  BlazingBlog
// =============================================

using AspireBlog.Common.Entities;

namespace AspireBlog.Mongo.Repositories;

public interface IBlogPostRepository : IGenericRepository<BlogPost>;