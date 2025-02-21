using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure.Repositories;

public class ClassEnrollmentRepository : RepositoryBase<ClassEnrollment>, IClassEnrollmentRepository
{
    public ClassEnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public async Task<IEnumerable<ClassEnrollment>> GetClassEnrollmentsForStudentAsync(string studentId, bool trackChanges)
    {
        return await FindByCondition(enrollment => enrollment.StudentId.Equals(studentId), trackChanges)
            .Include(enrollment => enrollment.Class) // Eager load Class
            .ThenInclude(c => c.Course)          // Then eager load Course within Class
            .Include(enrollment => enrollment.Class) // Include Class again to get ClassSchedule
            .ThenInclude(c => c.ClassSchedules)        // Then eager load ClassSchedule within Class
            .ToListAsync();
    }
}