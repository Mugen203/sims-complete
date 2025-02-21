using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces;

public interface IClassRepository : IRespositoryBase<Class>
{
    // Get classes by lecturer, by course, scheduled for a day, etc.
}