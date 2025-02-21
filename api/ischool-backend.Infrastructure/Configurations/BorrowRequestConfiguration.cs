using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;
using System;

namespace ischool_backend.Infrastructure.Configurations;

public class BorrowRequestConfiguration : IEntityTypeConfiguration<BorrowRequest>
{
    public void Configure(EntityTypeBuilder<BorrowRequest> builder)
    {
        // **IMPORTANT**: Use existing StudentID and BookID from your StudentConfiguration and BookConfiguration seed data!

        var studentIdForBorrowRequest = "222CS01000694"; // **Replace with an ACTUAL StudentID from your StudentConfiguration.cs seed data**
        var bookIdForBorrowRequest1 = new Guid("f549e035-5bd2-487a-867d-7ea5d1fd0ebd"); 
        var bookIdForBorrowRequest2 = new Guid("8e739c1c-3563-47ed-863b-e9a90af61c88"); 

        builder.HasData(
            new BorrowRequest
            {
                BorrowRequestId = Guid.NewGuid(), // Generate a new Guid for BorrowRequestID
                StudentId = studentIdForBorrowRequest,
                BookId = bookIdForBorrowRequest1,    
                BorrowDate = DateTimeOffset.UtcNow.AddDays(-10), 
                ReturnDate = DateTimeOffset.UtcNow.AddMonths(1), 
                IsReturned = false,
                Status = BorrowRequestStatus.Approved, // Example Status

                Student = new Student // **Inline Student - full props (reuse data from StudentConfig)**
                {
                    StudentID = studentIdForBorrowRequest,
                    FirstName = "Kwaku",
                    LastName = "Affram",
                    DateOfBirth = new DateTimeOffset(new DateTime(2000, 1, 1)),
                    Gender = Gender.Male,
                    Address = "Kings and Queens Hostel, Oyibi, Ghana",
                    Email = "radahn@example.com",
                    Phone = "0553138727",
                    EnrollmentDate = DateTimeOffset.UtcNow.AddYears(-1),
                    DegreeProgram = "BSc Computer Science",
                    Major = "Cloud Security",
                    EnrollmentStatus = EnrollmentStatus.Active,
                    IsInternational = false,
                },
                Book = new Book
                {
                    BookID = bookIdForBorrowRequest1, // **MUST match BookId above**
                    Title = "Introduction to C# Programming",
                    Author = "John Doe",
                    ISBN = "9781234567890",
                    Category = BookCategory.Technology,
                    BookStatus = BookStatus.Available,
                    LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), // Main Library ID
                    Library = new Library
                    {
                        LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                        LibraryName = "Main Library",
                        Location = "Central Campus"
                    }
                }
            },
            new BorrowRequest
            {
                BorrowRequestId = Guid.NewGuid(),
                StudentId = studentIdForBorrowRequest, // **Reference the SAME StudentID or another**
                BookId = bookIdForBorrowRequest2,     // **Reference the BookID for Book 2**
                BorrowDate = DateTimeOffset.UtcNow.AddDays(-5),  // Example BorrowDate
                ReturnDate = DateTimeOffset.UtcNow.AddMonths(2),   // Example ReturnDate (2 months from now)
                IsReturned = false,
                Status = BorrowRequestStatus.Borrowed, 

                 Student = new Student 
                {
                    StudentID = studentIdForBorrowRequest,
                    FirstName = "Kwaku",
                    LastName = "Affram",
                    DateOfBirth = new DateTimeOffset(new DateTime(2000, 1, 1)),
                    Gender = Gender.Male,
                    Address = "Kings and Queens Hostel, Oyibi, Ghana",
                    Email = "radahn@example.com",
                    Phone = "0553138727",
                    EnrollmentDate = DateTimeOffset.UtcNow.AddYears(-1),
                    DegreeProgram = "BSc Computer Science",
                    Major = "Cloud Security",
                    EnrollmentStatus = EnrollmentStatus.Active,
                    IsInternational = false,
                },
                Book = new Book 
                {
                    BookID = bookIdForBorrowRequest2, // **MUST match BookId above**
                    Title = "Data Structures and Algorithms",
                    Author = "Jane Smith",
                    ISBN = "9780987654321",
                    Category = BookCategory.NonFiction,
                    BookStatus = BookStatus.Available,
                    LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                     Library = new Library
                    {
                        LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                        LibraryName = "Main Library",
                        Location = "Central Campus"
                    }
                }
            }
        );
    }
}