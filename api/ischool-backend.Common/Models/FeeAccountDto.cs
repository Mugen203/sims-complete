namespace ischool_backend.Common.Models; 

/// <summary>
/// Data Transfer Object for summarizing a student's fee account.
/// </summary>
public class FeeAccountSummaryDto
{
    /// <summary>
    /// Outstanding balance in the fee account.
    /// </summary>
    public decimal OutstandingBalance { get; set; }

    /// <summary>
    /// Total fees for the current period.
    /// </summary>
    public decimal TotalFees { get; set; }

    /// <summary>
    /// Total amount paid towards fees.
    /// </summary>
    public decimal TotalPaid { get; set; }

    /// <summary>
    /// Current payment status (e.g., "Current", "Overdue").
    /// </summary>
    public string PaymentStatus { get; set; } = string.Empty;
}