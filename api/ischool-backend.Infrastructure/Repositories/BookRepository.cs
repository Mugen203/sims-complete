using ischool_backend.Core.Entities;
using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
}