using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder.HasData(
            new Library
            {
                LibraryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                LibraryName = "Main Library",
                Location = "Central Campus"
            }
        );
    }
}