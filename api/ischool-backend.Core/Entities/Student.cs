using System;

namespace ischool_backend.Core.Entities;

public class Student
{
    public Guid Id { get; set; }

    public string StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Address { get; set; }
    public string Department { get; set; }
    public decimal GPA { get; set; }

    //TODO: Navigation properties
}
