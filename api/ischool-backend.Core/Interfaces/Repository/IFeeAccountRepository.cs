using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IFeeAccountRepository : IRespositoryBase<FeeAccount>
{
    /// <summary>
    /// Retrieves a fee account for a specific student using the student's ID.
    /// </summary>
    /// <param name="studentId">The StudentID to filter FeeAccounts by.</param>
    /// <param name="trackChanges">Indicates if change tracking should be enabled.</param>
    /// <returns>A Task that represents the asynchronous operation. Returns a FeeAccount entity if found, otherwise null.</returns>
    Task<FeeAccount?> GetFeeAccountByStudentIdAsync(string studentId, bool trackChanges);
}