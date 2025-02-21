using System.ComponentModel.DataAnnotations;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
///     Represents a course offered by the institution.
///     Courses define the curriculum and are the basis for classes and enrollments.
/// </summary>
public class Course
{
    #region Constructors

    /// <summary>
    ///     Parameterless constructor for Entity Framework Core.
    ///     Required for EF Core to create proxies and for database seeding.
    /// </summary>
    public Course()
    {
        // Initialize navigation collections to prevent null reference exceptions when EF Core is used.
        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        Grades = new HashSet<Grade>();
    }

    /// <summary>
    ///     Parameterized constructor to create a new Course instance with essential details.
    /// </summary>
    /// <param name="courseCode">Unique code to identify the course (e.g., "CS101").</param>
    /// <param name="courseName">Full name of the course (e.g., "Introduction to Computer Science").</param>
    /// <param name="credits">Number of credits the course is worth.</param>
    /// <param name="department">Department offering the course (e.g., "Computer Science Department").</param>
    /// <param name="description">Brief description of the course content.</param>
    /// <param name="level">Course level (e.g., "Undergraduate", "Graduate").</param>
    /// <param name="courseCategory">Category of the course (e.g., "Core", "Elective").</param>
    /// <param name="classLocation">Typical location where classes for this course are held (e.g., "Lecture Hall", "Online").</param>
    public Course(string courseCode, string courseName, int credits, string department, string description,
        Level level, CourseCategory courseCategory, ClassLocation classLocation)
    {
        CourseCode = courseCode;
        CourseName = courseName;
        Credits = credits;
        Department = department;
        Description = description;
        Level = level;
        CourseCategory = courseCategory;
        ClassLocation = classLocation;

        // Initialize navigation collections (even in parameterized constructor for consistency)
        ClassSchedules = new HashSet<ClassSchedule>();
        ClassEnrollments = new HashSet<ClassEnrollment>();
        Grades = new HashSet<Grade>();
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Unique code to identify the course.
    ///     Serves as the primary key for the Course entity.
    ///     Example: "CS101", "MATH201".
    /// </summary>
    [Key]
    [Required(ErrorMessage = "Course code is required")]
    [MaxLength(10,
        ErrorMessage = "Course code cannot exceed 10 characters")] // Increased maxLength to 10 for more flexibility
    public required string CourseCode { get; set; }

    /// <summary>
    ///     Full name of the course.
    ///     Example: "Introduction to Programming", "Calculus I".
    /// </summary>
    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
    public required string CourseName { get; set; }

    /// <summary>
    ///     Number of credits awarded upon successful completion of the course.
    ///     Typically ranges from 1 to 6, representing the course workload.
    /// </summary>
    [Required(ErrorMessage = "Credits are required")]
    [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6")]
    public int Credits { get; set; }

    /// <summary>
    ///     Academic department or faculty offering the course.
    ///     Example: "Computer Science Department", "Faculty of Engineering".
    /// </summary>
    [Required(ErrorMessage = "Department is required")]
    [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters")]
    public required string Department { get; set; }

    /// <summary>
    ///     Detailed description of the course content, learning objectives, and prerequisites.
    ///     Useful for course catalogs and student information.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public required string Description { get; set; }

    /// <summary>
    ///     Indicates whether the course is currently active and offered to students.
    ///     Defaults to true when a new Course is created. Can be used for course lifecycle management.
    /// </summary>
    [Required]
    public bool IsActive { get; set; } = true; // Default to active

    /// <summary>
    ///     Academic level of the course (e.g., Undergraduate, Graduate, Introductory, Advanced).
    ///     Uses the Level enum to represent predefined course levels.
    /// </summary>
    [Required(ErrorMessage = "Level is required")]
    [EnumDataType(typeof(Level))]
    public Level Level { get; set; }

    /// <summary>
    ///     Category or type of the course (e.g., Core, Elective, General Education, Major Specific).
    ///     Uses the CourseCategory enum for predefined course categories.
    /// </summary>
    [Required(ErrorMessage = "Course category is required")]
    [EnumDataType(typeof(CourseCategory))]
    public CourseCategory CourseCategory { get; set; }

    /// <summary>
    ///     Typical or default location where classes for this course are conducted (e.g., "Lecture Hall", "Online",
    ///     "Laboratory").
    ///     Uses the ClassLocation enum to represent predefined locations.
    ///     Note: Actual class schedules might vary from this default location.
    /// </summary>
    [Required(ErrorMessage = "Class location is required")]
    [EnumDataType(typeof(ClassLocation))]
    public ClassLocation ClassLocation { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    ///     Navigation property for ClassSchedules.
    ///     Represents the schedule of classes offered for this course.
    ///     Defines a one-to-many relationship between Course and ClassSchedule.
    /// </summary>
    public ICollection<ClassSchedule> ClassSchedules { get; set; }

    /// <summary>
    ///     Navigation property for ClassEnrollments.
    ///     Represents the enrollments of students in classes of this course.
    ///     Defines a one-to-many relationship between Course and ClassEnrollment.
    /// </summary>
    public ICollection<ClassEnrollment> ClassEnrollments { get; set; }

    /// <summary>
    ///     Navigation property for Grades.
    ///     Represents the grades awarded to students in this course.
    ///     Defines a one-to-many relationship between Course and Grade.
    /// </summary>
    public ICollection<Grade> Grades { get; set; }

    /// <summary>
    ///     Navigation property for PrerequisiteCourses.
    ///     Represents the courses that are prerequisites for this course.
    ///     Defines a many-to-many relationship between Course and itself (self-referencing).
    /// </summary>
    public ICollection<Course> PrerequisiteCourses { get; set; }

    /// <summary>
    ///     Navigation property for DependentCourses.
    ///     Represents the courses for which this course is a prerequisite.
    ///     This is the inverse navigation property for PrerequisiteCourses, completing the many-to-many relationship.
    /// </summary>
    public ICollection<Course> DependentCourses { get; set; }

    #endregion
}