// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Persistence
// =======================================================

namespace AspireBlog.Persistence.Implementation;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{

	public CategoryRepository(BlogDbContext context) : base(context) { }

}