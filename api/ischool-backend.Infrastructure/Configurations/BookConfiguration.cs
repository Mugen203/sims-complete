using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums; // Make sure you have your Enums namespace

namespace ischool_backend.Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Get the LibraryId of the Main Library 
        var mainLibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"); 
        builder.HasData(
            new Book
            {
                BookID = new Guid("f549e035-5bd2-487a-867d-7ea5d1fd0ebd"),
                Title = "Introduction to C# Programming",
                Author = "John Doe",
                ISBN = "9781234567890",
                Category = BookCategory.Technology,
                BookStatus = BookStatus.Available,
                LibraryId = mainLibraryId, 
                Library = new Library // Create inline Library instance for navigation property
                {
                    LibraryId = mainLibraryId, 
                    LibraryName = "Main Library",
                    Location = "Central Campus"
                }
            },
            new Book
            {
                BookID = new Guid("8e739c1c-3563-47ed-863b-e9a90af61c88"),
                Title = "Data Structures and Algorithms",
                Author = "Jane Smith",
                ISBN = "9780987654321",
                Category = BookCategory.NonFiction,
                BookStatus = BookStatus.Available,
                LibraryId = mainLibraryId,
                Library = new Library
                {
                    LibraryId = mainLibraryId,
                    LibraryName = "Main Library",
                    Location = "Central Campus"
                }
            }
        );
    }
}