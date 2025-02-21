// ClassConfiguration.cs
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for seeding data and configuring constraints for the Class entity.
/// Implements the <see cref="IEntityTypeConfiguration{Class}"/> interface.
/// Seeds data for Class entities, linking them to existing Course and Lecturer entities.
/// Adjusted to use generic Semester names (Semester1, Semester2) and section names (A, B) as per user feedback.
/// </summary>
public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    /// <summary>
    /// Configures the Class entity for data seeding.
    /// Seeds initial Class data, including linking to Courses and Lecturers using their respective IDs.
    /// Uses generic Semester names and section names (A, B).  Customize semester names if needed.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasData(
                new Class
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
            
            
            /*// Level 100 Core Computer Science Classes - Semester 1 2024-2025
            CreateClass("COSC113-Sem1-2024-A", "COSC113", "L123456789012", Semester.September, "2024-2025", ClassLocation.AmericanHigh),
            CreateClass("COSC115-Sem1-2024-B", "COSC115", "L123456789012", Semester.September, "2024-2025", ClassLocation.CS1),
            CreateClass("COSC116-Sem1-2024-C", "COSC116", "L123456789012", Semester.September, "2024-2025", ClassLocation.CS2),
            CreateClass("COSC130-Sem1-2024-D", "COSC130", "L123456789012", Semester.September, "2024-2025", ClassLocation.CS3), // Example - you might only use A, B sections. Adjust as needed.

            // Level 200 Core Computer Science Classes - Semester 2 2024-2025
            CreateClass("COSC230-Sem2-2024-A", "COSC230", "L123456789012", Semester.January, "2024-2025", ClassLocation.GeneralLab1),
            CreateClass("COSC240-Sem2-2024-B", "COSC240", "L123456789012", Semester.January, "2024-2025", ClassLocation.GeneralLab2),
            CreateClass("COSC245-Sem2-2024-C", "COSC245", "L123456789012", Semester.January, "2024-2025", ClassLocation.CS1),
            CreateClass("COSC250-Sem2-2024-D", "COSC250", "L123456789012", Semester.January, "2024-2025", ClassLocation.CS2),
            CreateClass("COSC255-Sem2-2024-E", "COSC255", "L123456789012", Semester.January, "2024-2025", ClassLocation.CS3),
            CreateClass("COSC260-Sem2-2024-F", "COSC260", "L123456789012", Semester.January, "2024-2025", ClassLocation.GeneralLab1),
            CreateClass("COSC271-Sem2-2024-G", "COSC271", "L123456789012", Semester.January, "2024-2025", ClassLocation.GeneralLab2),
            CreateClass("COSC280-Sem2-2024-H", "COSC280", "L123456789012", Semester.January, "2024-2025", ClassLocation.CS1),

            // Level 300 Core Computer Science Classes - Semester 1 2025-2026 (Example Academic Year Rollover)
            CreateClass("COSC331-Sem1-2025-A", "COSC331", "L123456789012", Semester.September, "2025-2026", ClassLocation.CS2),
            CreateClass("COSC346-Sem1-2025-B", "COSC346", "L123456789012", Semester.September, "2025-2026", ClassLocation.CS3),
            CreateClass("COSC357-Sem1-2025-C", "COSC357", "L123456789012", Semester.September, "2025-2026", ClassLocation.GeneralLab1),
            CreateClass("COSC361-Sem1-2025-D", "COSC361", "L123456789012", Semester.September, "2025-2026", ClassLocation.GeneralLab2),
            CreateClass("COSC364-Sem1-2025-E", "COSC364", "L123456789012", Semester.September, "2025-2026", ClassLocation.CS1),
            CreateClass("COSC370-Sem1-2025-F", "COSC370", "L123456789012", Semester.September, "2025-2026", ClassLocation.CS2),
            CreateClass("COSC380-Sem1-2025-G", "COSC380", "L123456789012", Semester.September, "2025-2026", ClassLocation.CS3)
            */
            
        );
    }

    /*
    /// <summary>
    /// Helper method to create a new <see cref="Class"/> instance with specified properties for seeding.
    /// Streamlines the creation of Class entities, reducing redundancy in the configuration.
    /// Adjusted ClassCode format to use "Sem1", "Sem2" for semesters and simpler section names (A, B, etc.).
    /// </summary>
    // ... (rest of CreateClass method remains the same)
    private static Class CreateClass(string classCode, string courseCode, string lecturerId, Semester semester, string academicYear, ClassLocation? classLocation = null)
    {
        return new Class
        {
            ClassCode = classCode,
            CourseCode = courseCode,
            LecturerID = lecturerId,
            Semester = semester,
            AcademicYear = academicYear,
            ClassLocation = classLocation,
            Course = null,
            Lecturer = null // Can be null to use default Course location
        };
    }*/
}