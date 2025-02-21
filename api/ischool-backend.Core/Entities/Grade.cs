using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a grade awarded to a student for a specific course in a particular semester and academic year.
/// This entity links a Student to a Course and records the achieved GradeValue.
/// </summary>
public class Grade
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public Grade()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new Grade instance with essential details.
    /// </summary>
    /// <param name="courseCode">Code of the course for which the grade is awarded.</param>
    /// <param name="studentId">ID of the student who received the grade.</param>
    /// <param name="gradeValue">The grade value (e.g., A, B+, C) awarded.</param>
    /// <param name="semester">Semester in which the course was taken.</param>
    /// <param name="academicYear">Academic year in which the course was taken (e.g., "2023-2024").</param>
    /// <param name="dateAwarded">Date when the grade was officially awarded.</param>
    /// <param name="remarks">Optional remarks or notes about the grade.</param>
    public Grade(string courseCode, string studentId, GradeValue gradeValue, Semester semester, string academicYear, DateTimeOffset dateAwarded, string remarks = "")
    {
        CourseCode = courseCode;
        StudentID = studentId;
        GradeValue = gradeValue;
        Semester = semester;
        AcademicYear = academicYear;
        DateAwarded = dateAwarded;
        Remarks = remarks;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the Grade entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid GradeID { get; set; }

    /// <summary>
    /// Code of the course for which the grade is awarded.
    /// This is also a foreign key to the Course entity.
    /// </summary>
    [Required(ErrorMessage = "Course code is required")]
    [MaxLength(10, ErrorMessage = "Course code cannot exceed 10 characters")] 
    public required string CourseCode { get; set; }

    /// <summary>
    /// ID of the student who received the grade.
    /// This is also a foreign key to the Student entity.
    /// </summary>
    [Required(ErrorMessage = "StudentID is required")]
    [MaxLength(13, ErrorMessage = "StudentID cannot exceed 13 characters")]
    public required string StudentID { get; set; }

    /// <summary>
    /// Date when the grade was officially awarded or recorded.
    /// </summary>
    [DataType(DataType.Date)] // Use DataType.Date for UI display formatting if needed
    public DateTimeOffset DateAwarded { get; set; }

    /// <summary>
    /// The actual grade value awarded (e.g., A, B+, C, F).
    /// Uses the GradeValue enum to represent predefined grade options.
    /// </summary>
    [Required]
    [EnumDataType(typeof(GradeValue))]
    public GradeValue GradeValue { get; set; }

    /// <summary>
    /// Semester in which the course was taken (e.g., Fall, Spring, Summer).
    /// Uses the Semester enum to represent predefined semesters.
    /// </summary>
    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    /// <summary>
    /// Academic year in which the course was taken.
    /// Format should be "YYYY-YYYY" (e.g., "2023-2024").
    /// Validated with a RegularExpression to ensure correct format.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in YYYY-YYYY format")]
    [Display(Name = "Academic Year")] // For display in UI labels
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public required string AcademicYear { get; set; }

    /// <summary>
    /// Optional remarks or notes related to the grade.
    /// Can be used for additional context or explanations about the grade.
    /// Defaults to an empty string.
    /// </summary>
    [MaxLength(500, ErrorMessage = "Remarks cannot exceed 500 characters")]
    public string Remarks { get; set; } = string.Empty; 

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Student entity.
    /// Represents the student who received this grade.
    /// Defines a many-to-one relationship between Grade and Student.
    /// </summary>
    [ForeignKey(nameof(StudentID))]
    public required Student Student { get; set; } // Ensures Student navigation property is always populated

    /// <summary>
    /// Navigation property to the Course entity.
    /// Represents the course for which this grade was awarded.
    /// Defines a many-to-one relationship between Grade and Course.
    /// </summary>
    [ForeignKey(nameof(CourseCode))]
    public required Course Course { get; set; } // Ensures Course navigation property is always populated

    #endregion
}