using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure.Repositories;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public async Task<Student?> GetStudentByIdAsync(string studentId, bool trackChanges)
    {
        return await FindByCondition(student => student.StudentID.Equals(studentId), trackChanges)
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(s => s.LastName) // Example ordering, adjust as needed
            .ToListAsync();
    }
}