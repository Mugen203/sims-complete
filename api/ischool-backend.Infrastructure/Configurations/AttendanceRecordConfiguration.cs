using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
{
    public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
    {
        var studentIdForAttendance = "222CS01000694";
        var classSessionIdForAttendance = new Guid("837c7278-3754-4bb6-98ee-7fca53d40677");

        builder.HasData(
            new AttendanceRecord
            {
                AttendanceRecordId = Guid.NewGuid(), // Generate Guid for AttendanceRecordId
                StudentId = studentIdForAttendance, // Reference existing StudentId
                ClassSessionId = classSessionIdForAttendance, // Reference existing ClassSessionId
                MarkTime = DateTimeOffset.UtcNow.AddDays(-1), // Example MarkTime
                AttendanceStatus = AttendanceStatus.Present, // Example AttendanceStatus
                StudentMarked = true,
                LecturerApproved = true,
                ApprovalTime = DateTimeOffset.UtcNow,
                Notes = "Student was present for the entire session",
                Student = new Student // Inline Student stub (full properties again)
                {
                    StudentID = studentIdForAttendance,
                    FirstName = "Kwaku",
                    LastName = "Affram",
                    DateOfBirth = new DateTimeOffset(new DateTime(2000, 1, 1)),
                    Gender = Gender.Male,
                    Address = "Kings and Queens Hostel, Oyibi, Ghana",
                    Email = "radahn@example.com",
                    Phone = "0553138727",
                    EnrollmentDate = DateTimeOffset.UtcNow.AddYears(-1),
                    DegreeProgram = "BSc Computer Science",
                    Major = "Cloud Security",
                    EnrollmentStatus = EnrollmentStatus.Active,
                    IsInternational = false,
                },
                ClassSession = new ClassSession // Inline ClassSession stub (nested entities again)
                {
                    ClassSessionId = classSessionIdForAttendance, // Reference same ClassSessionId
                    ScheduleId = new Guid("/* Paste ScheduleId from ClassScheduleConfiguration.cs here */"), // **REPLACE with ACTUAL ScheduleId - same as in ClassSessionConfig**
                    SessionDate = DateTimeOffset.UtcNow.AddDays(2), // Example SessionDate - can be different from ClassSessionConfig if needed
                    Topics = "Introduction to System Programming", // Replicate Topics
                    Status = ClassSessionStatus.Scheduled, // Replicate Status
                    Schedule = new ClassSchedule // Nested inline ClassSchedule (full properties again)
                    {
                        ScheduleId = new Guid("/* Paste ScheduleId from ClassScheduleConfiguration.cs here */"), // **REPLACE with ACTUAL ScheduleId - same as above**
                        ClassCode = "TEST-CLASS-001", // Replicate ClassCode from ClassSchedule seed data
                        ClassLocation = ClassLocation.AmericanHigh,
                        StartTime = new TimeSpan(9, 0, 0), // Example StartTime
                        EndTime = new TimeSpan(10, 50, 0), // Example EndTime
                        DayOfWeek = DayOfWeek.Monday,
                        Class = new Class // Double-nested inline Class (full properties again)
                        {
                            ClassCode = "TEST-CLASS-001", // Replicate ClassCode from Class seed data
                            CourseCode = "COSC115", // Replicate CourseCode from Class seed data
                            LecturerID = "L123456789012", // Replicate LecturerID from Class seed data
                            Semester = Semester.September,
                            AcademicYear = "2024-2025",
                            ClassLocation = ClassLocation.AmericanHigh,
                            Course = new Course // Triple-nested inline Course (full properties again)
                            {
                                CourseCode = "COSC115",
                                CourseName = "Elements of Programming",
                                CourseCategory = CourseCategory.CoreComputerScience,
                                Credits = 3,
                                Department = "Computer Science",
                                Description = "Introductory Course for Computer Science Students",
                            },
                            Lecturer = new Lecturer // Triple-nested inline Lecturer (full properties again)
                            {
                                LecturerID = "L123456789012",
                                FirstName = "Michael",
                                LastName = "Asare",
                                Email = "masare@example.com",
                                Phone = "0213456789",
                                Department = "Computer Science",
                                HireDate = DateTimeOffset.UtcNow.AddYears(-5),
                                OfficeLocation = "Main Building Office",
                                Credentials = "Masters in Computer Science",
                                Gender = Gender.Male
                            }
                        }
                    }
                }
            }
        );
    }
}