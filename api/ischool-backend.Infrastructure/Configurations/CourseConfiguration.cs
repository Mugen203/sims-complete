// CourseConfiguration.cs
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
/// Configuration class for seeding data and configuring constraints for the Course entity.
/// Implements the <see cref="IEntityTypeConfiguration{Course}"/> interface.
/// Seeds data for all courses in the Computer Science program based on the provided graduation checklist,
/// utilizing a helper method to streamline course creation.
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    /// <summary>
    /// Configures the Course entity for data seeding.
    /// Seeds a comprehensive list of Computer Science program courses, categorized by core, concentration, electives, cognates, and general education requirements,
    /// using the <see cref="CreateCourse"/> helper method to simplify course object creation.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            // Core Computer Courses
            CreateCourse("COSC113", "Elements of Programming", 3, "Computer Science", Level.Level100, CourseCategory.CoreComputerScience, ClassLocation.AmericanHigh),
            CreateCourse("COSC115", "Introduction to Computer Science I", 3, "Computer Science", Level.Level100, CourseCategory.CoreComputerScience, ClassLocation.CS1),
            CreateCourse("COSC116", "Introduction to Computer Science II", 3, "Computer Science", Level.Level100, CourseCategory.CoreComputerScience, ClassLocation.CS2),
            CreateCourse("COSC130", "Digital Electronics", 3, "Computer Science", Level.Level100, CourseCategory.CoreComputerScience, ClassLocation.CS3),
            CreateCourse("COSC230", "Database Systems Design", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab1),
            CreateCourse("COSC240", "Systems Programming", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab2),
            CreateCourse("COSC245", "Entrepreneurship and Human Development", 1, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS1),
            CreateCourse("COSC250", "Computer Ethics", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS2),
            CreateCourse("COSC255", "Operating Systems", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS3),
            CreateCourse("COSC260", "System Analysis & Design", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab1),
            CreateCourse("COSC271", "Data Comms & Comp Network I", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab2),
            CreateCourse("COSC280", "Information Systems", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS1),
            CreateCourse("COSC331", "Computer Graphics I", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.CS2),
            CreateCourse("COSC346", "Software Engineering", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.CS3),
            CreateCourse("COSC357", "Project Planning and Management", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab1),
            CreateCourse("COSC361", "Data Structures & Algorithms I", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab2),
            CreateCourse("COSC364", "Research Methods", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.CS1),
            CreateCourse("COSC370", "Operations Research", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.CS2),
            CreateCourse("COSC380", "Compiler Design I", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.CS3),
            CreateCourse("PHYS103", "Physics", 3, "Physics", Level.Level100, CourseCategory.Cognate, ClassLocation.GeneralLab1),

            // Core Computer Science Concentration
            CreateCourse("COSC257", "Computer Architecture & Microprocessor System", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS2),
            CreateCourse("COSC272", "Data Comms & Comp Networks II", 3, "Computer Science", Level.Level200, CourseCategory.CoreComputerScience, ClassLocation.CS3),
            CreateCourse("COSC325", "Computer Security", 3, "Computer Science", Level.Level300, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab1),
            CreateCourse("COSC430", "Computer Simulation and System Modeling", 3, "Computer Science", Level.Level400, CourseCategory.CoreComputerScience, ClassLocation.GeneralLab2),

            // Elective Courses
            CreateCourse("COSC425", "Mobile Application Development", 3, "Computer Science", Level.Level400, CourseCategory.ElectiveComputerScience, ClassLocation.CS1),
            CreateCourse("COSC435", "Computer and Cyber Forensics", 3, "Computer Science", Level.Level400, CourseCategory.ElectiveComputerScience, ClassLocation.CS2),
            CreateCourse("COSC440", "Computer Vision", 3, "Computer Science", Level.Level400, CourseCategory.ElectiveComputerScience, ClassLocation.CS3),

            // Cognate Courses
            CreateCourse("ACCT210", "Introduction to Accounting", 3, "Accounting", Level.Level200, CourseCategory.Cognate, ClassLocation.GeneralLab1),
            CreateCourse("MATH171", "Introductory Maths for Computer Science", 3, "Mathematics", Level.Level100, CourseCategory.Cognate, ClassLocation.GeneralLab2),
            CreateCourse("MATH172", "Discrete and Continuous Mathematics", 3, "Mathematics", Level.Level100, CourseCategory.Cognate, ClassLocation.CS1),
            CreateCourse("MGNT255", "Principles of Management", 3, "Management", Level.Level200, CourseCategory.Cognate, ClassLocation.CS2),
            CreateCourse("STAT282", "Probability & Statistics", 3, "Statistics", Level.Level200, CourseCategory.Cognate, ClassLocation.CS3),

            // General Education Requirements
            CreateCourse("AFST205", "Introduction to African Music", 1, "African Studies", Level.Level200, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("CMME115", "Introduction to Communication Skills", 2, "Communication", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("ENGL111", "Language and Writing Skills I", 2, "English", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("ENGL112", "Language and Writing Skills II", 2, "English", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("ENGL122", "Language and Writing Skills II", 3, "English", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("FREN121", "French for General Communication I", 2, "French", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("HLTH200", "Health Principles", 3, "Health", Level.Level200, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("PEAC100", "Physical Activity", 0, "Physical Education", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("PSYC105", "Introduction to Psychology", 3, "Psychology", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("RELB163", "Life and Teachings of Jesus", 3, "Religion", Level.Level100, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("RELB250", "Principles of Christian Faith", 3, "Religion", Level.Level200, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),
            CreateCourse("RELT385", "Introduction to Biblical Foundation Ethics", 3, "Theology", Level.Level300, CourseCategory.GeneralEducation, ClassLocation.AmericanHigh),

            // Final Year Project
            CreateCourse("COSC492", "Final Year Project II", 6, "Computer Science", Level.Level400, CourseCategory.FinalYearProject, ClassLocation.CS3),

            // Extra Courses
            CreateCourse("AFST243", "Chieftancy and Development", 1, "African Studies", Level.Level200, CourseCategory.Extra, ClassLocation.AmericanHigh),
            CreateCourse("COSC124", "Procedural Programming", 3, "Computer Science", Level.Level100, CourseCategory.Extra, ClassLocation.CS1),
            CreateCourse("COSC214", "Computer Organization", 3, "Computer Science", Level.Level200, CourseCategory.Extra, ClassLocation.CS2),
            CreateCourse("COSC224", "Object-Oriented Programming", 3, "Computer Science", Level.Level200, CourseCategory.Extra, ClassLocation.CS3),
            CreateCourse("COSC360", "Web Applications Development", 3, "Computer Science", Level.Level300, CourseCategory.Extra, ClassLocation.GeneralLab1),
            CreateCourse("COSC390", "Internship", 3, "Computer Science", Level.Level300, CourseCategory.Extra, ClassLocation.GeneralLab2),
            CreateCourse("COSC429", "Cloud Computing Systems", 3, "Computer Science", Level.Level400, CourseCategory.Extra, ClassLocation.CS1),
            CreateCourse("COSC446", "Advanced Network & Systems Administration", 3, "Computer Science", Level.Level400, CourseCategory.Extra, ClassLocation.CS2),
            CreateCourse("COSC455", "Artificial Intelligence & Machine Learning I", 3, "Computer Science", Level.Level400, CourseCategory.Extra, ClassLocation.CS3),
            CreateCourse("CSCD210", "Numerical Methods", 3, "Computer Science", Level.Level200, CourseCategory.Extra, ClassLocation.GeneralLab1),
            CreateCourse("CTZN001", "Citizenship", 0, "Citizenship", Level.Level100, CourseCategory.Extra, ClassLocation.AmericanHigh),
            CreateCourse("GNED125", "Study Skills", 0, "General Education", Level.Level100, CourseCategory.Extra, ClassLocation.AmericanHigh)
        );
    }

    /// <summary>
    /// Helper method to create a new <see cref="Course"/> instance with specified properties.
    /// This method streamlines the creation of Course entities for data seeding, reducing code duplication and improving readability.
    /// </summary>
    /// <param name="code">The course code (e.g., "COSC113").</param>
    /// <param name="name">The course name (e.g., "Elements of Programming").</param>
    /// <param name="credits">The number of credits for the course.</param>
    /// <param name="department">The department offering the course (e.g., "Computer Science").</param>
    /// <param name="level">The academic level of the course (e.g., <see cref="Level.Level100"/>).</param>
    /// <param name="category">The category of the course (e.g., <see cref="CourseCategory.CoreComputerScience"/>).</param>
    /// <param name="location">The class location (e.g., <see cref="ClassLocation.AmericanHigh"/>).</param>
    /// <param name="description">Optional description of the course.</param>
    /// <returns>A new <see cref="Course"/> entity instance with the provided properties.</returns>
    private static Course CreateCourse(string code, string name, int credits, string department,
        Level level, CourseCategory category, ClassLocation location, string description = "")
    {
        return new Course
        {
            CourseCode = code,
            CourseName = name,
            Credits = credits,
            Department = department,
            Description = description,
            IsActive = true,
            Level = level,
            CourseCategory = category,
            ClassLocation = location
        };
    }
}