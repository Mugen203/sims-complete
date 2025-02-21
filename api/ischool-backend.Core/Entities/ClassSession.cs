using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a single instance or occurrence of a scheduled class (ClassSchedule).
/// A ClassSession is a specific meeting of a class on a particular date, used for tracking attendance, topics, and session-specific information.
/// Time and Location are derived from the associated ClassSchedule.
/// </summary>
public class ClassSession
{
    #region Constructors and Properties (Keep existing constructors, adjust properties)

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public ClassSession()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new ClassSession instance with essential details.
    /// </summary>
    /// <param name="scheduleId">ID of the ClassSchedule to which this session belongs.</param>
    /// <param name="sessionDate">Date on which the class session takes place.</param>
    /// <param name="topics">Topics covered during the class session.</param>
    /// <param name="lecturerNotes">Optional notes from the lecturer for this session.</param>
    /// <param name="status">Status of the class session (e.g., Scheduled, Completed, Cancelled).</param>
    public ClassSession(Guid scheduleId, DateTimeOffset sessionDate, string topics, string? lecturerNotes = null,
        ClassSessionStatus status = ClassSessionStatus.Scheduled)
    {
        ScheduleId = scheduleId;
        SessionDate = sessionDate;
        Topics = topics;
        LecturerNotes = lecturerNotes;
        Status = status;
    }


    /// <summary>
    /// Unique identifier for the ClassSession entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ClassSessionId { get; set; }

    /// <summary>
    /// ID of the ClassSchedule to which this session belongs.
    /// Foreign key to the ClassSchedule entity.
    /// </summary>
    [Required]
    public Guid ScheduleId { get; set; }

    /// <summary>
    /// Date on which the class session is held.
    /// Represents the specific date of this session.
    /// </summary>
    [Required]
    public DateTimeOffset SessionDate { get; set; }


    /// <summary>
    /// Topics covered during this class session.
    /// Provides details about the content delivered in this session.
    /// </summary>
    [Required(ErrorMessage = "Topics is required")]
    [MaxLength(500, ErrorMessage = "Topics cannot exceed 500 characters")]
    public required string Topics { get; set; }

    /// <summary>
    /// Optional notes or comments from the lecturer specifically for this class session.
    /// Can include session-specific instructions, resources, or summaries.
    /// Nullable, as lecturers might not always provide notes for every session.
    /// </summary>
    [MaxLength(1000, ErrorMessage = "LecturerNotes cannot exceed 1000 characters")]
    public string? LecturerNotes { get; set; } // Nullable - notes are optional

    /// <summary>
    /// Status of the class session.
    /// Uses the ClassSessionStatus enum to represent the current state of the session (e.g., Scheduled, Completed, Cancelled).
    /// Defaults to 'Scheduled' when a new ClassSession is created.
    /// </summary>
    [Required]
    [EnumDataType(typeof(ClassSessionStatus))]
    public ClassSessionStatus Status { get; set; } = ClassSessionStatus.Scheduled; // Default status

    #endregion

    #region Navigation Properties 

    /// <summary>
    /// Navigation property to the ClassSchedule entity.
    /// Represents the ClassSchedule to which this session is an instance of.
    /// Defines a many-to-one relationship between ClassSession and ClassSchedule.
    /// </summary>
    [ForeignKey(nameof(ScheduleId))]
    public required ClassSchedule Schedule { get; set; } // Ensures Schedule navigation property is always populated

    #endregion
}