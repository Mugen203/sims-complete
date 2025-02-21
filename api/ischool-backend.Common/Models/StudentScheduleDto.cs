namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for representing a student's class schedule.
/// </summary>
public class StudentScheduleDto
{
    /// <summary>
    /// List of class sessions in the schedule.
    /// </summary>
    public List<ClassSessionDto> ClassSessions { get; set; } = new List<ClassSessionDto>();
}