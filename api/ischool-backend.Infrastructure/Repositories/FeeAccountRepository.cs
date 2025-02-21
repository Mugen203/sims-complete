using ischool_backend.Core.Entities;

namespace ischool_backend.Infrastructure.Repositories;

public class FeeAccountRepository : RepositoryBase<FeeAccount>
{
    public FeeAccountRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
    {
        
    }
}