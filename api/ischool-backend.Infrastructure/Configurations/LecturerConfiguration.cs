using System;
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
{
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
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
                    Gender = Gender.Female
                }
            );
    }
}

