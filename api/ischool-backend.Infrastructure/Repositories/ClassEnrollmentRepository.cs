using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class ClassEnrollmentRepository : RepositoryBase<ClassEnrollment>, IClassEnrollmentRepository
{
    public ClassEnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}