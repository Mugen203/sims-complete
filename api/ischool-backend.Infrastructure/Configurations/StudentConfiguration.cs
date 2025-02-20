// StudentConfiguration.cs
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for seeding data and configuring relationships for the Student entity.
/// Implements the <see cref="IEntityTypeConfiguration{Student}"/> interface.
/// </summary>
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    /// <summary>
    /// Configures the Student entity for data seeding and relationship setup.
    /// Defines a one-to-one relationship with FeeAccount and seeds initial Student data.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Configure one-to-one relationship between Student and FeeAccount
        builder.HasOne(s => s.FeeAccount)
            .WithOne(f => f.Student)
            .HasForeignKey<FeeAccount>(f => f.StudentID)
            .IsRequired(); // FeeAccount is required for each Student

        // Seed data for Student and FeeAccount entities
        var feeAccount = new FeeAccount // Create FeeAccount instance for seeding
        {
            StudentID = "222CS01000694",
            AcademicYear = "2024-2025",
            TotalFeeDue = 1000m,
            TotalFeePaid = 500m,
            Currency = Currency.GHS,
            Semester = Semester.September
        };

        var student = new Student // Create Student instance for seeding
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
            IsInternational = false,
            FeeAccount = feeAccount // Assign the created FeeAccount to the Student
        };
        feeAccount.Student = student; // Set the Student navigation property in FeeAccount to create bidirectional relationship

        builder.HasData(student); // Seed the Student entity, which will cascade-seed the FeeAccount due to relationship
    }
}