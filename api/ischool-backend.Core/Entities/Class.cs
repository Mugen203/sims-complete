using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a specific instance of a Course offered in a particular semester and academic year.
/// A Class is taught by a Lecturer and students enroll in Classes.
/// </summary>
public class Class
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public Class()
    {
        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        AttendanceRecords = new HashSet<AttendanceRecord>(); // Added AttendanceRecords here as well, if attendance is tracked per class instance
        Grades = new HashSet<Grade>(); // Added Grades here as well, grades are typically awarded per class instance
    }

    /// <summary>
    /// Parameterized constructor to create a new Class instance.
    /// </summary>
    /// <param name="classCode">Unique code for this specific class instance (e.g., "CS101-Fall2023-A").</param>
    /// <param name="courseCode">Course code of the Course this class is an instance of.</param>
    /// <param name="lecturerId">ID of the lecturer assigned to teach this class.</param>
    /// <param name="semester">Semester in which this class is offered.</param>
    /// <param name="academicYear">Academic year in which this class is offered (e.g., "2023-2024").</param>
    /// <param name="classLocation">Specific location where this class instance is held (overrides default Course location if needed).</param>
    public Class(string classCode, string courseCode, string lecturerId, Semester semester, string academicYear, ClassLocation? classLocation = null)
    {
        ClassCode = classCode;
        CourseCode = courseCode;
        LecturerID = lecturerId;
        Semester = semester;
        AcademicYear = academicYear;
        ClassLocation = classLocation; // Allow overriding Course's default ClassLocation for specific class instance

        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        AttendanceRecords = new HashSet<AttendanceRecord>();
        Grades = new HashSet<Grade>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique code for this specific class instance.
    /// Serves as the primary key for the Class entity.
    /// Example: "CS101-Fall2023-SectionA", "MATH201-Spring2024-Evening".
    /// Needs to be unique across all class instances.
    /// </summary>
    [Key]
    [Required(ErrorMessage = "Class code is required")]
    [MaxLength(20, ErrorMessage = "Class code cannot exceed 20 characters")] // Adjust MaxLength as needed
    public required string ClassCode { get; set; }

    /// <summary>
    /// Course code of the Course to which this class instance belongs.
    /// Foreign key to the Course entity.
    /// </summary>
    [Required(ErrorMessage = "Course code is required")]
    [MaxLength(10, ErrorMessage = "Course code cannot exceed 10 characters")] // Matches CourseCode in Course entity
    public required string CourseCode { get; set; }

    /// <summary>
    /// ID of the Lecturer assigned to teach this class instance.
    /// Foreign key to the Lecturer entity.
    /// </summary>
    [Required(ErrorMessage = "Lecturer ID is required")]
    [MaxLength(13, ErrorMessage = "Lecturer ID cannot exceed 13 characters")] // Matches LecturerID in Lecturer entity
    public required string LecturerID { get; set; }

    /// <summary>
    /// Semester in which this class is offered (e.g., Fall, Spring, Summer).
    /// Uses the Semester enum for predefined semester values.
    /// </summary>
    [Required(ErrorMessage = "Semester is required")]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    /// <summary>
    /// Academic year in which this class is offered.
    /// Format "YYYY-YYYY" (e.g., "2023-2024").
    /// </summary>
    [Required(ErrorMessage = "Academic Year is required")]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in YYYY-YYYY format")]
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public required string AcademicYear { get; set; }

    /// <summary>
    /// Specific location for this class instance.
    /// Can override the default ClassLocation specified in the Course entity if needed.
    /// Uses the ClassLocation enum. Nullable if the class location is the same as the default Course location.
    /// </summary>
    [EnumDataType(typeof(ClassLocation))]
    public ClassLocation? ClassLocation { get; set; } // Nullable - can inherit from Course's default location

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Course entity.
    /// Represents the Course definition this class instance is based on.
    /// Defines a many-to-one relationship between Class and Course.
    /// </summary>
    [ForeignKey(nameof(CourseCode))]
    public required Course Course { get; set; }

    /// <summary>
    /// Navigation property to the Lecturer entity.
    /// Represents the Lecturer assigned to teach this class instance.
    /// Defines a many-to-one relationship between Class and Lecturer.
    /// </summary>
    [ForeignKey(nameof(LecturerID))]
    public required Lecturer Lecturer { get; set; }

    /// <summary>
    /// Navigation property for ClassSchedules.
    /// Represents the schedule entries for this specific class instance (e.g., Monday 9 AM, Room 101).
    /// Defines a one-to-many relationship between Class and ClassSchedule.
    /// </summary>
    public ICollection<ClassSchedule> ClassSchedules { get; set; }

    /// <summary>
    /// Navigation property for ClassEnrollments.
    /// Represents the enrollments of students in this specific class instance.
    /// Defines a one-to-many relationship between Class and ClassEnrollment.
    /// </summary>
    public ICollection<ClassEnrollment> ClassEnrollments { get; set; }

    /// <summary>
    /// Navigation property for AttendanceRecords.
    /// Represents the attendance records for this specific class instance.
    /// Defines a one-to-many relationship between Class and AttendanceRecord.
    /// </summary>
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

    /// <summary>
    /// Navigation property for Grades.
    /// Represents the grades awarded to students specifically in this class instance.
    /// Defines a one-to-many relationship between Class and Grade.
    /// </summary>
    public ICollection<Grade> Grades { get; set; }

    #endregion
}