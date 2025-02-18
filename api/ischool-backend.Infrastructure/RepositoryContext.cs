using System;
using ischool_backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }

    //DBSet Properties For Core Entities
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BorrowRequest> BorrowRequests { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<ClassEnrollment> Enrollments { get; set; }
    public DbSet<ClassSchedule> ClassSchedules { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    public DbSet<ClassSession> ClassSessions { get; set; }
    public DbSet<FeeAccount> FeeAccounts { get; set; }
    public DbSet<FeePayment> FeePayments { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<LecturerEvaluation> LecturerEvaluations { get; set; }
    public DbSet<LecturerEvaluationDetail> LecturerEvaluationDetails { get; set; }

}
