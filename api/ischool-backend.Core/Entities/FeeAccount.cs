using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities
{
    public class FeeAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountId { get; set; }

        [Required]
        public decimal TotalFeeDue { get; set; }

        [Required]
        public decimal TotalFeePaid { get; set; }

        [NotMapped] // Ensure this is calculated dynamically
        public decimal OutstandingBalance => TotalFeeDue - TotalFeePaid;

        [Required]
        [EnumDataType(typeof(Currency))]
        public Currency Currency { get; set; } = Currency.GHS;

        [Required]
        public Semester Semester { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
        [Display(Name = "Academic Year")]
        public required string AcademicYear { get; set; }

        // Navigation properties
        [Required]
        [ForeignKey("Student")]
        [MaxLength(13, ErrorMessage = "StudentId cannot exceed 13 characters")]
        public required string StudentID { get; set; }

        public Student Student { get; set; } = null!;


        // Allow object initialization without parameters
        public FeeAccount() { }
        public FeeAccount(string studentId, string academicYear)
        {
            StudentID = studentId ?? throw new ArgumentNullException(nameof(studentId));
            AcademicYear = academicYear ?? throw new ArgumentNullException(nameof(academicYear));
        }
    }
}
