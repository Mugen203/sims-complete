using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
///     Represents a lecturer or instructor in the institution.
///     Lecturers are responsible for teaching classes and conducting evaluations.
/// </summary>
public class Lecturer
{
    #region Constructors

    /// <summary>
    ///     Parameterless constructor for Entity Framework Core.
    ///     Required for EF Core to create proxies and for database operations like seeding.
    /// </summary>
    public Lecturer()
    {
        // Initialize navigation collections to prevent null reference exceptions and for consistent object state.
        ClassSchedules = new HashSet<ClassSchedule>();
        Evaluations = new HashSet<LecturerEvaluation>();
        // Removed ClassEnrollments navigation property based on our discussion, as enrollments are related to Classes, not directly to Lecturers.
        // ClassEnrollments = new HashSet<ClassEnrollment>();
    }

    /// <summary>
    ///     Parameterized constructor to create a new Lecturer instance with essential details.
    /// </summary>
    /// <param name="lecturerId">Unique identifier for the lecturer.</param>
    /// <param name="firstName">Lecturer's first name.</param>
    /// <param name="lastName">Lecturer's last name.</param>
    /// <param name="email">Lecturer's email address.</param>
    /// <param name="phone">Lecturer's phone number.</param>
    /// <param name="department">Department the lecturer belongs to.</param>
    /// <param name="hireDate">Date when the lecturer was hired.</param>
    /// <param name="officeLocation">Lecturer's office location.</param>
    /// <param name="credentials">Lecturer's professional credentials or qualifications.</param>
    /// <param name="gender">Lecturer's gender (optional).</param>
    public Lecturer(string lecturerId, string firstName, string lastName, string email, string phone,
        string department, DateTimeOffset hireDate, string officeLocation, string credentials, Gender? gender)
    {
        LecturerID = lecturerId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Department = department;
        HireDate = hireDate;
        OfficeLocation = officeLocation;
        Credentials = credentials;
        Gender = gender;

        // Initialize navigation collections (even in parameterized constructor for consistency)
        ClassSchedules = new HashSet<ClassSchedule>();
        Evaluations = new HashSet<LecturerEvaluation>();
        // Removed ClassEnrollments initialization here as well
        // ClassEnrollments = new HashSet<ClassEnrollment>();
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Unique identifier for the lecturer.
    ///     Serves as the primary key for the Lecturer entity.
    /// </summary>
    [Key]
    [Required(ErrorMessage = "LecturerID is required")]
    [MaxLength(13, ErrorMessage = "LecturerID cannot exceed 13 characters")]
    public required string LecturerID { get; set; }

    /// <summary>
    ///     Lecturer's first name.
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public required string FirstName { get; set; }

    /// <summary>
    ///     Lecturer's last name.
    /// </summary>
    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public required string LastName { get; set; }

    /// <summary>
    ///     Calculated property to get the lecturer's full name.
    ///     Not mapped to the database as it's derived from FirstName and LastName.
    ///     Handles potential null values for FirstName or LastName gracefully.
    /// </summary>
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}".Trim(); // Null-safe FullName calculation

    /// <summary>
    ///     Lecturer's email address.
    ///     Validated to ensure it's a properly formatted email.
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
    public required string Email { get; set; }

    /// <summary>
    ///     Lecturer's phone number.
    ///     Stored as string to accommodate different phone number formats.
    /// </summary>
    [Required(ErrorMessage = "Phone number is required")]
    [MaxLength(20,
        ErrorMessage = "Phone number cannot exceed 20 characters")] // Increased maxLength to 20 for flexibility
    public required string Phone { get; set; } // Stored as string for format flexibility

    /// <summary>
    ///     Department to which the lecturer belongs.
    ///     Example: "Computer Science Department", "Mathematics Department".
    /// </summary>
    [Required(ErrorMessage = "Department is required")]
    [MaxLength(50, ErrorMessage = "Department cannot exceed 50 characters")]
    public required string Department { get; set; }

    /// <summary>
    ///     Date when the lecturer was hired by the institution.
    /// </summary>
    [Required(ErrorMessage = "Hire date is required")]
    public DateTimeOffset HireDate { get; set; }

    /// <summary>
    ///     Lecturer's office location within the institution.
    ///     Example: "Room 302, Science Building", "Online Office Hours".
    /// </summary>
    [Required(ErrorMessage = "Office location is required")]
    [MaxLength(50, ErrorMessage = "Office location cannot exceed 50 characters")]
    public required string OfficeLocation { get; set; }

    /// <summary>
    ///     Lecturer's professional credentials or qualifications.
    ///     Example: "Ph.D. in Computer Science", "MSc in Mathematics, Certified Teacher".
    /// </summary>
    [MaxLength(200, ErrorMessage = "Credentials cannot exceed 200 characters")]
    public required string Credentials { get; set; } // Made 'required' as credentials are usually essential

    /// <summary>
    ///     Lecturer's gender.
    ///     Uses the Gender enum for predefined gender options.
    ///     Nullable, indicating gender is optional information.
    /// </summary>
    [EnumDataType(typeof(Gender))]
    public Gender? Gender { get; set; } // Made Gender nullable to indicate it's optional

    #endregion

    #region Navigation Properties

    /// <summary>
    ///     Navigation property for ClassSchedules.
    ///     Represents the classes scheduled and taught by this lecturer.
    ///     Defines a one-to-many relationship between Lecturer and ClassSchedule.
    /// </summary>
    public ICollection<ClassSchedule> ClassSchedules { get; set; }

    /// <summary>
    ///     Navigation property for Evaluations.
    ///     Represents the lecturer evaluations conducted for this lecturer.
    ///     Defines a one-to-many relationship between Lecturer and LecturerEvaluation.
    /// </summary>
    public ICollection<LecturerEvaluation> Evaluations { get; set; }

    #endregion
}