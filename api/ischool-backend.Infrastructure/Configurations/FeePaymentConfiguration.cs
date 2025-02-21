using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for the FeePayment entity that defines relationships, constraints and seeds initial data.
///     Implements IEntityTypeConfiguration{FeePayment} to configure the FeePayment entity in the DbContext.
/// </summary>
public class FeePaymentConfiguration : IEntityTypeConfiguration<FeePayment>
{
    /// <summary>
    ///     Configures the FeePayment entity for data seeding, relationships, and constraints.
    ///     Implements the Configure method from IEntityTypeConfiguration{FeePayment}.
    ///     Seeds initial FeePayment data and configures navigation properties and foreign key relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FeePayment> builder)
    {
        // Configure required navigation property with auto-include
        // Ensures FeeAccount navigation property is always loaded when querying FeePayments
        builder.Navigation(fp => fp.FeeAccount)
            .IsRequired()
            .AutoInclude();

        // Configure relationship and cascading behavior
        builder.HasOne(fp => fp.FeeAccount)
            .WithMany(fa => fa.FeePayments)
            .HasForeignKey(fp => fp.AccountId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Choose appropriate DeleteBehavior


        // Reference existing AccountId from FeeAccountConfiguration seed data
        var existingAccountId = new Guid("870cd736-6042-4e98-9a11-7375208ec88b");

        // Seed initial FeePayment data using anonymous type to avoid navigation property issues
        builder.HasData(
            new
            {
                PaymentID = Guid.NewGuid(), // Generate a new Guid for PaymentID
                AccountId = existingAccountId, // Foreign key - AccountId, reference existing FeeAccount
                PaymentDate = DateTimeOffset.UtcNow.AddDays(-5),
                AmountPaid = 200.00m,
                PaymentMethod = PaymentMethod.MobileMoney,
                PaymentReference = "MOMO-TRANS-12345",
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                Status = PaymentStatus.Completed,
                Description = "Semester 1 Fees - Mobile Money Payment",
                ReceiptIssued = true,
                ReceiptNumber = "RCPT-2024-001",
                CreatedBy = "SeedDataScript", // **Valid CreatedBy**
                CreatedAt = DateTimeOffset.UtcNow // **Valid CreatedAt**
                // LastModifiedBy and LastModifiedAt can remain null if not modified
            }
        );
    }
}