using System;

namespace ischool_backend.Core.Entities;

public class Student
{
    public Guid Id { get; set; }

    public required string StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required DateTime EnrollmentDate { get; set; }
    public required string Address { get; set; }
    public required string Department { get; set; }
    public decimal GPA { get; set; }

    //TODO: Navigation properties
}
