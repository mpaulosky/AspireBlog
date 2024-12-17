// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ILoginProvider.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp
// Project Name :  AspireBlog.Abstractions
// =============================================

namespace AspireBlog.Abstractions.Interfaces;

public interface ILoginProvider
{
	Task LoginAsync();
	Task LogoutAsync();
}