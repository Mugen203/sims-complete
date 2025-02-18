﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ischool_backend.Infrastructure;

#nullable disable

namespace ischool_backend.Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ischool_backend.Core.Entities.AttendanceRecord", b =>
                {
                    b.Property<Guid>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ApprovalTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ClassSessionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LecturerApproved")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("MarkTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("StudentMarked")
                        .HasColumnType("bit");

                    b.HasKey("AttendanceID");

                    b.HasIndex("ClassSessionID");

                    b.HasIndex("StudentID");

                    b.ToTable("AttendanceRecords");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Book", b =>
                {
                    b.Property<Guid>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("BookStatus")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Edition")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Publisher")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.BorrowRequest", b =>
                {
                    b.Property<Guid>("BorrowRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookStatus")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("BorrowDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ReturnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("BorrowRequestId");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("BorrowRequests");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassEnrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EnrollmentId");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTimeOffset>("EnrollmentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LecturerId")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LecturerId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassSchedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassLocation")
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("LecturerID")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ScheduleId");

                    b.HasIndex("CourseCode");

                    b.HasIndex("LecturerID");

                    b.ToTable("ClassSchedules");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassSession", b =>
                {
                    b.Property<Guid>("ClassSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassLocation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("LecturerNotes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("SessionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Topics")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ClassSessionId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ClassSessions");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ClassLocation")
                        .HasColumnType("int");

                    b.Property<int>("CourseCategory")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("CourseCode");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.FeeAccount", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<decimal>("TotalFeeDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalFeePaid")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AccountId");

                    b.HasIndex("StudentID")
                        .IsUnique();

                    b.ToTable("FeeAccounts");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.FeePayment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("LastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("PaymentReference")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ReceiptIssued")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiptNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("AccountId");

                    b.ToTable("FeePayments");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Grade", b =>
                {
                    b.Property<Guid>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ClassEnrollmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateAwarded")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("GradeValue")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("GradeID");

                    b.HasIndex("ClassEnrollmentId");

                    b.HasIndex("CourseCode");

                    b.HasIndex("StudentID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Lecturer", b =>
                {
                    b.Property<string>("LecturerID")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Credentials")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("HireDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OfficeLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("LecturerID");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.LecturerEvaluation", b =>
                {
                    b.Property<Guid>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTimeOffset>("EvaluationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LecturerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("EvaluationId");

                    b.HasIndex("LecturerID");

                    b.ToTable("LecturerEvaluations");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.LecturerEvaluationDetail", b =>
                {
                    b.Property<Guid>("EvaluationDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<Guid>("EvaluationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("EvaluationDetailId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("LecturerEvaluationDetails");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Library", b =>
                {
                    b.Property<Guid>("LibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LibraryId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DegreeProgram")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("EnrollmentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EnrollmentStatus")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("GPA")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsInternational")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.AttendanceRecord", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.ClassSession", "ClassSession")
                        .WithMany()
                        .HasForeignKey("ClassSessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Student", "Student")
                        .WithMany("AttendanceRecords")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSession");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.BorrowRequest", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Student", "Student")
                        .WithMany("BorrowRequests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassEnrollment", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.Course", "Course")
                        .WithMany("ClassEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Lecturer", "Lecturer")
                        .WithMany("ClassEnrollments")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Student", "Student")
                        .WithMany("ClassEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassSchedule", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.Course", "Course")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Lecturer", "Lecturer")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassSession", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.ClassSchedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.FeeAccount", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.Student", "Student")
                        .WithOne("FeeAccount")
                        .HasForeignKey("ischool_backend.Core.Entities.FeeAccount", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.FeePayment", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.FeeAccount", "FeeAccount")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeeAccount");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Grade", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.ClassEnrollment", null)
                        .WithMany("Grades")
                        .HasForeignKey("ClassEnrollmentId");

                    b.HasOne("ischool_backend.Core.Entities.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ischool_backend.Core.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.LecturerEvaluation", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.Lecturer", "Lecturer")
                        .WithMany("Evaluations")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.LecturerEvaluationDetail", b =>
                {
                    b.HasOne("ischool_backend.Core.Entities.LecturerEvaluation", "LecturerEvaluation")
                        .WithMany("EvaluationDetails")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LecturerEvaluation");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.ClassEnrollment", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Course", b =>
                {
                    b.Navigation("ClassEnrollments");

                    b.Navigation("ClassSchedules");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Lecturer", b =>
                {
                    b.Navigation("ClassEnrollments");

                    b.Navigation("ClassSchedules");

                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.LecturerEvaluation", b =>
                {
                    b.Navigation("EvaluationDetails");
                });

            modelBuilder.Entity("ischool_backend.Core.Entities.Student", b =>
                {
                    b.Navigation("AttendanceRecords");

                    b.Navigation("BorrowRequests");

                    b.Navigation("ClassEnrollments");

                    b.Navigation("FeeAccount")
                        .IsRequired();

                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
