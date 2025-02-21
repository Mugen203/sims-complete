using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class AttendanceRecordRepository : RepositoryBase<AttendanceRecord>, IAttendanceRecordRepository
{
    public AttendanceRecordRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}