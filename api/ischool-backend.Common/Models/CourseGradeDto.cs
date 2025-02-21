using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

/// <summary>
///     Data Transfer Object for a single course grade in a grade report.
/// </summary>
public class CourseGradeDto
{
    /// <summary>
    ///     Name or Code of the Course.
    /// </summary>
    public string CourseName { get; set; } = string.Empty;

    /// <summary>
    ///     Letter grade or percentage grade received in the course.
    /// </summary>
    public CommonGrade Grade { get; set; }

    /// <summary>
    ///     Credit hours for the course.
    /// </summary>
    public int Credits { get; set; }

    /// <summary>
    ///     Semester or Academic Year in which the course was taken.
    /// </summary>
    public CommonSemester Semester { get; set; }
}
