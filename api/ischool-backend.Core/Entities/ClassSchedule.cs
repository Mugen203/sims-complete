using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a specific scheduled time slot for a Class instance.
/// A ClassSchedule defines when and where a particular Class meets (e.g., Monday 9:00 AM - 10:50 AM, Room 201).
/// Multiple ClassSchedule entries can exist for a single Class if it meets at different times or days.
/// </summary>
public class ClassSchedule
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public ClassSchedule()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new ClassSchedule instance with essential details.
    /// </summary>
    /// <param name="classCode">Code of the Class to which this schedule belongs.</param>
    /// <param name="classLocation">Location where the class is scheduled to take place.</param>
    /// <param name="startTime">Starting time of the scheduled class.</param>
    /// <param name="endTime">Ending time of the scheduled class.</param>
    /// <param name="dayOfWeek">Day of the week when the class is scheduled.</param>
    public ClassSchedule(string classCode, ClassLocation classLocation, TimeSpan startTime, TimeSpan endTime, DayOfWeek dayOfWeek)
    {
        ClassCode = classCode;
        ClassLocation = classLocation;
        StartTime = startTime;
        EndTime = endTime;
        DayOfWeek = dayOfWeek;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the ClassSchedule entry.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ScheduleId { get; set; }

    /// <summary>
    /// Code of the Class to which this schedule entry belongs.
    /// Foreign key to the Class entity.
    /// </summary>
    [Required(ErrorMessage = "ClassCode is required")]
    [MaxLength(20, ErrorMessage = "ClassCode cannot exceed 20 characters")] // Matches ClassCode in Class entity
    public required string ClassCode { get; set; }

    /// <summary>
    /// Location where the class is scheduled to take place for this specific time slot.
    /// Uses the ClassLocation enum to represent predefined locations (e.g., "Room 201", "Online").
    /// </summary>
    [Required]
    [EnumDataType(typeof(ClassLocation))]
    public required ClassLocation ClassLocation { get; set; }

    /// <summary>
    /// Starting time of the scheduled class slot.
    /// Represents the time of day the class begins (e.g., 09:00:00 for 9:00 AM).
    /// </summary>
    [Required]
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// Ending time of the scheduled class slot.
    /// Represents the time of day the class ends (e.g., 10:50:00 for 10:50 AM).
    /// </summary>
    [Required]
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Day of the week on which this class is scheduled (e.g., Monday, Tuesday, Wednesday).
    /// Uses the DayOfWeek enum provided by .NET (System namespace).
    /// </summary>
    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    // Removed Semester and AcademicYear properties - this information is already available through the related Class entity.
    // Keeping Semester and AcademicYear at Class level makes more sense as a Class is offered within a specific semester/year.
    // If a Class has schedules across different semesters/years, then you might reconsider keeping Semester/AcademicYear here,
    // but in most educational systems, a Class instance is tied to a specific term.

    /// <summary>
    /// Indicates if this schedule slot is currently booked or unavailable for scheduling conflicts.
    /// Defaults to false. Can be used for scheduling management and conflict detection.
    /// </summary>
    [Required]
    public bool IsBooked { get; set; } = false;

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Class entity.
    /// Represents the Class instance to which this schedule entry applies.
    /// Defines a many-to-one relationship between ClassSchedule and Class.
    /// </summary>
    [ForeignKey(nameof(ClassCode))]
    public required Class Class { get; set; } // Ensures Class navigation property is always populated
    
    /// <summary>
    /// **Navigation property for ClassSessions.**
    /// **Represents the collection of ClassSession instances associated with this ClassSchedule.**
    /// **Defines a one-to-many relationship between ClassSchedule and ClassSession.**
    /// </summary>
    public ICollection<ClassSession> ClassSessions { get; set; } = new HashSet<ClassSession>();


    // Removed navigation properties to Course and Lecturer as they are now accessed through the Class navigation property.

    #endregion
}