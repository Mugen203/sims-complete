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

    // Navigation Properties
    [ForeignKey(nameof(AccountId))]
    public FeeAccount FeeAccount { get; set; } = null!;
}
