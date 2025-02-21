using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class BorrowRequestRepository : RepositoryBase<BorrowRequest>, IBorrowRequestRepository
{
    public BorrowRequestRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}