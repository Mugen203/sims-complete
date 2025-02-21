using ischool_backend.Core.Entities;

namespace ischool_backend.Core.Interfaces;

public interface IBookRepository : IRespositoryBase<Book>
{
    // Book-specific repository methods will go here
    // Example:
    // IEnumerable<Book> GetBooksByAuthor(string author);
    // IEnumerable<Book> GetAvailableBooks();
}