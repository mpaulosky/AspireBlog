// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostCreateTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPost))]
public class BlogPostCreateTests
{

	[Fact]
	public void BlogPost_When_Created_ShouldReturnAValidBlogPost()
	{

		//Arrange
		var title = "ASP.NET Core";
		var content = "ASP.NET Core is a high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.";
		var introduction = "ASP.NET Core is a high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.";
		var slug = "asp-net-core";
		var imageUrl = "https://aspnetcore.com";
		var createdOn = DateTimeOffset.Now;
		var isPublished = true;
		var publishedOn = DateTimeOffset.Now;
		var modifiedOn = DateTimeOffset.Now;
		var category = new CategoryDto{ Slug = "aspnet-core", CategoryName = "ASP.NET Core" };
		var author = new UserInfoDto { UserId = ObjectId.GenerateNewId().ToString(), Name = "Jane Doe", Email = "jane.doe@test.com", Roles = ["Admin"] };

		//Act
		var actual = new BlogPost
		{
			Title = title,
			Content = content,
			Introduction = introduction,
			Slug = slug,
			ImageUrl = imageUrl,
			CreatedOn = createdOn,
			IsPublished = isPublished,
			PublishedOn = publishedOn,
			ModifiedOn = modifiedOn,
			Category = category,
			Author = author
		};

		//Assert
		actual.Title.Should().Be(title);

		actual.Content.Should().Be(content);

		actual.Introduction.Should().Be(introduction);

		actual.Slug.Should().Be(slug);

		actual.ImageUrl.Should().Be(imageUrl);

		actual.CreatedOn.Should().Be(createdOn);

		actual.IsPublished.Should().Be(isPublished);
	
		actual.PublishedOn.Should().Be(publishedOn);

		actual.ModifiedOn.Should().Be(modifiedOn);

		actual.Category.Should().BeEquivalentTo(category);

		actual.Author.Should().BeEquivalentTo(author);

	}

}