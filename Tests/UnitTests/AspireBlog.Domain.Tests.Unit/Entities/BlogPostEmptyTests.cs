// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostEmptyTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// =======================================================

// ======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     BlogPostEmptyTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain.Tests.Unit
// ========================================================

namespace AspireBlog.Domain.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPost))]
public class BlogPostEmpty
{

	[Fact]
	public void Empty_BlogPost_ShouldReturnABlogPostWithEmptyValues()
	{

		//Arrange
		var expected = new BlogPost
		{
				Slug = string.Empty,
				Title = string.Empty,
				Introduction = string.Empty,
				ImageUrl = string.Empty,
				Content = string.Empty,
				CreatedOn = null,
				IsPublished = false,
				PublishedOn = null,
				ModifiedOn = null,
				Category = CategoryDto.Empty,
				Author = UserInfoDto.Empty
		};

		//Act
		var actual = BlogPost.Empty;

		//Assert
		actual.Should().BeEquivalentTo(expected);

	}

}