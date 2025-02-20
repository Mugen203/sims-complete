// LecturerConfiguration.cs
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for seeding data and configuring constraints for the Lecturer entity.
/// Implements the <see cref="IEntityTypeConfiguration{Lecturer}"/> interface.
/// </summary>
public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
{
    /// <summary>
    /// Configures the Lecturer entity for data seeding and constraint setup.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
        // Seed data for Lecturer entity
        builder.HasData(
            new Lecturer
            {
                LecturerID = "L123456789012",
                FirstName = "Papa",
                LastName = "Prince",
                Email = "pprince@example.com",
                Phone = "0123456789",
                Department = "Computer Science",
                HireDate = DateTimeOffset.UtcNow.AddYears(-5),
                OfficeLocation = "Main Building Office",
                Credentials = "PhD in Computer Science",
                Gender = Gender.Male // Corrected to Male based on common "Papa Prince" naming convention
            }
        );
    }
}