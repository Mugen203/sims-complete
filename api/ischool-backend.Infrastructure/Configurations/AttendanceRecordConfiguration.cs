using ischool_backend.Core.Entities;
using ischool_backend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ischool_backend.Infrastructure.Configurations;

public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
{
    public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
    {
        // Configure the relationships (eager loading - optional for seed data, more relevant for querying)
        builder.Navigation(a => a.Student).AutoInclude();
        builder.Navigation(a => a.ClassSession).AutoInclude();

        // Configure required properties (already defined in entity, likely redundant here but doesn't hurt)
        builder.Property(a => a.StudentId).IsRequired();
        builder.Property(a => a.ClassSessionId).IsRequired();

        const string studentIdForAttendance = "222CS01000694";
        var classSessionIdForAttendance = new Guid("837c7278-3754-4bb6-98ee-7fca53d40677");


        // Seed data using ANONYMOUS OBJECT and setting ONLY FOREIGN KEY PROPERTIES
        builder.HasData(
            new
            {
                AttendanceRecordId = Guid.NewGuid(), // Generate Guid for AttendanceRecordId
                StudentId = studentIdForAttendance, // **Directly set StudentId (FK)**
                ClassSessionId = classSessionIdForAttendance, // **Directly set ClassSessionId (FK)**
                MarkTime = DateTimeOffset.UtcNow.AddDays(-1),
                AttendanceStatus = AttendanceStatus.Present,
                StudentMarked = true,
                LecturerApproved = true,
                ApprovalTime = DateTimeOffset.UtcNow,
                Notes = "Student was present for the entire session"
                // **DO NOT set navigation properties Student or ClassSession here!**
            }
        );
    }
}