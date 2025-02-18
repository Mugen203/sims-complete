using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities
{
    public class ClassEnrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EnrollmentId")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Student")]
        [MaxLength(13, ErrorMessage = "StudentId cannot exceed 13 characters")]
        public required string StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [MaxLength(10, ErrorMessage = "CourseId cannot exceed 10 characters")]
        public required string CourseId { get; set; }

        [Required]
        [ForeignKey("Lecturer")]
        [MaxLength(13, ErrorMessage = "LecturerId cannot exceed 13 characters")]
        public required string LecturerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTimeOffset EnrollmentDate { get; set; }

        [Required]
        [EnumDataType(typeof(Semester))]
        public Semester Semester { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
        [Display(Name = "Academic Year")]
        public required string AcademicYear { get; set; }

        [Required]
        [EnumDataType(typeof(EnrollmentStatus))]
        [Display(Name = "Enrollment Status")]
        public EnrollmentStatus Status { get; set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public Lecturer Lecturer { get; set; } = null!;

        // Optional navigation property to Grade
        public ICollection<Grade> Grades { get; set; } = [];
    }
}