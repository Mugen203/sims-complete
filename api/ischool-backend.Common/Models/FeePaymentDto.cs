using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for a single fee transaction in a statement.
/// </summary>
public class FeePaymentDto
{
    public DateTimeOffset PaymentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public CommonPaymentMethod PaymentMethod { get; set; }
    public string PaymentReference { get; set; } = string.Empty;
    public CommonSemester Semester { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public CommonPaymentStatus Status { get; set; }
    public string? Description { get; set; }
    public bool ReceiptIssued { get; set; }
    public string? ReceiptNumber { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
}