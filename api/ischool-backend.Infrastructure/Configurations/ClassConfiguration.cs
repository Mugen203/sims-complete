using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the Class entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{Class} to configure the Class entity in the DbContext.
/// </summary>
public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        // Configure the required navigation properties with auto-include
        // This ensures related Course and Lecturer data is automatically loaded when querying Classes
        builder.Navigation(c => c.Course)
            .IsRequired()
            .AutoInclude();

        builder.Navigation(c => c.Lecturer)
            .IsRequired()
            .AutoInclude();

        // Configure the relationships and cascading behavior
        builder.HasOne(c => c.Course)
            .WithMany()
            .HasForeignKey(c => c.CourseCode)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Lecturer)
            .WithMany()
            .HasForeignKey(c => c.LecturerID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Configure the collections to ensure proper initialization
        builder.Metadata.FindNavigation(nameof(Class.ClassSchedules))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Class.ClassEnrollments))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Class.AttendanceRecords))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Class.Grades))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

        // Reference existing Course and Lecturer IDs for data seeding
        const string courseCodeForClass = "COSC115";
        const string lecturerIdForClass = "L123456789012";

        // Seed initial class data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                ClassCode = "TEST-CLASS-001",
                CourseCode = courseCodeForClass,
                LecturerID = lecturerIdForClass,
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                ClassLocation = ClassLocation.AmericanHigh
            }
        );
    }
}