using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class FeeAccountRepository : RepositoryBase<FeeAccount>, IFeeAccountRepository
{
    public FeeAccountRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
    {
        
    }
}