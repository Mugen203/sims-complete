using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IClassSessionRepository : IRespositoryBase<ClassSession>
{
    // Get class sessions for a specific class.
    // Get class sessions for a specific lecturer
    // Get class sessions within a date range.
    // Get upcoming class sessions.
    // Get class sessions for a specific room/location.
}