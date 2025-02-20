using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a payment made towards a student's FeeAccount.
/// Tracks payment details such as date, amount, method, reference, and audit information.
/// </summary>
public class FeePayment
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// Initializes default values for PaymentDate and CreatedAt.
    /// </summary>
    public FeePayment()
    {
        PaymentDate = DateTimeOffset.UtcNow; // Default PaymentDate to current time
        CreatedAt = DateTimeOffset.UtcNow;   // Default CreatedAt to current time
    }

    /// <summary>
    /// Parameterized constructor to create a new FeePayment instance with essential details.
    /// </summary>
    /// <param name="accountId">ID of the FeeAccount to which this payment is applied.</param>
    /// <param name="amountPaid">Amount paid in this transaction.</param>
    /// <param name="paymentMethod">Method of payment used.</param>
    /// <param name="paymentReference">Reference number or identifier for the payment.</param>
    /// <param name="semester">Semester for which the payment is made.</param>
    /// <param name="academicYear">Academic year for which the payment is made (e.g., "2023-2024").</param>
    /// <param name="createdBy">User who created this payment record.</param>
    public FeePayment(Guid accountId, decimal amountPaid, PaymentMethod paymentMethod, string paymentReference, Semester semester, string academicYear, string createdBy)
    {
        AccountId = accountId;
        PaymentDate = DateTimeOffset.UtcNow; // Set PaymentDate to current time at creation
        AmountPaid = amountPaid;
        PaymentMethod = paymentMethod;
        PaymentReference = paymentReference;
        Semester = semester;
        AcademicYear = academicYear;
        Status = PaymentStatus.Pending; // Default status for new payments. Consider if this is always 'Pending' initially.
        CreatedBy = createdBy;
        CreatedAt = DateTimeOffset.UtcNow; // Set CreatedAt to current time at creation
        ReceiptIssued = false;            // Default to false
    }


    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the FeePayment entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PaymentID { get; set; }

    /// <summary>
    /// ID of the FeeAccount to which this payment is applied.
    /// Foreign key to the FeeAccount entity.
    /// </summary>
    [Required]
    public Guid AccountId { get; set; }

    /// <summary>
    /// Date and time when the payment was made.
    /// Defaults to the time of creation of the FeePayment record.
    /// </summary>
    [Required]
    public DateTimeOffset PaymentDate { get; set; }

    /// <summary>
    /// Amount paid in this transaction.
    /// Stored as decimal with precision of 18 and scale of 2 to handle monetary values accurately.
    /// Must be greater than zero.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount paid must be greater than zero")]
    public decimal AmountPaid { get; set; }

    /// <summary>
    /// Method of payment used (e.g., Cash, Credit Card, Mobile Money).
    /// Uses the PaymentMethod enum for predefined payment method options.
    /// </summary>
    [Required]
    [EnumDataType(typeof(PaymentMethod))]
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Reference number or identifier for the payment transaction.
    /// Could be a transaction ID, receipt number from payment gateway, or similar.
    /// </summary>
    [Required]
    [MaxLength(50, ErrorMessage = "PaymentReference cannot exceed 50 characters")]
    public string PaymentReference { get; set; } = null!; // Non-nullable

    /// <summary>
    /// Semester for which this payment is being made.
    /// Uses the Semester enum for predefined semester values.
    /// </summary>
    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    /// <summary>
    /// Academic year for which this payment is being made.
    /// Format "YYYY-YYYY" (e.g., "2023-2024").
    /// Validated with a RegularExpression to ensure correct format.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format ENGINEERING-YYYY")]
    [Display(Name = "Academic Year")] // For display in UI labels
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public string AcademicYear { get; set; } = null!; // Non-nullable

    /// <summary>
    /// Current status of the payment (e.g., Pending, Completed, Failed).
    /// Uses the PaymentStatus enum for predefined payment status values.
    /// Defaults to 'Pending' in parameterized constructor. Consider if default should be different.
    /// </summary>
    [Required]
    [EnumDataType(typeof(PaymentStatus))]
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending; // Default status - consider if Pending is always initial status

    /// <summary>
    /// Optional description or notes about the payment.
    /// Can be used to add context or details about the payment.
    /// Nullable.
    /// </summary>
    [MaxLength(200, ErrorMessage = "Payment description cannot exceed 200 characters")]
    public string? Description { get; set; } // Nullable - description is optional

    /// <summary>
    /// Indicates whether a receipt has been issued for this payment.
    /// Defaults to false upon creation.
    /// </summary>
    public bool ReceiptIssued { get; set; } = false; // Default to false

    /// <summary>
    /// Optional receipt number associated with this payment.
    /// Nullable, as a receipt number might not always be immediately available or applicable.
    /// </summary>
    [MaxLength(50, ErrorMessage = "Receipt number cannot exceed 50 characters")]
    public string? ReceiptNumber { get; set; } // Nullable - receipt number is optional

    /// <summary>
    /// User who created this payment record (audit trail).
    /// Required for audit logging and tracking payment creation.
    /// </summary>
    [Required]
    [MaxLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters")]
    public string CreatedBy { get; set; } = null!; // Non-nullable for audit trail

    /// <summary>
    /// Date and time when this payment record was created (audit trail).
    /// Defaults to the time of FeePayment object instantiation.
    /// </summary>
    [Required]
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// User who last modified this payment record (audit trail).
    /// Nullable, as a payment record might not be modified after creation.
    /// </summary>
    [MaxLength(50, ErrorMessage = "LastModifiedBy cannot exceed 50 characters")]
    public string? LastModifiedBy { get; set; } // Nullable - not always modified

    /// <summary>
    /// Date and time when this payment record was last modified (audit trail).
    /// Nullable, as a payment record might not be modified after creation.
    /// </summary>
    public DateTimeOffset? LastModifiedAt { get; set; } // Nullable - not always modified

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the FeeAccount entity.
    /// Represents the FeeAccount to which this payment is applied.
    /// Defines a many-to-one relationship between FeePayment and FeeAccount.
    /// </summary>
    [ForeignKey(nameof(AccountId))]
    public required FeeAccount FeeAccount { get; set; } // Ensures FeeAccount navigation property is always populated

    #endregion
}