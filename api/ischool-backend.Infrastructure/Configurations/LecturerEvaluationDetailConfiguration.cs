// LecturerEvaluationDetailConfiguration.cs
using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the LecturerEvaluationDetail entity, defining relationships, constraints, and seed data.
/// Implements IEntityTypeConfiguration{LecturerEvaluationDetail} to configure the LecturerEvaluationDetail entity in the DbContext.
/// </summary>
public class LecturerEvaluationDetailConfiguration : IEntityTypeConfiguration<LecturerEvaluationDetail>
{
    /// <summary>
    /// Configures the LecturerEvaluationDetail entity for data seeding, relationships, and constraints.
    /// Implements the Configure method from IEntityTypeConfiguration{LecturerEvaluationDetail}.
    /// Seeds initial LecturerEvaluationDetail data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<LecturerEvaluationDetail> builder)
    {
        // Configure required navigation property to LecturerEvaluation with auto-include
        // Ensures LecturerEvaluation navigation property is always loaded when querying LecturerEvaluationDetails
        builder.Navigation(led => led.LecturerEvaluation)
               .IsRequired()
               .AutoInclude();

        // Configure relationship and cascading behavior for LecturerEvaluation (Many-to-One)
        builder.HasOne(led => led.LecturerEvaluation)
               .WithMany(le => le.EvaluationDetails) 
               .HasForeignKey(led => led.EvaluationId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior

        
        // Reference existing EvaluationId from LecturerEvaluationConfiguration seed data
        var existingEvaluationId = new Guid("a09e818b-38f9-4650-958f-e778f80a2f7c"); 
        
        // Seed initial LecturerEvaluationDetail data using anonymous type
        builder.HasData(
            new
            {
                EvaluationDetailId = Guid.NewGuid(), // Generate new Guid for EvaluationDetailId
                EvaluationId = existingEvaluationId, // Foreign Key - EvaluationId, reference existing LecturerEvaluation
                Category = EvaluationCategory.TeachingEffectiveness,
                Rating = 4 // Example Rating
            },
            new
            {
                EvaluationDetailId = Guid.NewGuid(), // Generate new Guid for EvaluationDetailId
                EvaluationId = existingEvaluationId, // Foreign Key - EvaluationId, reference existing LecturerEvaluation
                Category = EvaluationCategory.CommunicationSkills,
                Rating = 5 // Example Rating
            }
        );
    }
}