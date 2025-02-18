using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class Student
{
    [Key]
    [Required(ErrorMessage = "StudentID is required")]
    [MaxLength(13, ErrorMessage = "StudentID cannot exceed 13 characters")]
    public required string StudentID { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public required string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{(FirstName ?? string.Empty)} {(LastName ?? string.Empty)}".Trim();

    [Required(ErrorMessage = "Date of birth is required")]
    public DateTimeOffset DateOfBirth { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
    public required string Address { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [MaxLength(10, ErrorMessage = "Phone number cannot exceed 10 characters")]
    public required string Phone { get; set; }

    [Required(ErrorMessage = "Enrollment date is required")]
    public DateTimeOffset EnrollmentDate { get; set; }

    [Required(ErrorMessage = "Degree program is required")]
    [MaxLength(50, ErrorMessage = "Degree program cannot exceed 50 characters")]
    public required string DegreeProgram { get; set; }

    [Required(ErrorMessage = "Major is required")]
    [MaxLength(50, ErrorMessage = "Major cannot exceed 50 characters")]
    public required string Major { get; set; }

    [Required(ErrorMessage = "Enrollment status is required")]
    [MaxLength(20, ErrorMessage = "Enrollment status cannot exceed 20 characters")]
    public required EnrollmentStatus EnrollmentStatus { get; set; }

    [Required]
    public bool IsInternational { get; set; }

    // GPA as a property for immediate access in the mobile app
    [Column(TypeName = "decimal(4, 2)")]
    public decimal GPA { get; set; }


    // Navigation properties
    public ICollection<ClassEnrollment> ClassEnrollments { get; set; }
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public required FeeAccount FeeAccount { get; set; }
    public ICollection<BorrowRequest> BorrowRequests { get; set; }


    // Parameterless constructor for EF Core seeding and object initialization
    public Student()
    {
        ClassEnrollments = new HashSet<ClassEnrollment>();
        AttendanceRecords = new HashSet<AttendanceRecord>();
        Grades = new HashSet<Grade>();
        BorrowRequests = new HashSet<BorrowRequest>();
        // You can either create a default FeeAccount here or allow it to be set later
        // For seeding purposes, you might want to leave it uninitialized if it's set by your service
    }

    public Student(string studentId, string firstName, string lastName, DateTimeOffset dateOfBirth, Gender gender, string address, string email, string phone, DateTimeOffset enrollmentDate, string degreeProgram, string major, EnrollmentStatus enrollmentStatus, bool isInternational)
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

        // Automatically create a FeeAccount for the student
        FeeAccount = new FeeAccount
        {
            StudentID = StudentID,
            AcademicYear = DateTimeOffset.UtcNow.Year + "-" + (DateTimeOffset.UtcNow.Year + 1)
        };


        // Initialize collections
        ClassEnrollments = new HashSet<ClassEnrollment>();
        AttendanceRecords = new HashSet<AttendanceRecord>();
        Grades = new HashSet<Grade>();
        BorrowRequests = new HashSet<BorrowRequest>();
    }
}