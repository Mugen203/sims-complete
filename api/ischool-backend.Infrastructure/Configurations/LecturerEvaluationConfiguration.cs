using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the LecturerEvaluation entity, defining relationships, constraints, and seed data.
/// Implements IEntityTypeConfiguration{LecturerEvaluation} to configure the LecturerEvaluation entity in the DbContext.
/// </summary>
public class LecturerEvaluationConfiguration : IEntityTypeConfiguration<LecturerEvaluation>
{
    /// <summary>
    /// Configures the LecturerEvaluation entity for data seeding, relationships, and constraints.
    /// Implements the Configure method from IEntityTypeConfiguration{LecturerEvaluation}.
    /// Seeds initial LecturerEvaluation data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<LecturerEvaluation> builder)
    {
        // Configure required navigation property to Lecturer with auto-include
        // Ensures Lecturer navigation property is always loaded when querying LecturerEvaluations
        builder.Navigation(le => le.Lecturer)
               .IsRequired()
               .AutoInclude();

        // Configure relationship and cascading behavior for Lecturer
        builder.HasOne(le => le.Lecturer)
               .WithMany(l => l.Evaluations)
               .HasForeignKey(le => le.LecturerId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior

        // Configure navigation property to EvaluationDetails with auto-include (if needed - consider performance implications)
        // builder.Navigation(le => le.EvaluationDetails).AutoInclude(); // Decide if AutoInclude is necessary for EvaluationDetails

        // Configure relationship for EvaluationDetails (One-to-Many from LecturerEvaluation to LecturerEvaluationDetail)
        builder.HasMany(le => le.EvaluationDetails)
               .WithOne(led => led.LecturerEvaluation)
               .HasForeignKey(led => led.EvaluationId)
               .OnDelete(DeleteBehavior.Cascade); // Cascade delete for EvaluationDetails when Evaluation is deleted

        
        // Reference existing LecturerID for data seeding
        const string lecturerIdForEvaluation = "L123456789012";

        // Seed initial LecturerEvaluation data using anonymous type
        builder.HasData(
            new
            {
                EvaluationId = new Guid("a09e818b-38f9-4650-958f-e778f80a2f7c"), 
                LecturerId = lecturerIdForEvaluation, // Foreign Key - LecturerId, reference existing Lecturer
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                EvaluationDate = DateTimeOffset.UtcNow.AddDays(-10), // Example EvaluationDate
                Comments = "Initial lecturer evaluation for Fall semester." // Example comment
            }
        );
    }
}