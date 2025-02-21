using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a student enrolled in the educational institution.
/// Stores personal details, enrollment information, and navigation properties to related entities like enrollments, grades, and fee accounts.
/// </summary>
public class Student
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and perform database operations.
    /// Also used for object initialization in various scenarios.
    /// Initializes navigation collections to prevent null reference exceptions.
    /// </summary>
    public Student()
    {
        ClassEnrollments = new HashSet<ClassEnrollment>();
        AttendanceRecords = new HashSet<AttendanceRecord>();
        Grades = new HashSet<Grade>();
        BorrowRequests = new HashSet<BorrowRequest>();
    }

    /// <summary>
    /// Parameterized constructor to create a new Student instance with essential details.
    /// Initializes basic student information, related FeeAccount, and navigation collections.
    /// </summary>
    /// <param name="studentId">Unique identifier for the student.</param>
    /// <param name="firstName">Student's first name.</param>
    /// <param name="lastName">Student's last name.</param>
    /// <param name="dateOfBirth">Student's date of birth.</param>
    /// <param name="gender">Student's gender.</param>
    /// <param name="address">Student's address.</param>
    /// <param name="email">Student's email address.</param>
    /// <param name="phone">Student's phone number.</param>
    /// <param name="enrollmentDate">Date when the student enrolled.</param>
    /// <param name="degreeProgram">Student's degree program (e.g., Bachelor of Science in Computer Science).</param>
    /// <param name="major">Student's major (e.g., Computer Science, Biology).</param>
    /// <param name="enrollmentStatus">Student's current enrollment status (e.g., Active, Inactive).</param>
    /// <param name="isInternational">Indicates if the student is an international student.</param>
    public Student(string studentId, string firstName, string lastName, DateTimeOffset dateOfBirth, Gender gender,
        string address, string email, string phone, DateTimeOffset enrollmentDate, string degreeProgram, string major,
        EnrollmentStatus enrollmentStatus, bool isInternational) : this() // Call parameterless constructor
    {
        StudentID = studentId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Address = address;
        Email = email;
        Phone = phone;
        EnrollmentDate = enrollmentDate;
        DegreeProgram = degreeProgram;
        Major = major;
        EnrollmentStatus = enrollmentStatus;
        IsInternational = isInternational;
        
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the student.
    /// Serves as the primary key for the Student entity.
    /// </summary>
    [Key]
    [Required(ErrorMessage = "StudentID is required")]
    [MaxLength(13, ErrorMessage = "StudentID cannot exceed 13 characters")]
    public required string StudentID { get; set; }

    /// <summary>
    /// Student's first name.
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Student's last name.
    /// </summary>
    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public required string LastName { get; set; }

    /// <summary>
    /// Calculated property to get the student's full name.
    /// Not mapped to the database as it's derived from FirstName and LastName.
    /// </summary>
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>
    /// Student's date of birth.
    /// </summary>
    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTimeOffset DateOfBirth { get; set; }

    /// <summary>
    /// Student's gender.
    /// Uses the Gender enum for a predefined set of gender options.
    /// </summary>
    [Required(ErrorMessage = "Gender is required")]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    /// <summary>
    /// Student's address.
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
    public required string Address { get; set; }

    /// <summary>
    /// Student's email address.
    /// Validated to ensure it's a properly formatted email.
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
    public required string Email { get; set; }

    /// <summary>
    /// Student's phone number.
    /// Stored as string to accommodate different phone number formats.
    /// </summary>
    [Required(ErrorMessage = "Phone number is required")]
    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    public required string Phone { get; set; } // Stored as string for format flexibility

    /// <summary>
    /// Date when the student officially enrolled in the institution.
    /// </summary>
    [Required(ErrorMessage = "Enrollment date is required")]
    [DataType(DataType.Date)]
    public DateTimeOffset EnrollmentDate { get; set; }

    /// <summary>
    /// Degree program the student is enrolled in (e.g., "Bachelor of Science").
    /// </summary>
    [Required(ErrorMessage = "Degree program is required")]
    [MaxLength(100, ErrorMessage = "Degree program cannot exceed 100 characters")]
    public required string DegreeProgram { get; set; }

    /// <summary>
    /// Student's major within their degree program (e.g., "Computer Science").
    /// </summary>
    [Required(ErrorMessage = "Major is required")]
    [MaxLength(100, ErrorMessage = "Major cannot exceed 100 characters")]
    public required string Major { get; set; }

    /// <summary>
    /// Current enrollment status of the student (e.g., "Active", "Inactive", "Suspended").
    /// Uses the EnrollmentStatus enum for predefined status values.
    /// </summary>
    [Required(ErrorMessage = "Enrollment status is required")]
    [EnumDataType(typeof(EnrollmentStatus))]
    public required EnrollmentStatus EnrollmentStatus { get; set; }

    /// <summary>
    /// Indicates whether the student is an international student.
    /// </summary>
    [Required]
    public bool IsInternational { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property for ClassEnrollments.
    /// Represents the classes this student is enrolled in.
    /// Defines a one-to-many relationship between Student and ClassEnrollment.
    /// </summary>
    public ICollection<ClassEnrollment> ClassEnrollments { get; set; }

    /// <summary>
    /// Navigation property for AttendanceRecords.
    /// Represents the attendance records for this student across various class sessions.
    /// Defines a one-to-many relationship between Student and AttendanceRecord.
    /// </summary>
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

    /// <summary>
    /// Navigation property for Grades.
    /// Represents the grades this student has received in various classes.
    /// Defines a one-to-many relationship between Student and Grade.
    /// </summary>
    public ICollection<Grade> Grades { get; set; }

    /// <summary>
    /// Navigation property for FeeAccount.
    /// Represents the fee account associated with this student.
    /// Defines a one-to-one relationship between Student and FeeAccount.
    /// </summary>
    public required FeeAccount FeeAccount { get; set; } // FeeAccount is required for every student

    /// <summary>
    /// Navigation property for BorrowRequests.
    /// Represents the library borrow requests made by this student.
    /// Defines a one-to-many relationship between Student and BorrowRequest.
    /// </summary>
    public ICollection<BorrowRequest> BorrowRequests { get; set; }

    #endregion
}