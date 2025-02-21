using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
///     Represents a record of a student's attendance at a specific ClassSession.
///     Tracks when attendance was marked, whether it was student-marked and lecturer-approved, the attendance status, and
///     any relevant notes.
/// </summary>
public class AttendanceRecord
{
    #region Constructors

    /// <summary>
    ///     Parameterless constructor for Entity Framework Core.
    ///     Required for EF Core to create proxies and for database operations.
    /// </summary>
    public AttendanceRecord()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    ///     Parameterized constructor to create a new AttendanceRecord instance with essential details.
    /// </summary>
    /// <param name="studentId">ID of the Student for whom attendance is being recorded.</param>
    /// <param name="classSessionId">ID of the ClassSession for which attendance is being recorded.</param>
    /// <param name="markTime">Timestamp when attendance was marked.</param>
    /// <param name="attendanceStatus">Status of the attendance (e.g., Present, Absent, Late).</param>
    public AttendanceRecord(string studentId, Guid classSessionId, DateTimeOffset markTime,
        AttendanceStatus attendanceStatus)
    {
        StudentId = studentId;
        ClassSessionId = classSessionId;
        MarkTime = markTime;
        AttendanceStatus = attendanceStatus;
        StudentMarked = false; // Default to false, explicitly set if student-marked
        LecturerApproved = false; // Default to false, approval happens later if needed
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Unique identifier for the AttendanceRecord entity.
    ///     Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid AttendanceRecordId { get; set; } // Renamed to AttendanceRecordId 

    /// <summary>
    ///     ID of the Student for whom attendance is recorded.
    ///     Foreign key to the Student entity.
    /// </summary>
    [Required(ErrorMessage = "StudentID is required")]
    [ForeignKey("Student")] // Clarifying ForeignKey attribute
    [MaxLength(13, ErrorMessage = "StudentID cannot exceed 13 characters")]
    public required string StudentId { get; set; }

    /// <summary>
    ///     ID of the ClassSession for which attendance is being recorded.
    ///     Foreign key to the ClassSession entity.
    /// </summary>
    [Required(ErrorMessage = "ClassSessionID is required")]
    [ForeignKey("ClassSession")] // Clarifying ForeignKey attribute
    public required Guid ClassSessionId { get; set; }

    /// <summary>
    ///     Timestamp when the attendance record was created or marked.
    ///     Represents when the attendance was registered in the system.
    /// </summary>
    [Required(ErrorMessage = "MarkTime is required")]
    public DateTimeOffset MarkTime { get; set; }

    /// <summary>
    ///     Indicates whether the attendance was initially marked by the student themselves (e.g., through a self-check-in
    ///     system).
    ///     Defaults to false, implying lecturer or system-marked attendance.
    /// </summary>
    [Required(ErrorMessage = "StudentMarked is required")]
    public bool StudentMarked { get; set; } // Default to false

    /// <summary>
    ///     Indicates whether a lecturer has officially approved or verified this attendance record.
    ///     Used in scenarios where attendance needs lecturer confirmation.
    ///     Defaults to false, and is set to true upon lecturer approval.
    /// </summary>
    [Required(ErrorMessage = "LecturerApproved is required")]
    public bool LecturerApproved { get; set; } // Default to false

    /// <summary>
    ///     Timestamp when the attendance record was approved by a lecturer (if applicable).
    ///     Nullable, as approval might not always be required or might be pending.
    /// </summary>
    public DateTimeOffset? ApprovalTime { get; set; } // Nullable - approval might be pending or not required

    /// <summary>
    ///     Status of the attendance (e.g., Present, Absent, Late, Excused).
    ///     Uses the AttendanceStatus enum for predefined attendance status values.
    ///     Replaces the string 'Status' property with a strongly-typed enum for better data integrity and validation.
    /// </summary>
    [Required(ErrorMessage = "Attendance Status is required")]
    [EnumDataType(typeof(AttendanceStatus))]
    public required AttendanceStatus AttendanceStatus { get; set; } // Replaced string Status with AttendanceStatus enum

    /// <summary>
    ///     Optional notes or remarks related to the attendance record.
    ///     Can be used to provide context or reasons for a particular attendance status (e.g., "Medical Leave", "Late due to
    ///     traffic").
    ///     Defaults to an empty string.
    /// </summary>
    [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
    public string Notes { get; set; } = string.Empty;

    #endregion

    #region Navigation Properties

    /// <summary>
    ///     Navigation property to the Student entity.
    ///     Represents the student whose attendance is recorded.
    ///     Defines a many-to-one relationship between AttendanceRecord and Student.
    /// </summary>
    public required Student Student { get; set; } // Ensures Student navigation property is always populated

    /// <summary>
    ///     Navigation property to the ClassSession entity.
    ///     Represents the specific class session for which attendance is recorded.
    ///     Defines a many-to-one relationship between AttendanceRecord and ClassSession.
    /// </summary>
    public required ClassSession
        ClassSession { get; set; } // Ensures ClassSession navigation property is always populated

    #endregion
}