using System;
using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
                new Course
                {
                    CourseCode = "COSC113",
                    CourseName = "Elements of Programming",
                    Credits = 3,
                    Department = "Computer Science",
                    Description = "Introduction to programming concepts and techniques.",
                    IsActive = true,
                    Level = Level.Level100,
                    CourseCategory = CourseCategory.CoreComputerScience,
                    ClassLocation = ClassLocation.AmericanHigh
                },
                new Course
                {
                    CourseCode = "COSC115",
                    CourseName = "Introduction to Computer Science I",
                    Credits = 3,
                    Department = "Computer Science",
                    Description = "Foundational course covering the basics of computer science.",
                    IsActive = true,
                    Level = Level.Level100,
                    CourseCategory = CourseCategory.CoreComputerScience,
                    ClassLocation = ClassLocation.CS1
                }
            );
    }
}
