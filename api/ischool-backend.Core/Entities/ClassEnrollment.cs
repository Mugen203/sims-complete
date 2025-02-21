using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents the enrollment of a Student in a specific Class instance.
/// Tracks student enrollment in a class for a particular semester and academic year.
/// </summary>
public class ClassEnrollment
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public ClassEnrollment()
    {
        Grades = new HashSet<Grade>(); // Initialize Grades collection
    }

    /// <summary>
    /// Parameterized constructor to create a new ClassEnrollment instance with essential details.
    /// </summary>
    /// <param name="studentId">ID of the Student being enrolled.</param>
    /// <param name="classCode">Code of the Class in which the student is enrolling.</param>
    /// <param name="enrollmentDate">Date of enrollment.</param>
    /// <param name="semester">Semester of enrollment.</param>
    /// <param name="academicYear">Academic year of enrollment (e.g., "2023-2024").</param>
    /// <param name="status">Enrollment status (e.g., Active, Waitlisted, Dropped).</param>
    public ClassEnrollment(string studentId, string classCode, DateTimeOffset enrollmentDate, Semester semester, string academicYear, EnrollmentStatus status)
    {
        StudentId = studentId;
        ClassCode = classCode;
        EnrollmentDate = enrollmentDate;
        Semester = semester;
        AcademicYear = academicYear;
        Status = status;

        Grades = new HashSet<Grade>(); // Initialize Grades collection
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the ClassEnrollment record.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EnrollmentId")] // Explicitly naming the column for clarity - optional
    public Guid Id { get; set; }

    /// <summary>
    /// ID of the Student being enrolled in the class.
    /// Foreign key to the Student entity.
    /// </summary>
    [Required]
    [ForeignKey("Student")] // Clarifying ForeignKey attribute
    [MaxLength(13, ErrorMessage = "StudentId cannot exceed 13 characters")]
    public required string StudentId { get; set; }

    /// <summary>
    /// Code of the Class in which the student is enrolled.
    /// Foreign key to the Class entity.
    /// </summary>
    [Required(ErrorMessage = "ClassCode is required")]
    [ForeignKey("Class")] // Clarifying ForeignKey attribute
    [MaxLength(20, ErrorMessage = "ClassCode cannot exceed 20 characters")] // Matches ClassCode in Class entity
    public required string ClassCode { get; set; }

    /// <summary>
    /// Date when the student enrolled in the class.
    /// </summary>
    [Required]
    [DataType(DataType.Date)] // Use DataType.Date for UI display formatting if needed
    [Display(Name = "Enrollment Date")] // For display in UI labels
    public DateTimeOffset EnrollmentDate { get; set; }

    /// <summary>
    /// Semester of the enrollment.
    /// Uses the Semester enum for predefined semester values.
    /// </summary>
    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    /// <summary>
    /// Academic year of the enrollment.
    /// Format "YYYY-YYYY" (e.g., "2023-2024").
    /// Validated with a RegularExpression to ensure correct format.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in формате YYYY-YYYY")]
    [Display(Name = "Academic Year")] // For display in UI labels
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public required string AcademicYear { get; set; }

    /// <summary>
    /// Current enrollment status of the student in the class (e.g., Active, Waitlisted, Dropped).
    /// Uses the EnrollmentStatus enum for predefined status values.
    /// </summary>
    [Required]
    [EnumDataType(typeof(EnrollmentStatus))]
    [Display(Name = "Enrollment Status")] // For display in UI labels
    public EnrollmentStatus Status { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Student entity.
    /// Represents the student who is enrolled in this class.
    /// Defines a many-to-one relationship between ClassEnrollment and Student.
    /// </summary>
    public required Student Student { get; set; } // Ensures Student navigation property is always populated

    /// <summary>
    /// Navigation property to the Class entity.
    /// Represents the Class instance in which the student is enrolled.
    /// Defines a many-to-one relationship between ClassEnrollment and Class.
    /// </summary>
    public required Class Class { get; set; } // Ensures Class navigation property is always populated

    /// <summary>
    /// Navigation property for Grades.
    /// Represents the grades awarded to this student specifically for this class enrollment.
    /// Defines a one-to-many relationship between ClassEnrollment and Grade.
    /// </summary>
    public ICollection<Grade> Grades { get; set; } = new HashSet<Grade>(); // Initialize to empty collection

    // Removed navigation properties to Course and Lecturer as they are accessed through the Class navigation property.

    #endregion
}