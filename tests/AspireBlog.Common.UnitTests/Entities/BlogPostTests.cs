namespace Aspire.Common.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(BlogPost))]
public class BlogPostTests
{
	[Fact]
	public void Title_SetTitle_ShouldSetSlug()
	{
		// Arrange
		BlogPost blogPost = new BlogPost {
			// Act
			Title = "Test Title" };

		// Assert
		blogPost.Slug.Should().Be("test%20title");
	}

	[Fact]
	public void Title_SetTitle_ShouldNotChangeExistingSlug()
	{
		// Arrange
		BlogPost blogPost = new BlogPost { Slug = "existing-slug", // Act
			Title = "New Title" };

		// Assert
		blogPost.Slug.Should().Be("existing-slug");
	}

	[Fact]
	public void BlogPost_DefaultValues_ShouldBeSetCorrectly()
	{
		// Arrange & Act
		BlogPost blogPost = new BlogPost();

		// Assert
		blogPost.Id.Should().Be(ObjectId.Empty);
		blogPost.Title.Should().BeNull();
		blogPost.Slug.Should().BeNull();
		blogPost.Introduction.Should().BeNull();
		blogPost.Content.Should().BeNull();
		blogPost.CreatedOn.Should().BeNull();
		blogPost.IsPublished.Should().BeFalse();
		blogPost.PublishedOn.Should().BeNull();
		blogPost.ModifiedOn.Should().BeNull();
		blogPost.ImageUrl.Should().BeNull();
		blogPost.Category.Should().BeNull();
		blogPost.Author.Should().BeNull();
	}
}