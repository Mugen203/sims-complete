using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class ClassSessionRepository : RepositoryBase<ClassSession>, IClassSessionRepository
{
    public ClassSessionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}