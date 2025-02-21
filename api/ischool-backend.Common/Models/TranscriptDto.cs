using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for a student's academic transcript.
/// </summary>
public class TranscriptDto
{
    /// <summary>
    /// List of grades for all courses taken, across all semesters.
    /// </summary>
    public List<TranscriptCourseRecordDto> CourseRecords { get; set; } = new List<TranscriptCourseRecordDto>();

    /// <summary>
    /// Cumulative Grade Point Average (CGPA).
    /// </summary>
    public decimal CumulativeGpa { get; set; }
}

/// <summary>
/// Data Transfer Object for a single course record in a transcript.
/// </summary>
public class TranscriptCourseRecordDto
{
    /// <summary>
    /// Name or Code of the Course.
    /// </summary>
    public string CourseName { get; set; } = string.Empty;

    /// <summary>
    /// Grade received in the course.
    /// </summary>
    public CommonGrade Grade { get; set; }

    /// <summary>
    /// Credit hours for the course.
    /// </summary>
    public int Credits { get; set; }

    /// <summary>
    /// Semester or Academic Year in which the course was taken.
    /// </summary>
    public CommonSemester Semester { get; set; }
}