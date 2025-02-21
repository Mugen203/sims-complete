using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure.Repositories;

public class FeeAccountRepository : RepositoryBase<FeeAccount>, IFeeAccountRepository
{
    public FeeAccountRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
    {
        
    }
    
    public async Task<FeeAccount?> GetFeeAccountByStudentIdAsync(string studentId, bool trackChanges)
    {
        return await FindByCondition(feeAccount => feeAccount.StudentID.Equals(studentId), trackChanges)
            .Include(fa => fa.FeePayments) // Eager load FeeTransactions for statement
            .SingleOrDefaultAsync();
    }
}