using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the ClassSession entity that defines relationships, constraints and seeds initial data.
/// Implements IEntityTypeConfiguration{ClassSession} to configure the ClassSession entity in the DbContext.
/// </summary>
public class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
{
    /// <summary>
    /// Configures the ClassSession entity for data seeding, relationships, and constraints.
    /// Implements the Configure method from IEntityTypeConfiguration{ClassSession}.
    /// Seeds initial ClassSession data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<ClassSession> builder)
    {
        // Configure required navigation property with auto-include
        // Ensures Schedule navigation property is always loaded when querying ClassSessions
        builder.Navigation(cs => cs.Schedule)
               .IsRequired()
               .AutoInclude();

        // Configure relationship and cascading behavior
        builder.HasOne(cs => cs.Schedule)
               .WithMany(cschedule => cschedule.ClassSessions)
               .HasForeignKey(cs => cs.ScheduleId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior

        
        
        var scheduleIdForSession = new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4");

        // Seed initial ClassSession data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                ClassSessionId = new Guid("837c7278-3754-4bb6-98ee-7fca53d40677"), // Example ClassSessionId
                ScheduleId = scheduleIdForSession, // Foreign key - ScheduleId, reference existing ScheduleId
                SessionDate = DateTimeOffset.UtcNow.AddDays(2), // Example SessionDate
                Topics = "Introduction to System Programming",
                LecturerNotes = "Please review Chapter 1 before next session",
                Status = ClassSessionStatus.Scheduled
            }
        );
    }
}