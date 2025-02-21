using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Configure one-to-one relationship between Student and FeeAccount
        builder.HasOne(s => s.FeeAccount)
            .WithOne(f => f.Student)
            .HasForeignKey<FeeAccount>(f => f.StudentID)
            .IsRequired(); 

        // Seed data for Student entities ONLY 
        var student = new Student 
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
        };
        builder.HasData(student); 
    }
}