// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeCategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : MyAspireBlogApp1
// Project Name :  AspireBlog.Common.UnitTests
// =============================================

namespace Aspire.Common.BogusFakes;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(FakeCategory))]
public class FakeCategoryTests
{
	
	[Fact(DisplayName = "FakeCategory GetNewCategory Test with keepId false")]
	public void GetNewCategory_Should_Return_Category_Without_Id_When_KeepId_Is_False()
	{
		
		// Act
		var category = FakeCategory.GetNewCategory(keepId: false, useSeed: false);

		// Assert
		category.Id.Should().Be(ObjectId.Empty);
		category.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
			"Blazor WASM", "Entity Framework Core (EF Core)", 
			".NET MAUI", "Other");
					
		category.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
			".net%20maui", "other");
		
		category.IsArchived.Should().BeFalse();
		category.ArchivedBy.Should().BeNull();
		
	}

	[Fact(DisplayName = "FakeCategory GetNewCategory Test with keepId true")]
	public void GetNewCategory_Should_Return_Category_With_Id_When_KeepId_Is_True()
	{
		
		// Act
		var category = FakeCategory.GetNewCategory(keepId: true);

		// Assert
		category.Id.Should().NotBe(ObjectId.Empty);
		category.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
			"Blazor WASM", "Entity Framework Core (EF Core)", 
			".NET MAUI", "Other");
					
		category.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
			".net%20maui", "other");
		
		category.IsArchived.Should().BeFalse();
		category.ArchivedBy.Should().BeNull();
		
	}

	[Fact(DisplayName = "FakeCategory GetNewCategory Test with keepId true and useSeed true")]
	public void GetNewCategory_Should_Return_Category_With_Id_When_KeepId_Is_True_And_UseSeed_Is_True()
	{
		
		// Act
		var category = FakeCategory.GetNewCategory(keepId: true, useSeed: true);

		// Assert
		category.Id.Should().NotBe(ObjectId.Empty);
		category.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
			"Blazor WASM", "Entity Framework Core (EF Core)", 
			".NET MAUI", "Other");
					
		category.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
			".net%20maui", "other");

		category.Slug.Should().NotBeNullOrEmpty();
		category.IsArchived.Should().BeFalse();
		category.ArchivedBy.Should().BeNull();
	}

	[Theory(DisplayName = "FakeCategory GetCategories Test with use new seed Is True")]
	[InlineData(1, true)]
	[InlineData(5, true)]
	public void GetCategories_With_UseSeed_Is_True_Should_Return_FakeCategories_That_Are_Different_Test(int countRequested,
		bool useSeed)
	{

		// Act
		var categories = FakeCategory.GetCategories(countRequested, useSeed);
		var categories2 = FakeCategory.GetCategories(countRequested, useSeed);

		// Assert
		for (int i = 0; i < categories.Count; i++)
		{
			categories[i].Id.Should().NotBeSameAs(categories2[i].Id);
				
			categories[i].CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
				"Blazor WASM", "Entity Framework Core (EF Core)", 
				".NET MAUI", "Other");
			
			categories[i].Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
				"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
				".net%20maui", "other");
			
				if (categories[i].IsArchived)
				{
					if (categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}

					if (!categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}
				}
				
				if (!categories[i].IsArchived)
				{
					if (!categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().BeEquivalentTo(categories2[i].ArchivedBy);
					}
					if (categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}
				}
			
		}
		
	}

	[Theory(DisplayName = "FakeCategory GetCategories Test with use new seed is False")]
		[InlineData(1, false)]
		[InlineData(5, false)]
		public void GetCategories_With_UseSeed_Is_False_Should_Return_FakeCategories_That_Are_The_Same_Test(int countRequested,
			bool useSeed)
		{
		
			// Act
			var categories = FakeCategory.GetCategories(countRequested, useSeed);
			var categories2  = FakeCategory.GetCategories(countRequested, useSeed);

			// Assert
			for (int i = 0; i < categories.Count; i++)
			{
				
				categories[i].Id.Should().NotBeSameAs(categories2[i].Id);
				
				categories[i].CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
					"Blazor WASM", "Entity Framework Core (EF Core)", 
					".NET MAUI", "Other");
			
				categories[i].Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
					"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
					".net%20maui", "other");
							
				categories2[i].CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
					"Blazor WASM", "Entity Framework Core (EF Core)", 
					".NET MAUI", "Other");
			
				categories2[i].Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
					"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
					".net%20maui", "other");
		
				if (categories[i].IsArchived)
				{
					if (categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}

					if (!categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}
				}
				
				if (!categories[i].IsArchived)
				{
					if (!categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().BeEquivalentTo(categories2[i].ArchivedBy);
					}
					if (categories2[i].IsArchived)
					{
						categories[i].ArchivedBy.Should().NotBeEquivalentTo(categories2[i].ArchivedBy);
					}
				}
				
			}

		}
		
	[Fact(DisplayName = "FakeData should generate valid Category when useSeed is false")]
	public void FakeData_Should_Generate_Valid_Category_When_UseSeed_Is_False()
	{
		
		// Act
		var category = FakeCategory.FakeData(useSeed: false);

		// Assert
		category.Id.Should().NotBe(ObjectId.Empty);
		category.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
			"Blazor WASM", "Entity Framework Core (EF Core)", 
			".NET MAUI", "Other");
		
		category.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
			".net%20maui", "other");

		if (category.IsArchived)
		{
			category.ArchivedBy.Should().NotBeNull();
		}
		else
		{
			category.ArchivedBy.Should().BeNull();
		}
		
	}
	
			
	[Fact(DisplayName = "FakeData should generate valid Category when useSeed is true")]
	public void FakeData_Should_Generate_Valid_Category_When_UseSeed_Is_True()
	{
		
		// Act
		var category = FakeCategory.FakeData(useSeed: false);

		// Assert
		category.Id.Should().NotBe(ObjectId.Empty);
		
		category.CategoryName.Should().BeOneOf("ASP.NET Core", "Blazor Server", 
			"Blazor WASM", "Entity Framework Core (EF Core)", 
			".NET MAUI", "Other");
		
		category.Slug.Should().BeOneOf("asp.net%20core", "blazor%20server", 
			"blazor%20wasm", "entity%20framework%20core%20%28ef%20core%29", 
			".net%20maui", "other");
		
		if (category.IsArchived)
		{
			category.ArchivedBy.Should().NotBeNull();
		}
		else
		{
			category.ArchivedBy.Should().BeNull();
		}

	}
}