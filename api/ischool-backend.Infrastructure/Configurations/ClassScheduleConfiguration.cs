using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the ClassSchedule entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{ClassSchedule} to configure the ClassSchedule entity in the DbContext.
/// </summary>
public class ClassScheduleConfiguration : IEntityTypeConfiguration<ClassSchedule>
{
    /// <summary>
    ///     Configures the ClassSchedule entity for data seeding, relationships, and constraints.
    ///     Implements the Configure method from IEntityTypeConfiguration{ClassSchedule}.
    ///     Seeds initial ClassSchedule data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<ClassSchedule> builder)
    {
        // Configure required navigation property with auto-include
        // Ensures Class navigation property is always loaded when querying ClassSchedules
        builder.Navigation(cs => cs.Class)
            .IsRequired()
            .AutoInclude();

        // Configure relationship and cascading behavior
        builder.HasOne(cs => cs.Class)
            .WithMany(c => c.ClassSchedules)
            .HasForeignKey(cs => cs.ClassCode)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior


        // Reference existing ClassCode for data seeding
        const string classCodeForSchedule = "TEST-CLASS-001";

        // Seed initial ClassSchedule data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                ScheduleId = new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4"),
                ClassCode = classCodeForSchedule, // Foreign key - ClassCode
                ClassLocation = ClassLocation.AmericanHigh,
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(10, 50, 0),
                DayOfWeek = DayOfWeek.Monday,
                IsBooked = false // Default value
            }
        );
    }
}