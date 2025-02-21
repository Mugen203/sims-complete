using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class ClassScheduleRepository : RepositoryBase<ClassSchedule>, IClassScheduleRepository
{
    public ClassScheduleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}