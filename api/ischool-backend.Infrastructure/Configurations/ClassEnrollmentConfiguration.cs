using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the ClassEnrollment entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{ClassEnrollment} to configure the ClassEnrollment entity in the DbContext.
/// </summary>
public class ClassEnrollmentConfiguration : IEntityTypeConfiguration<ClassEnrollment>
{
    /// <summary>
    ///     Configures the ClassEnrollment entity for data seeding, relationships, and constraints.
    ///     Implements the Configure method from IEntityTypeConfiguration{ClassEnrollment}.
    ///     Seeds initial ClassEnrollment data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<ClassEnrollment> builder)
    {
        // Configure required navigation properties with auto-include
        // Ensures Student and Class navigation properties are always loaded when querying ClassEnrollments
        builder.Navigation(ce => ce.Student)
            .IsRequired()
            .AutoInclude();

        builder.Navigation(ce => ce.Class)
            .IsRequired()
            .AutoInclude();

        // Configure relationships and cascading behavior
        builder.HasOne(ce => ce.Student)
            .WithMany(s => s.ClassEnrollments)
            .HasForeignKey(ce => ce.StudentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ce => ce.Class)
            .WithMany(c => c.ClassEnrollments)
            .HasForeignKey(ce => ce.ClassCode)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        // Configure collection navigation for Grades - using field access mode for encapsulation
        builder.Metadata.FindNavigation(nameof(ClassEnrollment.Grades))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

        // Reference existing Student and Class IDs for data seeding
        const string studentIdForEnrollment = "222CS01000694";
        const string classCodeForEnrollment = "TEST-CLASS-001";


        // Seed initial ClassEnrollment data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                Id = Guid.NewGuid(), // Generate Guid for EnrollmentId
                StudentId = studentIdForEnrollment, // Foreign key - StudentId
                ClassCode = classCodeForEnrollment, // Foreign key - ClassCode
                EnrollmentDate = DateTimeOffset.UtcNow.AddMonths(-6),
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                Status = EnrollmentStatus.Active // Example EnrollmentStatus
            }
        );
    }
}