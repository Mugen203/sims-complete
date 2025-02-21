using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IGradeRepository : IRespositoryBase<Grade>
{
    // Get grades for a specific student
    // Get grades for a specific course.
    // Potentially filter grades by semester/term.
    // etc
}