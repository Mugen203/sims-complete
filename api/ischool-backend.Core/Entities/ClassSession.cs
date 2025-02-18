using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class ClassSession
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ClassSessionId { get; set; }

    [Required]
    public Guid ScheduleId { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    [Required]
    public ClassLocation ClassLocation { get; set; }

    [Required]
    public DateTimeOffset SessionDate { get; set; }

    [Required(ErrorMessage = "Topics is required")]
    [MaxLength(500, ErrorMessage = "Topics cannot exceed 500 characters")]
    public required string Topics { get; set; }

    [MaxLength(1000, ErrorMessage = "LecturerNotes cannot exceed 1000 characters")]
    public string? LecturerNotes { get; set; } // Nullable to allow cases where no notes are provided

    [Required]
    [EnumDataType(typeof(ClassSessionStatus))]
    public ClassSessionStatus Status { get; set; } = ClassSessionStatus.Scheduled;

    //Navigation properties
    [ForeignKey(nameof(ScheduleId))]
    public required ClassSchedule Schedule { get; set; }

}
