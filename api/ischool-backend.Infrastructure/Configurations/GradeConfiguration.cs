using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the Grade entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{Grade} to configure the Grade entity in the DbContext.
/// </summary>
public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    /// <summary>
    ///     Configures the Grade entity for data seeding, relationships, and constraints.
    ///     Implements the Configure method from IEntityTypeConfiguration{Grade}.
    ///     Seeds initial Grade data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        // Configure required navigation properties with auto-include
        // Ensures Student and Course navigation properties are always loaded when querying Grades
        builder.Navigation(g => g.Student)
            .IsRequired()
            .AutoInclude();

        builder.Navigation(g => g.Course)
            .IsRequired()
            .AutoInclude();

        // Configure relationships and cascading behavior
        builder.HasOne(g => g.Student)
            .WithMany(s => s.Grades) // Assuming Student entity has Grades collection
            .HasForeignKey(g => g.StudentID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior

        builder.HasOne(g => g.Course)
            .WithMany(c => c.Grades) // Assuming Course entity has Grades collection
            .HasForeignKey(g => g.CourseCode)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior


        // Reference existing StudentID and CourseCode for data seeding
        const string studentIdForGrade = "222CS01000694";
        const string courseCodeForGrade = "COSC240";

        // Seed initial Grade data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                GradeID = Guid.NewGuid(), // Generate Guid for GradeID
                StudentID = studentIdForGrade, // Foreign key - StudentID, reference existing StudentID
                CourseCode = courseCodeForGrade, // Foreign key - CourseCode, reference existing CourseCode
                GradeValue = GradeValue.A,
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                DateAwarded = DateTimeOffset.UtcNow.AddMonths(-3),
                Remarks = "Excellent performance"
            }
        );
    }
}