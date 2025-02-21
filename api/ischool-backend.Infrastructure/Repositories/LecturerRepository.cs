using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class LecturerRepository : RepositoryBase<Lecturer>, ILecturerRepository
{
    public LecturerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}