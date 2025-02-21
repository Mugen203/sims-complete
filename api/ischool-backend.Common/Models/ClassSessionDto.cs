using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for representing a single class session in a schedule.
/// </summary>
public class ClassSessionDto
{
    /// <summary>
    /// Name or Code of the Course.
    /// </summary>
    public string CourseName { get; set; } = string.Empty; // Initialize to avoid null exceptions

    /// <summary>
    /// Name of the Lecturer for this session.
    /// </summary>
    public string LecturerName { get; set; } = string.Empty;

    /// <summary>
    /// Start time of the class session.
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// End time of the class session.
    /// </summary>
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Day of the week for the class session.
    /// </summary>
    public string DayOfWeek { get; set; } = string.Empty;

    /// <summary>
    /// Classroom where the class session is held.
    /// </summary>
    public string Venue { get; set; } = string.Empty;
    
    /// <summary>
    /// Location of the class, using the ClassLocation enum.
    /// </summary>
    public ClassLocation? ClassLocation { get; set; } // Use ClassLocation enum type
    // You can also add a string property to represent the location as a string for API response
    // if needed for simpler client consumption:
    public string ClassLocationString => ClassLocation.ToString();
}