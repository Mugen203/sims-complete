using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;

namespace ischool_backend.Infrastructure.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
       
        var studentIdForGrade = "222CS01000694"; 
        var courseCodeForGrade = "COSC240";     

        builder.HasData(
            new Grade
            {
                GradeID = Guid.NewGuid(), 
                StudentID = studentIdForGrade, 
                CourseCode = courseCodeForGrade,
                GradeValue = GradeValue.A,
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                DateAwarded = DateTimeOffset.UtcNow.AddMonths(-3),
                Remarks = "Excellent performance",
                Student = new Student
                {
                    StudentID = studentIdForGrade, 
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
                },
                Course = new Course
                {
                    CourseCode = courseCodeForGrade,
                    CourseName = "Systems Programming",
                    Department = "Computer Science",
                    Description = string.Empty,
                }
            }
        );
    }
}