namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for a student's GPA (Grade Point Average).
/// </summary>
public class GpaDto
{
    /// <summary>
    /// The Grade Point Average value.
    /// </summary>
    public decimal GpaValue { get; set; }
}