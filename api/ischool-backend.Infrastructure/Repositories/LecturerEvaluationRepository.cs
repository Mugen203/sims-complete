using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class LecturerEvaluationRepository : RepositoryBase<LecturerEvaluation>, ILecturerEvaluationRepository
{
    public LecturerEvaluationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}