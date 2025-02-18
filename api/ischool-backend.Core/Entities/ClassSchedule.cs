using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities
{
    public class ClassSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required Guid ScheduleId { get; set; }

        [Required]
        [EnumDataType(typeof(ClassLocation))]
        public required ClassLocation ClassLocation { get; set; }

        [Required(ErrorMessage = "CourseCode is required")]
        [MaxLength(10)]
        public required string CourseCode { get; set; }

        [Required(ErrorMessage = "LecturerID is required")]
        [MaxLength(15)]
        public required string LecturerID { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        [EnumDataType(typeof(Semester))]
        public Semester Semester { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic Year must be in format YYYY-YYYY")]
        public required string AcademicYear { get; set; }

        [Required]
        public bool IsBooked { get; set; } = false;

        // Navigation properties
        [ForeignKey(nameof(CourseCode))]
        public Course? Course { get; set; }

        [ForeignKey(nameof(LecturerID))]
        public Lecturer? Lecturer { get; set; }
    }
}
