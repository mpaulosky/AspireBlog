namespace Aspire.Common.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Category))]
public class CategoryTests
{
	[Fact]
	public void Category_Should_Have_Default_Values()
	{
		// Arrange & Act
		Category category = new Category();

		// Assert
		category.Id.Should().Be(ObjectId.Empty);
		category.CategoryName.Should().BeNull();
		category.Slug.Should().BeNull();
		category.IsArchived.Should().BeFalse();
		category.ArchivedBy.Should().NotBeNull();
	}

	[Fact]
	public void CategoryName_Should_Set_Slug_When_Not_Already_Set()
	{
		// Arrange
		Category category = new Category();
		string categoryName = "Test Category";

		// Act
		category.CategoryName = categoryName;

		// Assert
		category.Slug.Should().Be(Uri.EscapeDataString(categoryName.ToLowerInvariant()));
	}

	[Fact]
	public void CategoryName_Should_Not_Change_Slug_When_Already_Set()
	{
		// Arrange
		Category category = new Category { Slug = "existing-slug" };
		string categoryName = "Test Category";

		// Act
		category.CategoryName = categoryName;

		// Assert
		category.Slug.Should().Be("existing-slug");
	}

	[Fact]
	public void Category_Should_Be_Archived()
	{
		// Arrange
		Category category = new Category {
			// Act
			IsArchived = true };

		// Assert
		category.IsArchived.Should().BeTrue();
	}
}