using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ischool_backend.Core.Entities
{
    public class AttendanceRecord
    {
        [Key]
        [Required(ErrorMessage = "AttendanceID is required")]
        [MaxLength(20, ErrorMessage = "AttendanceID cannot exceed 20 characters")]
        public Guid AttendanceID { get; set; }

        [Required(ErrorMessage = "StudentID is required")]
        [ForeignKey("Student")]
        public required string StudentID { get; set; }

        [Required(ErrorMessage = "ClassSessionID is required")]
        [ForeignKey("ClassSession")]
        public required string ClassSessionID { get; set; }

        [Required(ErrorMessage = "MarkTime is required")]
        public DateTimeOffset MarkTime { get; set; }

        [Required(ErrorMessage = "StudentMarked is required")]
        public bool StudentMarked { get; set; }

        [Required(ErrorMessage = "LecturerApproved is required")]
        public bool LecturerApproved { get; set; }

        // ApprovalTime can be null if not yet approved
        public DateTimeOffset? ApprovalTime { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public required string Status { get; set; }

        [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; } = string.Empty;

        // Navigation properties
        public Student Student { get; set; } = null!;
        public ClassSession ClassSession { get; set; } = null!;
    }
}