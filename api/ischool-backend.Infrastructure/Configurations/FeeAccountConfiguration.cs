using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

public class FeeAccountConfiguration : IEntityTypeConfiguration<FeeAccount>
{
    public void Configure(EntityTypeBuilder<FeeAccount> builder)
    {
        builder.HasData(
            new FeeAccount
            {
                AccountId = new Guid("870cd736-6042-4e98-9a11-7375208ec88b"),
                StudentID = "222CS01000694",
                AcademicYear = "2024-2025",
                TotalFeeDue = 1000m,
                TotalFeePaid = 500m,
                Currency = Currency.GHS,
                Semester = Semester.September,
                Student = new Student
                {
                    StudentID = "222CS01000694",
                    FirstName = "Kwaku",
                    LastName = "Affram",
                    DateOfBirth = new DateTimeOffset(new DateTime(2000, 1, 1)),
                    Gender = Gender.Male,
                    Address = "Kings and Queens Hostel, Oyibi, Ghana",
                    Email = "radahn@example.com",
                    Phone = "0553138727",
                    EnrollmentDate = DateTimeOffset.UtcNow.AddYears(-1),
                    DegreeProgram = "BSc Computer Science",
                    Major = "Cloud Security",
                    EnrollmentStatus = EnrollmentStatus.Active,
                    IsInternational = false,
                }
            }
        );
    }
}