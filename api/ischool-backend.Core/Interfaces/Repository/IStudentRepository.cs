using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IStudentRepository : IRespositoryBase<Student>
{
    /// <summary>
    /// Retrieves a student by their unique Student ID.
    /// </summary>
    /// <param name="studentId">The Student ID to search for.</param>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns the Student if found, otherwise null.</returns>
    Task<Student?> GetStudentByIdAsync(string studentId, bool trackChanges);

    /// <summary>
    /// Retrieves a collection of all students.
    /// </summary>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns a collection of Student entities.</returns>
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);

    // You can add more student-specific GET methods as needed later
    // Examples of potential future methods:
    // Task<IEnumerable<Student>> GetStudentsByMajorAsync(string major, bool trackChanges);
    // Task<IEnumerable<Student>> GetActiveStudentsAsync(bool trackChanges);
    // ... and so on
}