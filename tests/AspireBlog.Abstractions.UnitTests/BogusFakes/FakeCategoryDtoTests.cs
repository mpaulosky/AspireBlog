// set

namespace AspireBlog.Abstractions.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategoryDto))]
public class FakeCategoryDtoTests
{
	[Fact(DisplayName = "FakeCategoryDto GetNewCategoryDto Test with keepId false")]
	public void GetNewCategoryDto_Should_Return_Category_Without_Id_When_KeepId_Is_False()
	{
		// Act
		CategoryDto? categoryDto = FakeCategoryDto.GetNewCategoryDto();

		// Assert
		categoryDto.Id.Should().Be(ObjectId.Empty);

		categoryDto.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto.IsArchived.Should().BeFalse();
		categoryDto.ArchivedBy.Should().BeNull();
	}

	[Fact(DisplayName = "FakeCategoryDto GetNewCategoryDto Test with keepId true and useSeed true")]
	public void GetNewCategoryDto_Should_Return_Category_With_Id_When_KeepId_Is_True_And_UseSeed_Is_True()
	{
		// Act
		CategoryDto? categoryDto = FakeCategoryDto.GetNewCategoryDto(true, true);
		CategoryDto? categoryDto2 = FakeCategoryDto.GetNewCategoryDto(true, true);

		// Assert
		categoryDto.Id.Should().NotBe(ObjectId.Empty);

		categoryDto.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto.IsArchived.Should().BeFalse();
		categoryDto.ArchivedBy.Should().BeNull();

		categoryDto2.Id.Should().NotBe(ObjectId.Empty);

		categoryDto2.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto2.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto2.IsArchived.Should().BeFalse();
		categoryDto2.ArchivedBy.Should().BeNull();

		categoryDto.Id.Should().NotBeSameAs(categoryDto2.Id);
		categoryDto.CategoryName.Should().BeEquivalentTo(categoryDto2.CategoryName);
		categoryDto.Slug.Should().BeEquivalentTo(categoryDto2.Slug);
		categoryDto.IsArchived.Should().Be(categoryDto2.IsArchived);
		categoryDto.ArchivedBy.Should().BeEquivalentTo(categoryDto2.ArchivedBy);
	}

	[Fact(DisplayName = "FakeCategoryDto GetNewCategoryDto Test with keepId true and useSeed false")]
	public void GetNewCategoryDto_Should_Return_Category_With_Id_When_KeepId_Is_True_And_UseSeed_Is_False()
	{
		// Act
		CategoryDto? categoryDto = FakeCategoryDto.GetNewCategoryDto(true);

		// Assert
		categoryDto.Id.Should().NotBe(ObjectId.Empty);

		categoryDto.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto.IsArchived.Should().BeFalse();
		categoryDto.ArchivedBy.Should().BeNull();
	}

	[Theory(DisplayName = "FakeCategoryDto GetCategoryDtos Test with use new seed")]
	[InlineData(1, false)]
	[InlineData(5, false)]
	public void GetCategoryDtos_With_UseSeed_Is_False_Should_Return_FakeCategories_That_Are_The_Same_Test(
		int countRequested,
		bool useSeed)
	{
		// Act
		List<CategoryDto>? categoryDtos = FakeCategoryDto.GetCategoryDtos(countRequested, useSeed);
		List<CategoryDto>? categoryDtos2 = FakeCategoryDto.GetCategoryDtos(countRequested, useSeed);

		// Assert
		for (int i = 0; i < categoryDtos.Count; i++)
		{
			categoryDtos[i].Id.Should().NotBeSameAs(categoryDtos2[i].Id);

			categoryDtos[i].CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
				"Blazor WASM", "Entity Framework Core (EF Core)",
				".NET MAUI", "Other");

			categoryDtos[i].Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
				"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
				".net%20maui", "other");

			if (categoryDtos[i].IsArchived)
			{
				if (categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}

				if (!categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}
			}

			if (!categoryDtos[i].IsArchived)
			{
				if (!categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().BeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}

				if (categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}
			}
		}
	}

	[Theory(DisplayName = "FakeCategoryDto GetCategoryDtos Test with use useSeed true")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetCategoryDtos_With_UseSeed_Is_True_Should_Return_FakeCategoryDtos_That_Are_Different_Test(
		int countRequested,
		bool useSeed)
	{
		// Act
		List<CategoryDto>? categoryDtos = FakeCategoryDto.GetCategoryDtos(countRequested, useSeed);
		List<CategoryDto>? categoryDtos2 = FakeCategoryDto.GetCategoryDtos(countRequested, useSeed);

		// Assert
		for (int i = 0; i < categoryDtos.Count; i++)
		{
			categoryDtos[i].Id.Should().NotBeSameAs(categoryDtos2[i].Id);

			categoryDtos[i].CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
				"Blazor WASM", "Entity Framework Core (EF Core)",
				".NET MAUI", "Other");

			categoryDtos[i].Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
				"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
				".net%20maui", "other");

			if (categoryDtos[i].IsArchived)
			{
				if (categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}

				if (!categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}
			}

			if (!categoryDtos[i].IsArchived)
			{
				if (!categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().BeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}

				if (categoryDtos2[i].IsArchived)
				{
					categoryDtos[i].ArchivedBy.Should().NotBeEquivalentTo(categoryDtos2[i].ArchivedBy);
				}
			}
		}
	}

	[Fact]
	public void FakeData_ShouldReturnNonNullCategoryDto_WhenCalled()
	{
		// Act
		CategoryDto? result = FakeCategoryDto.FakeData();

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public void FakeData_ShouldHaveCategoryName_WhenCalled()
	{
		// Act
		CategoryDto? result = FakeCategoryDto.FakeData();

		// Assert
		result.CategoryName.Should().NotBeNullOrEmpty();
		result.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");
	}

	[Fact]
	public void FakeData_ShouldHaveId_WhenCalled()
	{
		// Act
		CategoryDto? result = FakeCategoryDto.FakeData();

		// Assert
		result.Id.Should().NotBe(ObjectId.Empty);
	}

	[Fact]
	public void FakeData_ShouldHandleIsArchivedCorrectly_WhenCalled()
	{
		// Act
		CategoryDto? result = FakeCategoryDto.FakeData();

		// Assert
		if (result.IsArchived)
		{
			result.ArchivedBy.Should().NotBeNull();
		}
		else
		{
			result.ArchivedBy.Should().BeNull();
		}
	}

	[Fact]
	public void FakeData_Should_Generate_Consistent_Data_When_UseSeed_Is_True()
	{
		// Act
		CategoryDto? categoryDto = FakeCategoryDto.FakeData(true);
		CategoryDto? categoryDto2 = FakeCategoryDto.FakeData(true);

		// Assert
		categoryDto.Id.Should().NotBeSameAs(categoryDto2.Id);

		categoryDto.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto2.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto2.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		if (categoryDto.IsArchived)
		{
			if (categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}

			if (!categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}
		}

		if (!categoryDto.IsArchived)
		{
			if (!categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().BeEquivalentTo(categoryDto2.ArchivedBy);
			}

			if (categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}
		}
	}

	[Fact]
	public void FakeData_Should_Generate_Different_Data_When_UseSeed_Is_False()
	{
		// Act
		CategoryDto? categoryDto = FakeCategoryDto.FakeData();
		CategoryDto? categoryDto2 = FakeCategoryDto.FakeData();

		// Assert
		categoryDto.Id.Should().NotBeSameAs(categoryDto2.Id);

		categoryDto.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		categoryDto2.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server",
			"Blazor WASM", "Entity Framework Core (EF Core)",
			".NET MAUI", "Other");

		categoryDto2.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server",
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29",
			".net%20maui", "other");

		if (categoryDto.IsArchived)
		{
			if (categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}

			if (!categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}
		}

		if (!categoryDto.IsArchived)
		{
			if (!categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().BeEquivalentTo(categoryDto2.ArchivedBy);
			}

			if (categoryDto2.IsArchived)
			{
				categoryDto.ArchivedBy.Should().NotBeEquivalentTo(categoryDto2.ArchivedBy);
			}
		}
	}
}