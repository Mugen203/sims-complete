using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface ICourseRepository : IRespositoryBase<Course>
{
    // Get courses by lecturer, by department, etc.
}