using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure.Repositories;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.CourseName) // Example ordering - adjust as needed
            .ToListAsync();
    }

}