namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for a single fee transaction in a statement.
/// </summary>
public class FeeTransactionDto
{
    /// <summary>
    /// Date of the transaction.
    /// </summary>
    public DateTimeOffset TransactionDate { get; set; }

    /// <summary>
    /// Type of transaction (e.g., "Tuition Fee", "Payment", "Fine").
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// Description of the transaction.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Amount of the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Running balance after the transaction.
    /// </summary>
    public decimal RunningBalance { get; set; }
}