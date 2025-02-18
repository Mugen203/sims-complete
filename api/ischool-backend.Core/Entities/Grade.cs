using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid GradeID { get; set; }

    [Required(ErrorMessage = "Course code is required")]
    public required string CourseCode { get; set; }

    [Required(ErrorMessage = "StudentID is required")]
    public required string StudentID { get; set; }

    [DataType(DataType.Date)]
    public DateTimeOffset DateAwarded { get; set; }
    public int Credits { get; set; }

    [Required]
    [EnumDataType(typeof(GradeValue))]
    public GradeValue GradeValue { get; set; }

    [Required]
    [EnumDataType(typeof(Semester))]
    public Semester Semester { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
    [Display(Name = "Academic Year")]
    public required string AcademicYear { get; set; }

    [MaxLength(500, ErrorMessage = "Remarks cannot exceed 500 characters")]
    public string Remarks { get; set; } = string.Empty;


    //Navigation Properties
    [ForeignKey(nameof(StudentID))]
    public Student Student { get; set; } = null!; // Ensures Student is required

    [ForeignKey(nameof(CourseCode))]
    public Course Course { get; set; } = null!; // Ensures Course is required
}
