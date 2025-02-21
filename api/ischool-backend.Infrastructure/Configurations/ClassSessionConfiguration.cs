using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ischool_backend.Core.Enums;
using System;

namespace ischool_backend.Infrastructure.Configurations;

public class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
{
    public void Configure(EntityTypeBuilder<ClassSession> builder)
    {
        // **IMPORTANT**: Use existing ScheduleId from your ClassScheduleConfiguration seed data!
        var scheduleIdForSession = new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4"); 
        
        builder.HasData(
            new ClassSession
            {
                ClassSessionId = new Guid("837c7278-3754-4bb6-98ee-7fca53d40677"),
                ScheduleId = scheduleIdForSession, // Reference existing ScheduleId
                SessionDate = DateTimeOffset.UtcNow.AddDays(2), // Example SessionDate
                Topics = "Introduction to System Programming",
                LecturerNotes = "Please review Chapter 1 before next session",
                Status = ClassSessionStatus.Scheduled,
                Schedule = new ClassSchedule 
                {
                    ScheduleId = scheduleIdForSession, // Reference the same ScheduleId
                    ClassCode = "TEST-CLASS-001", // Replicate ClassCode from ClassSchedule seed data
                    ClassLocation = ClassLocation.AmericanHigh,
                    StartTime = new TimeSpan(9, 0, 0), // Example StartTime (9:00 AM)
                    EndTime = new TimeSpan(10, 50, 0), // Example EndTime (10:50 AM)
                    DayOfWeek = DayOfWeek.Monday,
                    Class = new Class // Nested inline Class stub (full properties again)
                    {
                        ClassCode = "TEST-CLASS-001", // Replicate ClassCode from Class seed data
                        CourseCode = "COSC115", // Replicate CourseCode from Class seed data
                        LecturerID = "L123456789012", // Replicate LecturerID from Class seed data
                        Semester = Semester.September,
                        AcademicYear = "2024-2025",
                        ClassLocation = ClassLocation.AmericanHigh,
                        Course = new Course // Double-nested inline Course (full properties again)
                        {
                            CourseCode = "COSC115",
                            CourseName = "Elements of Programming",
                            CourseCategory = CourseCategory.CoreComputerScience,
                            Credits = 3,
                            Department = "Computer Science",
                            Description = "Introductory Course for Computer Science Students",
                        },
                        Lecturer = new Lecturer // Double-nested inline Lecturer (full properties again)
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
        );
    }
}