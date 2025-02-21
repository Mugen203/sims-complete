using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IAttendanceRecordRepository : IRespositoryBase<AttendanceRecord>
{
    // Get attendance records for a class (across all sessions of that class)
    // etc
}