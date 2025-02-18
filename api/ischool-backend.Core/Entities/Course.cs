using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class Course
{
    [Key]
    [Required(ErrorMessage = "Course code is required")]
    [MaxLength(10, ErrorMessage = "Course code cannot exceed 10 characters")]
    public required string CourseCode { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
    public required string CourseName { get; set; }

    [Required(ErrorMessage = "Credits are required")]
    [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6")]
    public int Credits { get; set; }

    [Required(ErrorMessage = "Department is required")]
    [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters")]
    public required string Department { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public required string Description { get; set; }

    [Required]
    public bool IsActive { get; set; } = true; // Default to active

    [Required(ErrorMessage = "Level is required")]
    [EnumDataType(typeof(Level))]
    public Level Level { get; set; }

    [Required(ErrorMessage = "Course category is required")]
    [EnumDataType(typeof(CourseCategory))]
    public CourseCategory CourseCategory { get; set; }

    [Required(ErrorMessage = "Class location is required")]
    [EnumDataType(typeof(ClassLocation))]
    public ClassLocation ClassLocation { get; set; }

    // Navigation properties
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }

    public Course()
    {
        // Initialize collections to prevent null reference exceptions
        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        Grades = new HashSet<Grade>();
    }
}