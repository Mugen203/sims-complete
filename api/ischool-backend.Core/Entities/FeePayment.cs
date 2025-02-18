using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class FeePayment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PaymentID { get; set; }

    [Required]
    public Guid AccountId { get; set; }

    [Required]
    public DateTimeOffset PaymentDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount paid must be greater than zero")]
    public decimal AmountPaid { get; set; }

    [Required]
    [EnumDataType(typeof(PaymentMethod))]
    public PaymentMethod PaymentMethod { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "PaymentReference cannot exceed 50 characters")]
    public string PaymentReference { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
    [Display(Name = "Academic Year")]
    public string AcademicYear { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(PaymentStatus))]
    public PaymentStatus Status { get; set; }

    [MaxLength(200, ErrorMessage = "Payment description cannot exceed 200 characters")]
    public string? Description { get; set; }

    // Receipt tracking
    public bool ReceiptIssued { get; set; }
    [MaxLength(50, ErrorMessage = "Receipt number cannot exceed 50 characters")]
    public string? ReceiptNumber { get; set; }

    // Audit trail fields
    [Required]
    [MaxLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters")]
    public string CreatedBy { get; set; } = null!;

    [Required]
    public DateTimeOffset CreatedAt { get; set; }

    [MaxLength(50, ErrorMessage = "LastModifiedBy cannot exceed 50 characters")]
    public string? LastModifiedBy { get; set; }

    public DateTimeOffset? LastModifiedAt { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(AccountId))]
    public FeeAccount FeeAccount { get; set; } = null!;
}