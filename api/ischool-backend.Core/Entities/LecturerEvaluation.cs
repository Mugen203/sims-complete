using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents an evaluation of a Lecturer's performance.
/// Stores general evaluation information and links to detailed evaluation responses in LecturerEvaluationDetail.
/// </summary>
public class LecturerEvaluation
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// Initializes the EvaluationDetails collection and sets the EvaluationDate to the current time.
    /// </summary>
    public LecturerEvaluation()
    {
        EvaluationDetails = new HashSet<LecturerEvaluationDetail>(); // Initialize navigation collection
        EvaluationDate = DateTimeOffset.UtcNow; // Default EvaluationDate to current time
    }

    /// <summary>
    /// Parameterized constructor to create a new LecturerEvaluation instance with essential details.
    /// </summary>
    /// <param name="lecturerId">ID of the Lecturer being evaluated.</param>
    /// <param name="semester">Semester in which the evaluation is conducted.</param>
    /// <param name="academicYear">Academic year for the evaluation (e.g., "2023-2024").</param>
    public LecturerEvaluation(string lecturerId, Semester semester, string academicYear)
    {
        LecturerId = lecturerId ?? throw new ArgumentNullException(nameof(lecturerId));
        EvaluationDate = DateTimeOffset.UtcNow; // Set EvaluationDate to current time at creation
        Semester = semester;
        AcademicYear = academicYear ?? throw new ArgumentNullException(nameof(academicYear));
        EvaluationDetails = new HashSet<LecturerEvaluationDetail>(); // Initialize navigation collection
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the LecturerEvaluation entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EvaluationId { get; set; }

    /// <summary>
    /// ID of the Lecturer being evaluated.
    /// Foreign key to the Lecturer entity.
    /// </summary>
    [Required(ErrorMessage = "LecturerID is required")]
    [MaxLength(13, ErrorMessage = "LecturerID cannot exceed 13 characters")]
    [ForeignKey("Lecturer")] // Clarifying ForeignKey attribute
    public required string LecturerId { get; set; } // Renamed to LecturerId for consistency

    /// <summary>
    /// Date and time when the evaluation was conducted or recorded.
    /// Defaults to the current time upon creation.
    /// </summary>
    [Required]
    public DateTimeOffset EvaluationDate { get; set; } = DateTimeOffset.UtcNow; // Default value set in parameterless constructor

    /// <summary>
    /// Semester in which the evaluation is being conducted.
    /// Uses the Semester enum for predefined semester values.
    /// </summary>
    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    /// <summary>
    /// Academic year for which this evaluation is being conducted.
    /// Format "YYYY-YYYY" (e.g., "2023-2024").
    /// Validated with a RegularExpression to ensure correct format.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format ENGINEERING-YYYY")]
    [Display(Name = "Academic Year")] // For display in UI labels
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public string AcademicYear { get; set; } = null!; // Non-nullable

    /// <summary>
    /// Optional comments or general feedback about the lecturer's performance.
    /// Provides a space for qualitative feedback.
    /// Nullable.
    /// </summary>
    [MaxLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
    public string? Comments { get; set; } // Optional comment field

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Lecturer entity.
    /// Represents the lecturer being evaluated.
    /// Defines a many-to-one relationship between LecturerEvaluation and Lecturer.
    /// </summary>
    [ForeignKey(nameof(LecturerId))]
    public required Lecturer Lecturer { get; set; } // Ensures Lecturer navigation property is always populated

    /// <summary>
    /// Navigation property to the collection of LecturerEvaluationDetail entities.
    /// Represents the detailed responses or answers provided in this evaluation.
    /// Defines a one-to-many relationship between LecturerEvaluation and LecturerEvaluationDetail.
    /// </summary>
    public ICollection<LecturerEvaluationDetail> EvaluationDetails { get; set; } // Virtual for lazy loading if needed, use HashSet for initialization

    #endregion
}