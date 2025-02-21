using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IStudentRepository : IRespositoryBase<Student>
{
    // Student-specific repository methods will go here
    // Example:
    // IEnumerable<Student> GetStudentsEnrolledInCourse(int courseId);
}