using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

/// <summary>
///     Configuration class for seeding data and configuring constraints for the Course entity.
///     Implements the <see cref="IEntityTypeConfiguration{Course}" /> interface.
///     Seeds data for all courses in the Computer Science program based on the provided graduation checklist,
///     utilizing a helper method to streamline course creation.
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    /// <summary>
    ///     Configures the Course entity for data seeding.
    ///     Seeds a comprehensive list of Computer Science program courses, categorized by core, concentration, electives,
    ///     cognates, and general education requirements,
    ///     using the <see cref="CreateCourse" /> helper method to simplify course object creation.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // **DEFINE NAVIGATION PROPERTIES AND RELATIONSHIPS ABOVE HASDATA **
        // Course entity in this configuration doesn't have navigation properties configured here.


        // **DEFINE SEED DATA BELOW NAVIGATION PROPERTIES AND RELATIONSHIPS **

        // Seed initial course data using anonymous types - no navigation properties to worry about for Course itself
        builder.HasData(
            // Core Computer Courses - Level 100
            new
            {
                CourseCode = "COSC113", CourseName = "Elements of Programming", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level100, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Introduction to fundamental programming concepts.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC115", CourseName = "Introduction to Computer Science I", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level100, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS1,
                Description = "First course in the computer science introductory sequence.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC116", CourseName = "Introduction to Computer Science II", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level100, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description = "Second course in the computer science introductory sequence.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC130", CourseName = "Digital Electronics", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level100, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Fundamentals of digital electronics.", // Added Description
                IsActive = true // Added IsActive = true
            },
            // Core Computer Courses - Level 200
            new
            {
                CourseCode = "COSC230", CourseName = "Database Systems Design", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Principles of database systems design and implementation.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC240", CourseName = "Systems Programming", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Advanced programming concepts in system-level development.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC245", CourseName = "Entrepreneurship and Human Development", Credits = 1,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS1,
                Description = "Exploration of entrepreneurship and human development topics.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC250", CourseName = "Computer Ethics", Credits = 3, Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description = "Ethical considerations in computing and information technology.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC255", CourseName = "Operating Systems", Credits = 3, Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Core concepts and principles of operating systems.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC260", CourseName = "System Analysis & Design", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Methods and techniques for system analysis and design.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC271", CourseName = "Data Comms & Comp Network I", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Introduction to data communications and computer networks.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC280", CourseName = "Information Systems", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS1,
                Description = "Overview of information systems and their applications.", // Added Description
                IsActive = true // Added IsActive = true
            },
            // Core Computer Courses - Level 300
            new
            {
                CourseCode = "COSC331", CourseName = "Computer Graphics I", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description = "Introduction to computer graphics principles and techniques.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC346", CourseName = "Software Engineering", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Principles and practices of software engineering.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC357", CourseName = "Project Planning and Management", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Techniques for planning and managing software projects.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC361", CourseName = "Data Structures & Algorithms I", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Fundamental data structures and algorithms.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC364", CourseName = "Research Methods", Credits = 3, Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS1,
                Description = "Introduction to research methodologies in computer science.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC370", CourseName = "Operations Research", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description =
                    "Application of operations research techniques to computer science problems.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC380", CourseName = "Compiler Design I", Credits = 3, Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Principles and techniques of compiler design.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "PHYS103", CourseName = "Physics", Credits = 3, Department = "Physics",
                Level = Level.Level100, CourseCategory = CourseCategory.Cognate,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Introductory course in physics.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // Core Computer Science Concentration - Level 200
            new
            {
                CourseCode = "COSC257", CourseName = "Computer Architecture & Microprocessor System", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description = "Computer architecture and microprocessor systems.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC272", CourseName = "Data Comms & Comp Networks II", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Advanced topics in data communications and computer networks.", // Added Description
                IsActive = true // Added IsActive = true
            },
            // Core Computer Science Concentration - Level 300
            new
            {
                CourseCode = "COSC325", CourseName = "Computer Security", Credits = 3, Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Fundamentals of computer security.", // Added Description
                IsActive = true // Added IsActive = true
            },
            // Core Computer Science Concentration - Level 400
            new
            {
                CourseCode = "COSC430", CourseName = "Computer Simulation and System Modeling", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.CoreComputerScience,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Techniques for computer simulation and system modeling.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // Elective Courses - Level 400
            new
            {
                CourseCode = "COSC425", CourseName = "Mobile Application Development", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.ElectiveComputerScience,
                ClassLocation = ClassLocation.CS1,
                Description = "Development of mobile applications for various platforms.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC435", CourseName = "Computer and Cyber Forensics", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.ElectiveComputerScience,
                ClassLocation = ClassLocation.CS2,
                Description = "Principles and techniques of computer and cyber forensics.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC440", CourseName = "Computer Vision", Credits = 3, Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.ElectiveComputerScience,
                ClassLocation = ClassLocation.CS3,
                Description = "Introduction to computer vision and image processing.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // Cognate Courses - Level 200
            new
            {
                CourseCode = "ACCT210", CourseName = "Introduction to Accounting", Credits = 3,
                Department = "Accounting",
                Level = Level.Level200, CourseCategory = CourseCategory.Cognate,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Basic accounting principles and practices.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "MATH171", CourseName = "Introductory Maths for Computer Science", Credits = 3,
                Department = "Mathematics",
                Level = Level.Level100, CourseCategory = CourseCategory.Cognate,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Mathematical concepts relevant to computer science.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "MATH172", CourseName = "Discrete and Continuous Mathematics", Credits = 3,
                Department = "Mathematics",
                Level = Level.Level100, CourseCategory = CourseCategory.Cognate, ClassLocation = ClassLocation.CS1,
                Description = "Discrete and continuous mathematics for computer science.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "MGNT255", CourseName = "Principles of Management", Credits = 3, Department = "Management",
                Level = Level.Level200, CourseCategory = CourseCategory.Cognate, ClassLocation = ClassLocation.CS2,
                Description = "Fundamental principles of management.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "STAT282", CourseName = "Probability & Statistics", Credits = 3, Department = "Statistics",
                Level = Level.Level200, CourseCategory = CourseCategory.Cognate, ClassLocation = ClassLocation.CS3,
                Description = "Introduction to probability and statistics.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // General Education Requirements - Level 200, 100, 300
            new
            {
                CourseCode = "AFST205", CourseName = "Introduction to African Music", Credits = 1,
                Department = "African Studies",
                Level = Level.Level200, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Introduction to the diverse world of African music.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "CMME115", CourseName = "Introduction to Communication Skills", Credits = 2,
                Department = "Communication",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Basic communication skills for effective interaction.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "ENGL111", CourseName = "Language and Writing Skills I", Credits = 2,
                Department = "English",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "First course in language and writing skills development.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "ENGL112", CourseName = "Language and Writing Skills II", Credits = 2,
                Department = "English",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Second course in language and writing skills development.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "ENGL122", CourseName = "Language and Writing Skills II", Credits = 3,
                Department = "English",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description =
                    "Further development of language and writing skills.", // Duplication? - You might want to check the course code and name here. // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "FREN121", CourseName = "French for General Communication I", Credits = 2,
                Department = "French",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Introductory French for general communication.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "HLTH200", CourseName = "Health Principles", Credits = 3, Department = "Health",
                Level = Level.Level200, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Fundamental principles of health and wellness.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "PEAC100", CourseName = "Physical Activity", Credits = 0,
                Department = "Physical Education",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Introduction to physical activity and fitness.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "PSYC105", CourseName = "Introduction to Psychology", Credits = 3,
                Department = "Psychology",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Basic concepts and theories of psychology.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "RELB163", CourseName = "Life and Teachings of Jesus", Credits = 3,
                Department = "Religion",
                Level = Level.Level100, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Study of the life and teachings of Jesus Christ.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "RELB250", CourseName = "Principles of Christian Faith", Credits = 3,
                Department = "Religion",
                Level = Level.Level200, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Core principles of Christian faith and theology.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "RELT385", CourseName = "Introduction to Biblical Foundation Ethics", Credits = 3,
                Department = "Theology",
                Level = Level.Level300, CourseCategory = CourseCategory.GeneralEducation,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Ethical foundations based on biblical teachings.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // Final Year Project - Level 400
            new
            {
                CourseCode = "COSC492", CourseName = "Final Year Project II", Credits = 6,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.FinalYearProject,
                ClassLocation = ClassLocation.CS3,
                Description = "Continuation of the final year project in computer science.", // Added Description
                IsActive = true // Added IsActive = true
            },

            // Extra Courses - Level 200, 100, 300, 400
            new
            {
                CourseCode = "AFST243", CourseName = "Chieftancy and Development", Credits = 1,
                Department = "African Studies",
                Level = Level.Level200, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Exploration of chieftaincy and its role in development.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC124", CourseName = "Procedural Programming", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level100, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS1,
                Description = "Introduction to procedural programming paradigms.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC214", CourseName = "Computer Organization", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS2,
                Description = "Fundamentals of computer organization and architecture.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC224", CourseName = "Object-Oriented Programming", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS3,
                Description = "Principles and practices of object-oriented programming.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC360", CourseName = "Web Applications Development", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Development of web applications using modern technologies.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC390", CourseName = "Internship", Credits = 3, Department = "Computer Science",
                Level = Level.Level300, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.GeneralLab2,
                Description = "Practical work experience through internship.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC429", CourseName = "Cloud Computing Systems", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS1,
                Description = "Concepts and technologies of cloud computing systems.", // Added Description
                IsActive = true // Added IsActive = true
            },
            new
            {
                CourseCode = "COSC446", CourseName = "Advanced Network & Systems Administration", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS2,
                Description = "Advanced topics in network and systems administration.", // Added Description
                IsActive = true
            },
            new
            {
                CourseCode = "COSC455", CourseName = "Artificial Intelligence & Machine Learning I", Credits = 3,
                Department = "Computer Science",
                Level = Level.Level400, CourseCategory = CourseCategory.Extra, ClassLocation = ClassLocation.CS3,
                Description = "Introduction to artificial intelligence and machine learning.", // Added Description
                IsActive = true
            },
            new
            {
                CourseCode = "CSCD210", CourseName = "Numerical Methods", Credits = 3, Department = "Computer Science",
                Level = Level.Level200, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.GeneralLab1,
                Description = "Numerical methods for problem-solving in computer science.", // Added Description
                IsActive = true
            },
            new
            {
                CourseCode = "CTZN001", CourseName = "Citizenship", Credits = 0, Department = "Citizenship",
                Level = Level.Level100, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Fundamentals of citizenship and civic responsibility.", // Added Description
                IsActive = true
            },
            new
            {
                CourseCode = "GNED125", CourseName = "Study Skills", Credits = 0, Department = "General Education",
                Level = Level.Level100, CourseCategory = CourseCategory.Extra,
                ClassLocation = ClassLocation.AmericanHigh,
                Description = "Essential study skills for academic success.", // Added Description
                IsActive = true
            }
        );
    }
}