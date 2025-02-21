using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IGradeRepository : IRespositoryBase<Grade>
{
    
    /// <summary>
    /// Retrieves a collection of grades for a specific student.
    /// </summary>
    /// <param name="studentId">The StudentID to filter grades by.</param>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns a collection of Grade entities.</returns>
    Task<IEnumerable<Grade>> GetGradesForStudentAsync(string studentId, bool trackChanges);
}