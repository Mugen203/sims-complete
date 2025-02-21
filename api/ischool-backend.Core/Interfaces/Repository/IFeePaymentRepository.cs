using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IFeePaymentRepository : IRespositoryBase<FeePayment>
{
    //Get fee payments for a specific fee account
    //Get fee payments for a student (potentially through FeeAccount)
    //etc
}