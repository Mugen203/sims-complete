using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure.Repositories;

public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
{
    public GradeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public async Task<IEnumerable<Grade>> GetGradesForStudentAsync(string studentId, bool trackChanges)
    {
        return await FindByCondition(grade => grade.StudentID.Equals(studentId), trackChanges)
            .Include(grade => grade.Course) // Eager load Course from Grade
            .ToListAsync();
    }
}