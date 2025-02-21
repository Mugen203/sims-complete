using ischool_backend.Common.Models;
using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Service;

public interface IStudentService
{
// Student-specific service methods based on API actions:

    /// <summary>
    /// Retrieves the profile information of a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for the entity.</param>
    /// <returns>A task that represents the asynchronous operation. Returns a Student object if found, otherwise null.</returns>
    Task<Student?> GetStudentProfileAsync(string studentId, bool trackChanges);

    /// <summary>
    /// Retrieves a list of courses that a student is eligible to register for.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for entities.</param>
    /// <returns>A task that represents the asynchronous operation. Returns a collection of Course entities.</returns>
    Task<IEnumerable<Course>> GetRegistrableCoursesAsync(string studentId, bool trackChanges);

    /// <summary>
    /// Retrieves a list of courses that a student is currently registered in.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for entities.</param>
    /// <returns>A task that represents the asynchronous operation. Returns a collection of Course entities.</returns>
    Task<IEnumerable<Course>> GetRegisteredCoursesAsync(string studentId, bool trackChanges);

    /// <summary>
    /// Retrieves the class schedule for a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for entities.</param>
    /// <returns>A task that represents the asynchronous operation. Returns a student's schedule information (you might need to define a specific DTO or entity for schedule representation).</returns>
    Task<StudentScheduleDto> GetScheduleAsync(string studentId, bool trackChanges); // Return type might need to be refined (e.g., StudentScheduleDto)

    /// <summary>
    /// Retrieves a summary of a student's fee account.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for the entity.</param>
    /// <returns>A task that represents the asynchronous operation. Returns FeeAccountSummary information (you'll need to define a FeeAccountSummaryDto).</returns>
    Task<FeeAccountSummaryDto> GetFeeAccountSummaryAsync(string studentId, bool trackChanges); // Return type will be FeeAccountSummaryDto

    /// <summary>
    /// Retrieves a detailed financial statement for a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for the entity.</param>
    /// <returns>A task that represents the asynchronous operation. Returns a FeeStatement information (you'll need to define a FeeStatementDto).</returns>
    Task<FeeStatementDto> GetFeeStatementAsync(string studentId, bool trackChanges); // Return type will be FeeStatementDto

    /// <summary>
    /// Retrieves a grade report for a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for entities.</param>
    /// <returns>A task that represents the asynchronous operation. Returns GradeReport information (you'll need to define a GradeReportDto).</returns>
    Task<GradeReportDto> GetGradeReportAsync(string studentId, bool trackChanges); // Return type will be GradeReportDto

    /// <summary>
    /// Retrieves the academic transcript for a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for entities.</param>
    /// <returns>A task that represents the asynchronous operation. Returns Transcript information (you'll need to define a TranscriptDto).</returns>
    Task<TranscriptDto> GetTranscriptAsync(string studentId, bool trackChanges); // Return type will be TranscriptDto

    /// <summary>
    /// Retrieves the GPA (Grade Point Average) for a student.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="trackChanges">Indicates whether to track changes for the entity.</param>
    /// <returns>A task that represents the asynchronous operation. Returns GP information (you'll need to define a GpaDto).</returns>
    Task<GpaDto> GetGpaAsync(string studentId, bool trackChanges); // Return type will be GpaDto
}