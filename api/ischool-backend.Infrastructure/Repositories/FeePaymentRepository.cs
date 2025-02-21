using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class FeePaymentRepository : RepositoryBase<FeePayment>, IFeePaymentRepository
{
    public FeePaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}