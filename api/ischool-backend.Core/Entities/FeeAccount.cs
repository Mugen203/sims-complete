// FeeAccount.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a financial account for a student, tracking fees due and payments.
/// Each student has a FeeAccount to manage their financial transactions with the institution.
/// </summary>
public class FeeAccount
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and for database operations.
    /// </summary>
    public FeeAccount()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new FeeAccount instance with essential details.
    /// </summary>
    /// <param name="studentId">ID of the Student associated with this fee account.</param>
    /// <param name="academicYear">Academic year for which this fee account is relevant (e.g., "2023-2024").</param>
    public FeeAccount(string studentId, string academicYear)
    {
        StudentID = studentId ?? throw new ArgumentNullException(nameof(studentId));
        AcademicYear = academicYear ?? throw new ArgumentNullException(nameof(academicYear));
        TotalFeeDue = 0; // Initialize default values
        TotalFeePaid = 0;  // Initialize default values
        Currency = Currency.GHS; // Set default currency
        Semester = Semester.September;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the FeeAccount entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid AccountId { get; set; }

    /// <summary>
    /// Total amount of fees due for this account.
    /// Represents the sum of all charges and fees assessed to the student's account.
    /// </summary>
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Total fee due cannot be negative.")] // Ensure non-negative value
    public decimal TotalFeeDue { get; set; }

    /// <summary>
    /// Total amount of fees paid by the student towards this account.
    /// Represents the sum of all payments made by the student.
    /// </summary>
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Total fee paid cannot be negative.")] // Ensure non-negative value
    public decimal TotalFeePaid { get; set; }

    /// <summary>
    /// Calculated property to get the outstanding balance on the fee account.
    /// Derived from TotalFeeDue and TotalFeePaid. Not mapped to the database.
    /// </summary>
    [NotMapped] // Ensures this property is not mapped to a database column
    public decimal OutstandingBalance => TotalFeeDue - TotalFeePaid;

    /// <summary>
    /// Currency in which the fees are denominated.
    /// Uses the Currency enum for predefined currency options (e.g., GHS, USD, EUR).
    /// Defaults to GHS (Ghanaian Cedi).
    /// </summary>
    [Required]
    [EnumDataType(typeof(Currency))]
    public Currency Currency { get; set; } = Currency.GHS; // Default currency is GHS

    /// <summary>
    /// Semester to which this fee account applies.
    /// Uses the Semester enum for predefined semester values (e.g., Fall, Spring).
    /// </summary>
    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; } // Consider if Semester should be nullable or have a default

    /// <summary>
    /// Academic year for which this fee account is valid.
    /// Format "YYYY-YYYY" (e.g., "2023-2024").
    /// Validated with a RegularExpression to ensure correct format.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
    [Display(Name = "Academic Year")] // For display in UI labels
    [MaxLength(9, ErrorMessage = "Academic Year cannot exceed 9 characters")]
    public required string AcademicYear { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// ID of the Student associated with this fee account.
    /// Foreign key to the Student entity.
    /// </summary>
    [Required]
    [ForeignKey("Student")] // Clarifying ForeignKey attribute
    [MaxLength(13, ErrorMessage = "StudentId cannot exceed 13 characters")]
    public required string StudentID { get; set; }

    /// <summary>
    /// Navigation property to the Student entity.
    /// Represents the student who owns this fee account.
    /// Defines a one-to-one relationship (one FeeAccount per Student).
    /// </summary>
    public Student Student { get; set; } // Should be required but it's causing issues I cannot fix yet

    #endregion
}