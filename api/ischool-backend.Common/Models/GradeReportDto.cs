using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

/// <summary>
///     Data Transfer Object for a student's grade report.
/// </summary>
public class GradeReportDto
{
    /// <summary>
    ///     List of grades for each course in the report.
    /// </summary>
    public List<CourseGradeDto> CourseGrades { get; set; } = new();
}

