using ischool_backend.Common.Interfaces;
using ischool_backend.Common.Models;
using ischool_backend.Common.Utils;
using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using ischool_backend.Core.Interfaces.Service;
using ischool_backend.Core.Mappers;


namespace ischool_backend.Services;

internal sealed class StudentService : IStudentService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public StudentService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Student?> GetStudentProfileAsync(string studentId, bool trackChanges)
    {
        // Log information for debugging or auditing
        _logger.LogInfo($"Attempting to retrieve profile for student with ID: {studentId}");

        // Access the Student repository through the repository manager
        var student = await _repository.StudentRepository.GetStudentByIdAsync(studentId, trackChanges);

        if (student is null)
        {
            _logger.LogWarn($"Student with ID: {studentId} not found when trying to retrieve profile.");
            // You might want to throw a custom exception here, e.g., StudentNotFoundException
            // or return null and handle not found in the controller.
            return null; // Or throw StudentNotFoundException
        }

        _logger.LogInfo($"Successfully retrieved profile for student with ID: {studentId}");
        return student; // Return the Student entity. Controller will handle DTO mapping.
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Course>> GetRegistrableCoursesAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve registrable courses for student with ID: {studentId}");

        // **Implementation Note:** The logic to determine "registrable courses" is business-specific.
        // This is a placeholder. You'll need to implement the actual logic based on your rules.
        // For now, let's assume you have a repository method to get courses, or you might
        // need to fetch courses and then filter based on student's program, prerequisites, etc.

        // **Placeholder - Replace with your actual logic:**
        var allCourses = await _repository.CourseRepository.GetAllCoursesAsync(trackChanges);
        // Example placeholder filtering (replace with real registrable course logic):
        var registrableCourses = allCourses.Where(course => course.IsActive); 
        
        var registrableCoursesAsync = registrableCourses.ToList();
        _logger.LogInfo($"Retrieved {registrableCoursesAsync.Count} registrable courses for student with ID: {studentId}");
        return registrableCoursesAsync;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Course>> GetRegisteredCoursesAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve registered courses for student with ID: {studentId}");

        // Access the ClassEnrollment repository to find enrollments for the student
        var classEnrollments = await _repository.ClassEnrollmentRepository.GetClassEnrollmentsForStudentAsync(studentId, trackChanges);

        // Extract Course entities from the ClassEnrollments
        // Corrected line: Access Course through Class navigation property
        var registeredCourses = classEnrollments.Select<ClassEnrollment, Course>(enrollment => enrollment.Class.Course);

        var registeredCoursesAsync = registeredCourses.ToList();
        _logger.LogInfo($"Retrieved {registeredCoursesAsync.Count} registered courses for student with ID: {studentId}");
        return registeredCoursesAsync;
    }

    /// <inheritdoc />
    public async Task<StudentScheduleDto> GetScheduleAsync(string studentId, bool trackChanges)
{
    _logger.LogInfo($"Attempting to retrieve schedule for student with ID: {studentId}");

    var classEnrollments = await _repository.ClassEnrollmentRepository.GetClassEnrollmentsForStudentAsync(studentId, trackChanges);

    var classSessionDtos = classEnrollments.Select(enrollment =>
    {
        var lecturerName = enrollment.Class.Lecturer.FullName; // Lecturer from Class, handle null
        
        var classSchedule = enrollment.Class.ClassSchedules.FirstOrDefault(); // Get the first schedule, or null if no schedules

        return new ClassSessionDto // Mapping to DTO
        {
            CourseName = enrollment.Class.Course.CourseName,
            LecturerName = lecturerName, // Lecturer from Class
            StartTime = classSchedule?.StartTime ?? TimeSpan.Zero, // Use null-conditional and default TimeSpan.Zero if no schedule
            EndTime = classSchedule?.EndTime ?? TimeSpan.Zero,       // Use null-conditional and default TimeSpan.Zero if no schedule
            DayOfWeek = classSchedule?.DayOfWeek.ToString() ?? "N/A", // Use null-conditional and default "N/A" if no schedule
            // Explicit cast for the ClassLocation enum
            ClassLocation = classSchedule != null ? (Common.Enums.ClassLocation)classSchedule.ClassLocation : Common.Enums.ClassLocation.AmericanHigh
        };
    }).ToList();

    var scheduleDto = new StudentScheduleDto { ClassSessions = classSessionDtos };

    _logger.LogInfo($"Successfully retrieved schedule for student with ID: {studentId} with {classSessionDtos.Count} sessions.");
    return scheduleDto;
}

    /// <inheritdoc />
    public async Task<FeeAccountSummaryDto> GetFeeAccountSummaryAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve fee account summary for student with ID: {studentId}");

        var feeAccount = await _repository.FeeAccountRepository.GetFeeAccountByStudentIdAsync(studentId, trackChanges);

        if (feeAccount == null)
        {
            _logger.LogWarn($"Fee account not found for student with ID: {studentId}. Returning default summary.");
            return new FeeAccountSummaryDto(); // Or throw exception if FeeAccount is mandatory
        }

        var summaryDto = new FeeAccountSummaryDto // Mapping to DTO
        {
            OutstandingBalance = feeAccount.OutstandingBalance,
            TotalFees = feeAccount.TotalFeeDue,
            TotalPaid = feeAccount.TotalFeePaid
        };

        _logger.LogInfo($"Successfully retrieved fee account summary for student with ID: {studentId}");
        return summaryDto;
    }

    /// <inheritdoc />
    public async Task<FeeStatementDto> GetFeeStatementAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve fee statement for student with ID: {studentId}");

        var feeAccount = await _repository.FeeAccountRepository.GetFeeAccountByStudentIdAsync(studentId, trackChanges);

        if (feeAccount == null)
        {
            _logger.LogWarn($"Fee account not found for student ID: {studentId}. Returning empty statement.");
            return new FeeStatementDto(); // Or throw exception
        }

        var paymentDtos = feeAccount.FeePayments // Access FeePayments (plural!)
            .Select<FeePayment, FeePaymentDto>(payment => new FeePaymentDto // Mapping FeePayment to FeePaymentDto
            {
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaymentMethod = (Common.Enums.CommonPaymentMethod)payment.PaymentMethod, // Explicit cast to Common enum
                PaymentReference = payment.PaymentReference,
                Semester = (Common.Enums.CommonSemester)payment.Semester,
                AcademicYear = payment.AcademicYear,
                Status = (Common.Enums.CommonPaymentStatus)payment.Status,
                Description = payment.Description,
                ReceiptIssued = payment.ReceiptIssued,
                ReceiptNumber = payment.ReceiptNumber,
                CreatedBy = payment.CreatedBy,
                CreatedAt = payment.CreatedAt,
                LastModifiedBy = payment.LastModifiedBy,
                LastModifiedAt = payment.LastModifiedAt
            }).ToList();

        var statementDto = new FeeStatementDto { Transactions = paymentDtos }; // Use paymentDtos for Transactions

        _logger.LogInfo($"Successfully retrieved fee statement for student with ID: {studentId} with {paymentDtos.Count} payments.");
        return statementDto;
    }

    /// <inheritdoc />
    public async Task<GradeReportDto> GetGradeReportAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve grade report for student with ID: {studentId}");

        var grades = await _repository.GradeRepository.GetGradesForStudentAsync(studentId, trackChanges);

        var courseGradeDtos = grades.Select(grade => new CourseGradeDto // Mapping grades to DTOs
        {
            CourseName = grade.Course.CourseName, // Access CourseName through Course navigation
            Grade = (Common.Enums.CommonGrade)grade.GradeValue, // GradeValue is directly on Grade entity
            Credits = grade.Course.Credits, // Access CreditHours through Course navigation
            Semester = (Common.Enums.CommonSemester)grade.Semester   // Semester is directly on Grade entity
        }).ToList();

        var reportDto = new GradeReportDto { CourseGrades = courseGradeDtos };

        _logger.LogInfo($"Successfully retrieved grade report for student with ID: {studentId} with {courseGradeDtos.Count} course grades.");
        return reportDto;
    }

    /// <inheritdoc />
    public async Task<TranscriptDto> GetTranscriptAsync(string studentId, bool trackChanges)
{
    _logger.LogInfo($"Attempting to retrieve transcript for student with ID: {studentId}");

    var grades = await _repository.GradeRepository.GetGradesForStudentAsync(studentId, trackChanges);

    var enumerableGrades = grades.ToList();
    var transcriptCourseRecordDtos = enumerableGrades.Select(grade => new TranscriptCourseRecordDto // Mapping grades to TranscriptCourseRecordDto
    {
        CourseName = grade.Course.CourseName,
        Grade = (Common.Enums.CommonGrade)grade.GradeValue, // Cast to CommonGradeValue for DTO
        Credits = grade.Course.Credits,
        Semester = (Common.Enums.CommonSemester)grade.Semester // Cast to CommonSemester for DTO
    }).ToList();

    // **Refactored GPA calculation using GpaCalculator and GpaCalculationDto**
    var gpaCalculationDtos = enumerableGrades.Select(grade => new GpaCalculationDto // Mapping grades to GpaCalculationDto for GPA calculation
    {
        Grade = grade.GradeValue.ToCommonGrade(), // Convert Core GradeValue to CommonGrade for GPA calculation
        CreditHours = grade.Course.Credits
    }).ToList();

    var cumulativeGpa = GpaCalculator.CalculateGpa(gpaCalculationDtos);

    var transcriptDto = new TranscriptDto
    {
        CourseRecords = transcriptCourseRecordDtos,
        CumulativeGpa = (decimal)cumulativeGpa // Cast double GPA to decimal for DTO
    };

    _logger.LogInfo($"Successfully retrieved transcript for student with ID: {studentId} with {transcriptCourseRecordDtos.Count} course records. GPA: {cumulativeGpa}");
    return transcriptDto;
}
    

    /// <inheritdoc />
    public async Task<GpaDto> GetGpaAsync(string studentId, bool trackChanges)
    {
        _logger.LogInfo($"Attempting to retrieve GPA for student with ID: {studentId}");

        decimal calculatedGpa = 3.5m; // Placeholder GPA value

        var gpaDto = new GpaDto { GpaValue = calculatedGpa };

        _logger.LogInfo($"Successfully retrieved GPA for student with ID: {studentId}, GPA: {calculatedGpa}");
        return await Task.FromResult(gpaDto); 
    }
}