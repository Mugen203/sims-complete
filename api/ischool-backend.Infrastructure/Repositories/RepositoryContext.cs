using ischool_backend.Core.Entities;
using ischool_backend.Infrastructure.Configurations;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LecturerConfiguration());
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new ClassScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new ClassSessionConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new LibraryConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new FeeAccountConfiguration());
        modelBuilder.ApplyConfiguration(new FeePaymentConfiguration());
        modelBuilder.ApplyConfiguration(new BorrowRequestConfiguration());
        modelBuilder.ApplyConfiguration(new GradeConfiguration());
        modelBuilder.ApplyConfiguration(new ClassEnrollmentConfiguration());
        modelBuilder.ApplyConfiguration(new AttendanceRecordConfiguration());
    }
}