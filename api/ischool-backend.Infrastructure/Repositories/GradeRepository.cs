using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
{
    public GradeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}