using System.Linq.Expressions;
using ischool_backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ischool_backend.Infrastructure;

/// <summary>
/// Base repository class providing a generic implementation of data access operations
/// using Entity Framework Core. Implements the <see cref="IRespositoryBase{T}"/> interface.
/// </summary>
/// <typeparam name="T">The entity type. Must be a class.</typeparam>
public class RepositoryBase<T> : IRespositoryBase<T> where T : class
{
    private readonly RepositoryContext _repositoryContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
    /// </summary>
    /// <param name="repositoryContext">The <see cref="RepositoryContext"/> to be used for database interaction.</param>
    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    /// <inheritdoc />
    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>()
                .AsNoTracking() // Improves performance for read-only scenarios
            : _repositoryContext.Set<T>(); // Enables change tracking if needed for updates
    }

    /// <inheritdoc />
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() // Improves performance for read-only scenarios
            : _repositoryContext.Set<T>()
                .Where(expression); // Enables change tracking if needed for updates
    }

    /// <inheritdoc />
    public void Create(T entity)
    {
        _repositoryContext.Set<T>().Add(entity); // Adds the entity to the DbContext for insertion
    }

    /// <inheritdoc />
    public void Update(T entity)
    {
        _repositoryContext.Set<T>().Update(entity); // Marks the entity for update in the DbContext
    }

    /// <inheritdoc />
    public void Delete(T entity)
    {
        _repositoryContext.Set<T>().Remove(entity); // Marks the entity for deletion in the DbContext
    }
}