using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class ClassRepository : RepositoryBase<Class>, IClassRepository
{
    public ClassRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}