using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

public class BorrowRequestConfiguration : IEntityTypeConfiguration<BorrowRequest>
{
    public void Configure(EntityTypeBuilder<BorrowRequest> builder)
    {
        // Reference IDs from existing seed data
        const string studentIdForBorrowRequest = "222CS01000694";
        var bookIdForBorrowRequest1 = new Guid("f549e035-5bd2-487a-867d-7ea5d1fd0ebd");
        var bookIdForBorrowRequest2 = new Guid("8e739c1c-3563-47ed-863b-e9a90af61c88");

        // Seed data using anonymous types to handle required navigation properties
        builder.HasData(
            new
            {
                BorrowRequestId = Guid.NewGuid(),
                StudentId = studentIdForBorrowRequest,
                BookId = bookIdForBorrowRequest1,
                BorrowDate = DateTimeOffset.UtcNow.AddDays(-10),
                ReturnDate = DateTimeOffset.UtcNow.AddMonths(1),
                IsReturned = false,
                Status = BorrowRequestStatus.Approved
            },
            new
            {
                BorrowRequestId = Guid.NewGuid(),
                StudentId = studentIdForBorrowRequest,
                BookId = bookIdForBorrowRequest2,
                BorrowDate = DateTimeOffset.UtcNow.AddDays(-5),
                ReturnDate = DateTimeOffset.UtcNow.AddMonths(2),
                IsReturned = false,
                Status = BorrowRequestStatus.Borrowed
            }
        );
    }
}