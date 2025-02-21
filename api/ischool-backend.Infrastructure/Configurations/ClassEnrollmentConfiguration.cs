using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class ClassEnrollmentConfiguration : IEntityTypeConfiguration<ClassEnrollment>
{
    public void Configure(EntityTypeBuilder<ClassEnrollment> builder)
    {
        const string studentIdForEnrollment = "222CS01000694";
        const string classCodeForEnrollment = "TEST-CLASS-001"; 

        builder.HasData(
            new ClassEnrollment
            {
                Id = Guid.NewGuid(), // Generate Guid for EnrollmentId
                StudentId = studentIdForEnrollment,
                ClassCode = classCodeForEnrollment,
                EnrollmentDate = DateTimeOffset.UtcNow.AddMonths(-6), 
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                Status = EnrollmentStatus.Active, // Example EnrollmentStatus
                Student = new Student // Inline Student entity with full properties
                {
                    StudentID = studentIdForEnrollment,
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
                Class = new Class // Inline Class entity with full properties (and nested Course & Lecturer)
                {
                    ClassCode = classCodeForEnrollment,
                    CourseCode = "COSC115", // Example CourseCode - adjust if needed
                    LecturerID = "L123456789012", // Example LecturerID - adjust if needed
                    Semester = Semester.September,
                    AcademicYear = "2024-2025",
                    ClassLocation = ClassLocation.AmericanHigh,
                    Course = new Course // Nested Course entity
                    {
                        CourseCode = "COSC115",
                        CourseName = "Elements of Programming",
                        CourseCategory = CourseCategory.CoreComputerScience,
                        Credits = 3,
                        Department = "Computer Science",
                        Description = "Introductory Course for Computer Science Students",
                    },
                    Lecturer = new Lecturer // Nested Lecturer entity
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
            },
            
            new ClassEnrollment // Example for another enrollment - you can add more
            {
                Id = Guid.NewGuid(),
                StudentId = "222CS01000694",
                ClassCode = "TEST-CLASS-002",
                EnrollmentDate = DateTimeOffset.UtcNow.AddMonths(-4),
                Semester = Semester.January,
                AcademicYear = "2024-2025",
                Status = EnrollmentStatus.Active,
                Student = new Student 
                {
                    StudentID = studentIdForEnrollment,
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
                Class = new Class 
                {
                    ClassCode = "COSC221", // Match the ClassCode for this enrollment
                    CourseCode = "COSC361",
                    LecturerID = "L987654321012",
                    Semester = Semester.January,
                    AcademicYear = "2024-2025",
                    ClassLocation = ClassLocation.GeneralLab1,
                    Course = new Course // Nested Course for COSC221
                    {
                        CourseCode = "COSC361",
                        CourseName = "Data Structures & Algorithms I",
                        CourseCategory = CourseCategory.CoreComputerScience,
                        Credits = 3,
                        Department = "Computer Science",
                        Description = "In-depth study of data structures..."
                    },
                    Lecturer = new Lecturer // Nested Lecturer for COSC221 Class
                    {
                        LecturerID = "L987654321012",
                        FirstName = "Ama",
                        LastName = "Adjei",
                        Email = "aadjei@example.com",
                        Phone = "0209876543",
                        Department = "Computer Science",
                        HireDate = DateTimeOffset.UtcNow.AddYears(-3),
                        OfficeLocation = "New Wing, 2nd Floor",
                        Credentials = "PhD in Data Science",
                        Gender = Gender.Female
                    }
                }
            }
            );
    }
}