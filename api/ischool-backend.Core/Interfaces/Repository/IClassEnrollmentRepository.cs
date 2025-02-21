using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IClassEnrollmentRepository : IRespositoryBase<ClassEnrollment>
{
    /// <summary>
    /// Retrieves a collection of class enrollments for a specific student.
    /// </summary>
    /// <param name="studentId">The StudentID to filter enrollments by.</param>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns a collection of ClassEnrollment entities.</returns>
    Task<IEnumerable<ClassEnrollment>> GetClassEnrollmentsForStudentAsync(string studentId, bool trackChanges);
}