namespace ischool_backend.Common.Models;

/// <summary>
/// Data Transfer Object for a detailed fee statement.
/// </summary>
public class FeeStatementDto
{
    /// <summary>
    /// List of fee transactions in the statement.
    /// </summary>
    public List<FeePaymentDto> Transactions { get; set; } = new List<FeePaymentDto>();
}
