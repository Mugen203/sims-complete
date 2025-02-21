using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the Library entity, defining constraints and seed data.
///     Implements IEntityTypeConfiguration{Library} to configure the Library entity in the DbContext.
/// </summary>
public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    /// <summary>
    ///     Configures the Library entity for data seeding and constraint setup.
    ///     Implements the Configure method from IEntityTypeConfiguration{Library}.
    ///     Seeds initial Library data and configures any specific constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        // Seed data for Library entity using anonymous type
        builder.HasData(
            new
            {
                LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                LibraryName = "Main Library",
                Location = "Central Campus"
            }
        );
    }
}