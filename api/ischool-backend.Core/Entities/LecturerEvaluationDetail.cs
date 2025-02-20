using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a detailed response within a LecturerEvaluation.
/// Stores individual evaluation ratings for different categories (e.g., Teaching Effectiveness, Communication).
/// Each LecturerEvaluation can have multiple LecturerEvaluationDetail records, one for each evaluation category.
/// </summary>
public class LecturerEvaluationDetail
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// </summary>
    public LecturerEvaluationDetail()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new LecturerEvaluationDetail instance with essential details.
    /// </summary>
    /// <param name="evaluationId">ID of the LecturerEvaluation to which this detail record belongs.</param>
    /// <param name="category">Category of evaluation (e.g., TeachingEffectiveness).</param>
    /// <param name="rating">Rating given for the category (e.g., 1 to 5).</param>
    public LecturerEvaluationDetail(Guid evaluationId, EvaluationCategory category, int rating)
    {
        EvaluationId = evaluationId;
        Category = category;
        Rating = rating;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the LecturerEvaluationDetail entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EvaluationDetailId { get; set; }

    /// <summary>
    /// ID of the LecturerEvaluation to which this detail record belongs.
    /// Foreign key to the LecturerEvaluation entity.
    /// </summary>
    [Required]
    public Guid EvaluationId { get; set; }

    /// <summary>
    /// Category of evaluation (e.g., TeachingEffectiveness, Communication, Subject Knowledge).
    /// Uses the EvaluationCategory enum for predefined evaluation categories.
    /// </summary>
    [Required]
    [EnumDataType(typeof(EvaluationCategory))]
    public EvaluationCategory Category { get; set; } // e.g., TeachingEffectiveness, Communication

    /// <summary>
    /// Rating given for the evaluation category.
    /// Represents the score or level of performance in the given category.
    /// Expected to be within the range of 1 to 5 (e.g., 1=Poor, 5=Excellent).
    /// Validated using the Range attribute.
    /// </summary>
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } // Example: 1 = Poor, 5 = Excellent

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the LecturerEvaluation entity.
    /// Represents the overall lecturer evaluation to which this detail record belongs.
    /// Defines a many-to-one relationship between LecturerEvaluationDetail and LecturerEvaluation.
    /// </summary>
    [ForeignKey(nameof(EvaluationId))]
    public required LecturerEvaluation LecturerEvaluation { get; set; } // Ensures LecturerEvaluation navigation property is always populated

    #endregion
}