using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class LecturerEvaluation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EvaluationId { get; set; }

    [Required]
    public required string LecturerID { get; set; }

    [Required]
    public DateTimeOffset EvaluationDate { get; set; }

    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
    [Display(Name = "Academic Year")]
    public string AcademicYear { get; set; } = null!;

    [MaxLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
    public string? Comments { get; set; } // Optional comment field


    // Navigation Properties
    [ForeignKey(nameof(LecturerID))]
    public Lecturer Lecturer { get; set; } = null!;

    public ICollection<LecturerEvaluationDetail> EvaluationDetails { get; set; } = [];
}

