using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IClassEnrollmentRepository : IRespositoryBase<ClassEnrollment>
{
    // Count the number of students enrolled in a class.
    // Get students not yet enrolled in a class.
    // etc
}