// set

namespace AspireBlog.Abstractions.Mappers;

/// <summary>
///   Provides methods to map Category related entities to CategoryDto.
/// </summary>
public static class CategoryDtoMapper
{
	/// <summary>
	///   Maps Category to CategoryDto.
	/// </summary>
	/// <param name="category">The Category object to map.</param>
	/// <returns>A CategoryDto object.</returns>
	public static CategoryDto MapToCategoryDto(this Category category)
	{
		Guard.Against.Null(category, nameof(category));

		return new CategoryDto
		{
			Id = Guard.Against.EmptyObjectId(category!.Id, nameof(category.Id)),
			CategoryName = Guard.Against.NullOrWhiteSpace(category!.CategoryName!, nameof(category.CategoryName)),
			Slug = Guard.Against.NullOrWhiteSpace(category!.Slug!, nameof(category.Slug)),
			IsArchived = category.IsArchived,
			ArchivedBy = category.ArchivedBy
		};
	}
}