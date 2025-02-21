using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class ClassScheduleConfiguration : IEntityTypeConfiguration<ClassSchedule>
{
    public void Configure(EntityTypeBuilder<ClassSchedule> builder)
    {
        builder.HasData(
            new ClassSchedule
            {
                ScheduleId = new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4"),
                ClassCode = "TEST-CLASS-001",
                ClassLocation = ClassLocation.AmericanHigh,
                Class = new Class
                {
                    ClassCode = "TEST-CLASS-001",
                    CourseCode = "COSC115", 
                    LecturerID = "L123456789012", 
                    Semester = Semester.September,
                    AcademicYear = "2024-2025",
                    ClassLocation = ClassLocation.AmericanHigh,
                    Course = new Course
                    {
                        CourseCode = "COSC115",
                        CourseName = "Elements of Programming",
                        CourseCategory = CourseCategory.CoreComputerScience,
                        Credits = 3,
                        Department = "Computer Science",
                        Description = "Introductory Course for Computer Science Students",
                    },
                    Lecturer = new Lecturer
                    {
                        LecturerID = "L123456789012", 
                        FirstName = "Michael",
                        LastName = "Asare",
                        Email = "masare@example.com",
                        Phone = "0213456789",
                        Department = "Computer Science",
                        HireDate = DateTimeOffset.UtcNow.AddYears(-5),
                        OfficeLocation = "Main Building Office",
                        Credentials = "Masters in Computer Science",
                        Gender = Gender.Male
                    }
                }
            });
    }
}