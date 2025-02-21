using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface ICourseRepository : IRespositoryBase<Course>
{
    /// <summary>
    /// Retrieves a collection of all courses.
    /// </summary>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns a collection of Course entities.</returns>
    Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges);
}