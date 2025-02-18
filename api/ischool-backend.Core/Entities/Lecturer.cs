using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class Lecturer
{
    [Key]
    [Required(ErrorMessage = "LecturerID is required")]
    [MaxLength(13, ErrorMessage = "LecturerID cannot exceed 13 characters")]
    public required string LecturerID { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public required string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{(FirstName ?? string.Empty)} {(LastName ?? string.Empty)}".Trim();

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [MaxLength(10, ErrorMessage = "Phone number cannot exceed 10 characters")]
    public required string Phone { get; set; }

    [Required(ErrorMessage = "Department is required")]
    [MaxLength(50, ErrorMessage = "Department cannot exceed 50 characters")]
    public required string Department { get; set; }

    [Required(ErrorMessage = "Hire date is required")]
    public DateTimeOffset HireDate { get; set; }

    [Required(ErrorMessage = "Office location is required")]
    [MaxLength(50, ErrorMessage = "Office location cannot exceed 50 characters")]
    public required string OfficeLocation { get; set; }

    [MaxLength(200, ErrorMessage = "Credentials cannot exceed 200 characters")]
    public required string Credentials { get; set; }

    // Optional: Keep gender if you need it for your application logic, though it's not in the schema
    [EnumDataType(typeof(Gender))]
    public Gender? Gender { get; set; }

    // Navigation properties
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; }
    public virtual ICollection<LecturerEvaluation> Evaluations { get; set; }

    public Lecturer()
    {
        // Initialize collections to prevent null reference exceptions
        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        Evaluations = new HashSet<LecturerEvaluation>();
    }
}