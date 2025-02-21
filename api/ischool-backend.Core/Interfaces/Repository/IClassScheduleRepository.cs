using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IClassScheduleRepository : IRespositoryBase<ClassSchedule>
{
    // Get class schedules for a specific course
    // Get class schedules that overlap with a given time slot (for scheduling conflict detection).
    // etc
}