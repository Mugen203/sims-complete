using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the Student entity, defining constraints and seed data.
/// Implements IEntityTypeConfiguration{Student} to configure the Student entity in the DbContext.
/// </summary>
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    /// <summary>
    /// Configures the Student entity for data seeding and constraint setup.
    /// Implements the Configure method from IEntityTypeConfiguration{Student}.
    /// Seeds initial Student data and configures any specific constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Configure One-to-One relationship between Student and FeeAccount
        builder.HasOne(s => s.FeeAccount) // Student has one FeeAccount
            .WithOne(fa => fa.Student) // FeeAccount belongs to one Student
            .HasForeignKey<FeeAccount>(fa => fa.StudentID) // FeeAccount's FK is StudentID
            .IsRequired() // FeeAccount is required for each Student
            .OnDelete(DeleteBehavior.Cascade); // Configure Cascade Delete

        // Configure One-to-Many relationship: Student has many BorrowRequests
        builder.HasMany(s => s.BorrowRequests) // Student has many BorrowRequests (collection nav property)
            .WithOne(br => br.Student)     // Each BorrowRequest belongs to one Student (reference nav property in BorrowRequest)
            .HasForeignKey(br => br.StudentId) // Foreign key in BorrowRequest is StudentId
            .OnDelete(DeleteBehavior.Restrict);
        
        // Seed data for Student entity using anonymous type
        builder.HasData(
            new
            {
                StudentID = "222CS01000694",
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
                IsInternational = false
            }
        );
    }
}