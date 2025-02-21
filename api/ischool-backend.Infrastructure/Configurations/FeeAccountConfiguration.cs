using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the FeeAccount entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{FeeAccount} to configure the FeeAccount entity in the DbContext.
/// </summary>
public class FeeAccountConfiguration : IEntityTypeConfiguration<FeeAccount>
{
    /// <summary>
    ///     Configures the FeeAccount entity for data seeding, relationships, and constraints.
    ///     Implements the Configure method from IEntityTypeConfiguration{FeeAccount}.
    ///     Seeds initial FeeAccount data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FeeAccount> builder)
    {
        // Configure required navigation property with auto-include
        // Ensures Student navigation property is always loaded when querying FeeAccounts
        builder.Navigation(fa => fa.Student)
            .IsRequired()
            .AutoInclude();

        // Configure relationship and cascading behavior
        builder.HasOne(fa => fa.Student)
            .WithOne(s => s.FeeAccount)
            .HasForeignKey<FeeAccount>(fa => fa.StudentID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior


        // Reference existing StudentID for data seeding
        const string studentIdForFeeAccount = "222CS01000694";

        // Seed initial FeeAccount data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                AccountId = new Guid("870cd736-6042-4e98-9a11-7375208ec88b"), // Example AccountId
                StudentID = studentIdForFeeAccount, // Foreign key - StudentID, reference existing StudentID
                AcademicYear = "2024-2025",
                TotalFeeDue = 1000m,
                TotalFeePaid = 500m,
                Currency = Currency.GHS,
                Semester = Semester.September
            }
        );
    }
}