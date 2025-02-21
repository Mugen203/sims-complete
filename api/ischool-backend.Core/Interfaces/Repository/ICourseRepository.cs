using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces;

public interface ICourseRepository : IRespositoryBase<Course>
{
    // Get courses by lecturer, by department, etc.
}