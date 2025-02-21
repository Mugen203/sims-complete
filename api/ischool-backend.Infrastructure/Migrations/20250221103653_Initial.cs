using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ischool_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CourseCategory = table.Column<int>(type: "int", nullable: false),
                    ClassLocation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LecturerID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OfficeLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Credentials = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LecturerID);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.LibraryId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EnrollmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DegreeProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnrollmentStatus = table.Column<int>(type: "int", nullable: false),
                    IsInternational = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "CourseCourse",
                columns: table => new
                {
                    DependentCoursesCourseCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PrerequisiteCoursesCourseCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourse", x => new { x.DependentCoursesCourseCode, x.PrerequisiteCoursesCourseCode });
                    table.ForeignKey(
                        name: "FK_CourseCourse_Courses_DependentCoursesCourseCode",
                        column: x => x.DependentCoursesCourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourse_Courses_PrerequisiteCoursesCourseCode",
                        column: x => x.PrerequisiteCoursesCourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    ClassLocation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassCode);
                    table.ForeignKey(
                        name: "FK_Class_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerEvaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturerId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    EvaluationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerEvaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_LecturerEvaluations_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    BookStatus = table.Column<int>(type: "int", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "LibraryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Libraries_LibraryId1",
                        column: x => x.LibraryId1,
                        principalTable: "Libraries",
                        principalColumn: "LibraryId");
                });

            migrationBuilder.CreateTable(
                name: "FeeAccounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalFeeDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFeePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeAccounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_FeeAccounts_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClassLocation = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    LecturerID = table.Column<string>(type: "nvarchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_ClassSchedules_Class_ClassCode",
                        column: x => x.ClassCode,
                        principalTable: "Class",
                        principalColumn: "ClassCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSchedules_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode");
                    table.ForeignKey(
                        name: "FK_ClassSchedules_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EnrollmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Class_ClassCode",
                        column: x => x.ClassCode,
                        principalTable: "Class",
                        principalColumn: "ClassCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode");
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerEvaluationDetails",
                columns: table => new
                {
                    EvaluationDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerEvaluationDetails", x => x.EvaluationDetailId);
                    table.ForeignKey(
                        name: "FK_LecturerEvaluationDetails_LecturerEvaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "LecturerEvaluations",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRequests",
                columns: table => new
                {
                    BorrowRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRequests", x => x.BorrowRequestId);
                    table.ForeignKey(
                        name: "FK_BorrowRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowRequests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeePayments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiptIssued = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePayments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_FeePayments_FeeAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FeeAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassSessions",
                columns: table => new
                {
                    ClassSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Topics = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LecturerNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSessions", x => x.ClassSessionId);
                    table.ForeignKey(
                        name: "FK_ClassSessions_ClassSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ClassSchedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DateAwarded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ClassEnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grades_Class_ClassCode",
                        column: x => x.ClassCode,
                        principalTable: "Class",
                        principalColumn: "ClassCode");
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_ClassEnrollmentId",
                        column: x => x.ClassEnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId");
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClassSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarkTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StudentMarked = table.Column<bool>(type: "bit", nullable: false),
                    LecturerApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AttendanceStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceRecordId);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_ClassSessions_ClassSessionId",
                        column: x => x.ClassSessionId,
                        principalTable: "ClassSessions",
                        principalColumn: "ClassSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_Class_ClassCode",
                        column: x => x.ClassCode,
                        principalTable: "Class",
                        principalColumn: "ClassCode");
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseCode", "ClassLocation", "CourseCategory", "CourseName", "Credits", "Department", "Description", "IsActive", "Level" },
                values: new object[,]
                {
                    { "ACCT210", 5, 2, "Introduction to Accounting", 3, "Accounting", "Basic accounting principles and practices.", true, 1 },
                    { "AFST205", 1, 3, "Introduction to African Music", 1, "African Studies", "Introduction to the diverse world of African music.", true, 1 },
                    { "AFST243", 1, 5, "Chieftancy and Development", 1, "African Studies", "Exploration of chieftaincy and its role in development.", true, 1 },
                    { "CMME115", 1, 3, "Introduction to Communication Skills", 2, "Communication", "Basic communication skills for effective interaction.", true, 0 },
                    { "COSC113", 1, 0, "Elements of Programming", 3, "Computer Science", "Introduction to fundamental programming concepts.", true, 0 },
                    { "COSC115", 2, 0, "Introduction to Computer Science I", 3, "Computer Science", "First course in the computer science introductory sequence.", true, 0 },
                    { "COSC116", 3, 0, "Introduction to Computer Science II", 3, "Computer Science", "Second course in the computer science introductory sequence.", true, 0 },
                    { "COSC124", 2, 5, "Procedural Programming", 3, "Computer Science", "Introduction to procedural programming paradigms.", true, 0 },
                    { "COSC130", 4, 0, "Digital Electronics", 3, "Computer Science", "Fundamentals of digital electronics.", true, 0 },
                    { "COSC214", 3, 5, "Computer Organization", 3, "Computer Science", "Fundamentals of computer organization and architecture.", true, 1 },
                    { "COSC224", 4, 5, "Object-Oriented Programming", 3, "Computer Science", "Principles and practices of object-oriented programming.", true, 1 },
                    { "COSC230", 5, 0, "Database Systems Design", 3, "Computer Science", "Principles of database systems design and implementation.", true, 1 },
                    { "COSC240", 6, 0, "Systems Programming", 3, "Computer Science", "Advanced programming concepts in system-level development.", true, 1 },
                    { "COSC245", 2, 0, "Entrepreneurship and Human Development", 1, "Computer Science", "Exploration of entrepreneurship and human development topics.", true, 1 },
                    { "COSC250", 3, 0, "Computer Ethics", 3, "Computer Science", "Ethical considerations in computing and information technology.", true, 1 },
                    { "COSC255", 4, 0, "Operating Systems", 3, "Computer Science", "Core concepts and principles of operating systems.", true, 1 },
                    { "COSC257", 3, 0, "Computer Architecture & Microprocessor System", 3, "Computer Science", "Computer architecture and microprocessor systems.", true, 1 },
                    { "COSC260", 5, 0, "System Analysis & Design", 3, "Computer Science", "Methods and techniques for system analysis and design.", true, 1 },
                    { "COSC271", 6, 0, "Data Comms & Comp Network I", 3, "Computer Science", "Introduction to data communications and computer networks.", true, 1 },
                    { "COSC272", 4, 0, "Data Comms & Comp Networks II", 3, "Computer Science", "Advanced topics in data communications and computer networks.", true, 1 },
                    { "COSC280", 2, 0, "Information Systems", 3, "Computer Science", "Overview of information systems and their applications.", true, 1 },
                    { "COSC325", 5, 0, "Computer Security", 3, "Computer Science", "Fundamentals of computer security.", true, 2 },
                    { "COSC331", 3, 0, "Computer Graphics I", 3, "Computer Science", "Introduction to computer graphics principles and techniques.", true, 2 },
                    { "COSC346", 4, 0, "Software Engineering", 3, "Computer Science", "Principles and practices of software engineering.", true, 2 },
                    { "COSC357", 5, 0, "Project Planning and Management", 3, "Computer Science", "Techniques for planning and managing software projects.", true, 2 },
                    { "COSC360", 5, 5, "Web Applications Development", 3, "Computer Science", "Development of web applications using modern technologies.", true, 2 },
                    { "COSC361", 6, 0, "Data Structures & Algorithms I", 3, "Computer Science", "Fundamental data structures and algorithms.", true, 2 },
                    { "COSC364", 2, 0, "Research Methods", 3, "Computer Science", "Introduction to research methodologies in computer science.", true, 2 },
                    { "COSC370", 3, 0, "Operations Research", 3, "Computer Science", "Application of operations research techniques to computer science problems.", true, 2 },
                    { "COSC380", 4, 0, "Compiler Design I", 3, "Computer Science", "Principles and techniques of compiler design.", true, 2 },
                    { "COSC390", 6, 5, "Internship", 3, "Computer Science", "Practical work experience through internship.", true, 2 },
                    { "COSC425", 2, 1, "Mobile Application Development", 3, "Computer Science", "Development of mobile applications for various platforms.", true, 3 },
                    { "COSC429", 2, 5, "Cloud Computing Systems", 3, "Computer Science", "Concepts and technologies of cloud computing systems.", true, 3 },
                    { "COSC430", 6, 0, "Computer Simulation and System Modeling", 3, "Computer Science", "Techniques for computer simulation and system modeling.", true, 3 },
                    { "COSC435", 3, 1, "Computer and Cyber Forensics", 3, "Computer Science", "Principles and techniques of computer and cyber forensics.", true, 3 },
                    { "COSC440", 4, 1, "Computer Vision", 3, "Computer Science", "Introduction to computer vision and image processing.", true, 3 },
                    { "COSC446", 3, 5, "Advanced Network & Systems Administration", 3, "Computer Science", "Advanced topics in network and systems administration.", true, 3 },
                    { "COSC455", 4, 5, "Artificial Intelligence & Machine Learning I", 3, "Computer Science", "Introduction to artificial intelligence and machine learning.", true, 3 },
                    { "COSC492", 4, 4, "Final Year Project II", 6, "Computer Science", "Continuation of the final year project in computer science.", true, 3 },
                    { "CSCD210", 5, 5, "Numerical Methods", 3, "Computer Science", "Numerical methods for problem-solving in computer science.", true, 1 },
                    { "CTZN001", 1, 5, "Citizenship", 0, "Citizenship", "Fundamentals of citizenship and civic responsibility.", true, 0 },
                    { "ENGL111", 1, 3, "Language and Writing Skills I", 2, "English", "First course in language and writing skills development.", true, 0 },
                    { "ENGL112", 1, 3, "Language and Writing Skills II", 2, "English", "Second course in language and writing skills development.", true, 0 },
                    { "ENGL122", 1, 3, "Language and Writing Skills II", 3, "English", "Further development of language and writing skills.", true, 0 },
                    { "FREN121", 1, 3, "French for General Communication I", 2, "French", "Introductory French for general communication.", true, 0 },
                    { "GNED125", 1, 5, "Study Skills", 0, "General Education", "Essential study skills for academic success.", true, 0 },
                    { "HLTH200", 1, 3, "Health Principles", 3, "Health", "Fundamental principles of health and wellness.", true, 1 },
                    { "MATH171", 6, 2, "Introductory Maths for Computer Science", 3, "Mathematics", "Mathematical concepts relevant to computer science.", true, 0 },
                    { "MATH172", 2, 2, "Discrete and Continuous Mathematics", 3, "Mathematics", "Discrete and continuous mathematics for computer science.", true, 0 },
                    { "MGNT255", 3, 2, "Principles of Management", 3, "Management", "Fundamental principles of management.", true, 1 },
                    { "PEAC100", 1, 3, "Physical Activity", 0, "Physical Education", "Introduction to physical activity and fitness.", true, 0 },
                    { "PHYS103", 5, 2, "Physics", 3, "Physics", "Introductory course in physics.", true, 0 },
                    { "PSYC105", 1, 3, "Introduction to Psychology", 3, "Psychology", "Basic concepts and theories of psychology.", true, 0 },
                    { "RELB163", 1, 3, "Life and Teachings of Jesus", 3, "Religion", "Study of the life and teachings of Jesus Christ.", true, 0 },
                    { "RELB250", 1, 3, "Principles of Christian Faith", 3, "Religion", "Core principles of Christian faith and theology.", true, 1 },
                    { "RELT385", 1, 3, "Introduction to Biblical Foundation Ethics", 3, "Theology", "Ethical foundations based on biblical teachings.", true, 2 },
                    { "STAT282", 4, 2, "Probability & Statistics", 3, "Statistics", "Introduction to probability and statistics.", true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LecturerID", "Credentials", "Department", "Email", "FirstName", "Gender", "HireDate", "LastName", "OfficeLocation", "Phone" },
                values: new object[] { "L123456789012", "PhD in Computer Science", "Computer Science", "pprince@example.com", "Papa", 1, new DateTimeOffset(new DateTime(2020, 2, 21, 10, 36, 52, 472, DateTimeKind.Unspecified).AddTicks(7969), new TimeSpan(0, 0, 0, 0, 0)), "Prince", "Main Building Office", "0123456789" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "LibraryId", "LibraryName", "Location" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "Main Library", "Central Campus" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Address", "DateOfBirth", "DegreeProgram", "Email", "EnrollmentDate", "EnrollmentStatus", "FirstName", "Gender", "IsInternational", "LastName", "Major", "Phone" },
                values: new object[] { "222CS01000694", "Kings and Queens Hostel, Oyibi, Ghana", new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BSc Computer Science", "radahn@example.com", new DateTimeOffset(new DateTime(2024, 2, 21, 10, 36, 52, 487, DateTimeKind.Unspecified).AddTicks(4366), new TimeSpan(0, 0, 0, 0, 0)), 2, "Kwaku", 1, false, "Affram", "Cloud Security", "0553138727" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "BookStatus", "Category", "Edition", "ISBN", "LibraryId", "LibraryId1", "Publisher", "Title" },
                values: new object[,]
                {
                    { new Guid("8e739c1c-3563-47ed-863b-e9a90af61c88"), "Jane Smith", 1, 2, null, "9780987654321", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), null, null, "Data Structures and Algorithms" },
                    { new Guid("f549e035-5bd2-487a-867d-7ea5d1fd0ebd"), "John Doe", 1, 6, null, "9781234567890", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), null, null, "Introduction to C# Programming" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassCode", "AcademicYear", "ClassLocation", "CourseCode", "LecturerID", "Semester" },
                values: new object[] { "TEST-CLASS-001", "2024-2025", 1, "COSC115", "L123456789012", 1 });

            migrationBuilder.InsertData(
                table: "FeeAccounts",
                columns: new[] { "AccountId", "AcademicYear", "Currency", "Semester", "StudentID", "TotalFeeDue", "TotalFeePaid" },
                values: new object[] { new Guid("870cd736-6042-4e98-9a11-7375208ec88b"), "2024-2025", 1, 1, "222CS01000694", 1000m, 500m });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "AcademicYear", "ClassCode", "ClassEnrollmentId", "CourseCode", "DateAwarded", "GradeValue", "Remarks", "Semester", "StudentID" },
                values: new object[] { new Guid("c619c38c-1499-4711-ac6d-6a996974b946"), "2024-2025", null, null, "COSC240", new DateTimeOffset(new DateTime(2024, 11, 21, 10, 36, 52, 493, DateTimeKind.Unspecified).AddTicks(7667), new TimeSpan(0, 0, 0, 0, 0)), 1, "Excellent performance", 1, "222CS01000694" });

            migrationBuilder.InsertData(
                table: "BorrowRequests",
                columns: new[] { "BorrowRequestId", "BookId", "BorrowDate", "IsReturned", "ReturnDate", "Status", "StudentId" },
                values: new object[,]
                {
                    { new Guid("4b7d4ee1-b6da-4fbb-afe3-60e8bd234c8a"), new Guid("8e739c1c-3563-47ed-863b-e9a90af61c88"), new DateTimeOffset(new DateTime(2025, 2, 16, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(6689), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(2025, 4, 21, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(6692), new TimeSpan(0, 0, 0, 0, 0)), 4, "222CS01000694" },
                    { new Guid("8edfe3d8-1cf3-4732-a7f9-7095f805de60"), new Guid("f549e035-5bd2-487a-867d-7ea5d1fd0ebd"), new DateTimeOffset(new DateTime(2025, 2, 11, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(5982), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(2025, 3, 21, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 0, 0, 0, 0)), 2, "222CS01000694" }
                });

            migrationBuilder.InsertData(
                table: "ClassSchedules",
                columns: new[] { "ScheduleId", "ClassCode", "ClassLocation", "CourseCode", "DayOfWeek", "EndTime", "IsBooked", "LecturerID", "StartTime" },
                values: new object[] { new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4"), "TEST-CLASS-001", 1, null, 1, new TimeSpan(0, 10, 50, 0, 0), false, null, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "AcademicYear", "ClassCode", "CourseCode", "EnrollmentDate", "Semester", "Status", "StudentId" },
                values: new object[] { new Guid("91b94042-7e61-46ba-80a2-d06d187f5c3e"), "2024-2025", "TEST-CLASS-001", null, new DateTimeOffset(new DateTime(2024, 8, 21, 10, 36, 52, 494, DateTimeKind.Unspecified).AddTicks(8977), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "222CS01000694" });

            migrationBuilder.InsertData(
                table: "FeePayments",
                columns: new[] { "PaymentID", "AcademicYear", "AccountId", "AmountPaid", "CreatedAt", "CreatedBy", "Description", "LastModifiedAt", "LastModifiedBy", "PaymentDate", "PaymentMethod", "PaymentReference", "ReceiptIssued", "ReceiptNumber", "Semester", "Status" },
                values: new object[] { new Guid("dab4fadc-acef-46e7-bc20-c5357c3d8930"), "2024-2025", new Guid("870cd736-6042-4e98-9a11-7375208ec88b"), 200.00m, new DateTimeOffset(new DateTime(2025, 2, 21, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(2897), new TimeSpan(0, 0, 0, 0, 0)), "SeedDataScript", "Semester 1 Fees - Mobile Money Payment", null, null, new DateTimeOffset(new DateTime(2025, 2, 16, 10, 36, 52, 492, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 0, 0, 0, 0)), 1, "MOMO-TRANS-12345", true, "RCPT-2024-001", 1, 2 });

            migrationBuilder.InsertData(
                table: "ClassSessions",
                columns: new[] { "ClassSessionId", "LecturerNotes", "ScheduleId", "SessionDate", "Status", "Topics" },
                values: new object[] { new Guid("837c7278-3754-4bb6-98ee-7fca53d40677"), "Please review Chapter 1 before next session", new Guid("5e5c3a7a-097d-4d3a-8629-234e03485ce4"), new DateTimeOffset(new DateTime(2025, 2, 23, 10, 36, 52, 481, DateTimeKind.Unspecified).AddTicks(9071), new TimeSpan(0, 0, 0, 0, 0)), 1, "Introduction to System Programming" });

            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "AttendanceRecordId", "ApprovalTime", "AttendanceStatus", "ClassCode", "ClassSessionId", "LecturerApproved", "MarkTime", "Notes", "StudentId", "StudentMarked" },
                values: new object[] { new Guid("b299b5cd-28e0-4694-b4b3-3ed3cd4a5f93"), new DateTimeOffset(new DateTime(2025, 2, 21, 10, 36, 52, 496, DateTimeKind.Unspecified).AddTicks(1268), new TimeSpan(0, 0, 0, 0, 0)), 1, null, new Guid("837c7278-3754-4bb6-98ee-7fca53d40677"), true, new DateTimeOffset(new DateTime(2025, 2, 20, 10, 36, 52, 496, DateTimeKind.Unspecified).AddTicks(1265), new TimeSpan(0, 0, 0, 0, 0)), "Student was present for the entire session", "222CS01000694", true });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_ClassCode",
                table: "AttendanceRecords",
                column: "ClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_ClassSessionId",
                table: "AttendanceRecords",
                column: "ClassSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_StudentId",
                table: "AttendanceRecords",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryId",
                table: "Books",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryId1",
                table: "Books",
                column: "LibraryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequests_BookId",
                table: "BorrowRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequests_StudentId",
                table: "BorrowRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseCode",
                table: "Class",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Class_LecturerID",
                table: "Class",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_ClassCode",
                table: "ClassSchedules",
                column: "ClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_CourseCode",
                table: "ClassSchedules",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedules_LecturerID",
                table: "ClassSchedules",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_ScheduleId",
                table: "ClassSessions",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourse_PrerequisiteCoursesCourseCode",
                table: "CourseCourse",
                column: "PrerequisiteCoursesCourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassCode",
                table: "Enrollments",
                column: "ClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseCode",
                table: "Enrollments",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeAccounts_StudentID",
                table: "FeeAccounts",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeePayments_AccountId",
                table: "FeePayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ClassCode",
                table: "Grades",
                column: "ClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ClassEnrollmentId",
                table: "Grades",
                column: "ClassEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseCode",
                table: "Grades",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerEvaluationDetails_EvaluationId",
                table: "LecturerEvaluationDetails",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerEvaluations_LecturerId",
                table: "LecturerEvaluations",
                column: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "BorrowRequests");

            migrationBuilder.DropTable(
                name: "CourseCourse");

            migrationBuilder.DropTable(
                name: "FeePayments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "LecturerEvaluationDetails");

            migrationBuilder.DropTable(
                name: "ClassSessions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "FeeAccounts");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "LecturerEvaluations");

            migrationBuilder.DropTable(
                name: "ClassSchedules");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lecturers");
        }
    }
}
