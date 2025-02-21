using System.Linq.Expressions;

namespace ischool_backend.Core.Interfaces;

/// <summary>
/// Generic repository interface defining common data access operations for entities of type T.
/// </summary>
/// <typeparam name="T">The entity type. Must be a class.</typeparam>
public interface IRespositoryBase<T> where T : class
{
    /// <summary>
    /// Retrieves all entities of type T.
    /// </summary>
    /// <param name="trackChanges">
    /// A boolean value indicating whether Entity Framework should track changes for the retrieved entities.
    ///  - `true`:  Entities are tracked for changes (useful for updates).
    ///  - `false`: Entities are not tracked (more performant for read-only operations).
    /// </param>
    /// <returns>An <see cref="IQueryable{T}"/> representing all entities of type T.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Retrieves entities of type T that satisfy a specific condition.
    /// </summary>
    /// <param name="expression">An <see cref="Expression{Func{T, bool}}"/> that defines the condition to filter entities.</param>
    /// <param name="trackChanges">
    /// A boolean value indicating whether Entity Framework should track changes for the retrieved entities.
    ///  - `true`:  Entities are tracked for changes (useful for updates).
    ///  - `false`: Entities are not tracked (more performant for read-only operations).
    /// </param>
    /// <returns>An <see cref="IQueryable{T}"/> representing entities of type T that match the given condition.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Creates a new entity of type T in the database.
    /// </summary>
    /// <param name="entity">The entity of type T to create.</param>
    void Create(T entity);

    /// <summary>
    /// Updates an existing entity of type T in the database.
    /// </summary>
    /// <param name="entity">The entity of type T to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity of type T from the database.
    /// </summary>
    /// <param name="entity">The entity of type T to delete.</param>
    void Delete(T entity);
}