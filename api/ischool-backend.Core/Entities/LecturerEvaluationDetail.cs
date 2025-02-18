using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class LecturerEvaluationDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EvaluationDetailId { get; set; }

    [Required]
    public Guid EvaluationId { get; set; } // Foreign Key to LecturerEvaluation

    [Required]
    [EnumDataType(typeof(EvaluationCategory))]
    public EvaluationCategory Category { get; set; } // e.g., TeachingEffectiveness, Communication

    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } // Example: 1 = Poor, 5 = Excellent

    [ForeignKey(nameof(EvaluationId))]
    public LecturerEvaluation LecturerEvaluation { get; set; } = null!;
}
