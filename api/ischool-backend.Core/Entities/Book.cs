using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a book available in the library.
/// Stores book details such as title, author, ISBN, publisher, category, and status.
/// Now includes a relationship to the Library entity indicating which library manages this book.
/// </summary>
public class Book
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// </summary>
    public Book()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new Book instance with essential details.
    /// </summary>
    /// <param name="title">Title of the book.</param>
    /// <param name="author">Author of the book.</param>
    /// <param name="isbn">International Standard Book Number (ISBN) of the book.</param>
    /// <param name="category">Category of the book.</param>
    /// <param name="bookStatus">Current status of the book in the library.</param>
    /// <param name="libraryId">ID of the Library to which this book belongs.</param>
    public Book(string title, string author, string isbn, BookCategory category, BookStatus bookStatus, Guid libraryId)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Author = author ?? throw new ArgumentNullException(nameof(author));
        ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
        Category = category;
        BookStatus = bookStatus;
        LibraryId = libraryId; // Set LibraryId
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the Book entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid BookID { get; set; }

    /// <summary>
    /// Title of the book.
    /// </summary>
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters")]
    public required string Title { get; set; } // Non-nullable

    /// <summary>
    /// Author of the book.
    /// </summary>
    [Required(ErrorMessage = "Author is required")]
    [MaxLength(150, ErrorMessage = "Author name cannot exceed 150 characters")]
    public required string Author { get; set; } // Non-nullable

    /// <summary>
    /// International Standard Book Number (ISBN) of the book.
    /// Must be either 10 or 13 digits long and validated with a RegularExpression.
    /// </summary>
    [Required(ErrorMessage = "ISBN is required")]
    [MaxLength(13, ErrorMessage = "ISBN cannot exceed 13 characters")]
    [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format (must be 10 or 13 digits)")]
    public required string ISBN { get; set; } // Non-nullable

    /// <summary>
    /// Publisher of the book.
    /// Optional, can be null if publisher information is not available.
    /// </summary>
    [MaxLength(150, ErrorMessage = "Publisher name cannot exceed 150 characters")]
    public string? Publisher { get; set; } // Nullable

    /// <summary>
    /// Category of the book (e.g., Fiction, Non-Fiction, Textbook).
    /// Uses the BookCategory enum for predefined book category options.
    /// </summary>
    [Required(ErrorMessage = "Category is required")]
    [EnumDataType(typeof(BookCategory))]
    public BookCategory Category { get; set; }

    /// <summary>
    /// Current status of the book in the library (e.g., Available, Loaned, Damaged).
    /// Uses the BookStatus enum for predefined book status options.
    /// </summary>
    [Required(ErrorMessage = "BookStatus is required")]
    [EnumDataType(typeof(BookStatus))]
    public BookStatus BookStatus { get; set; }

    /// <summary>
    /// Edition of the book (e.g., 1st Edition, 2nd Revised Edition).
    /// Optional, can be null if edition information is not available.
    /// </summary>
    [MaxLength(50, ErrorMessage = "Edition cannot exceed 50 characters")]
    public string? Edition { get; set; } // Nullable

    /// <summary>
    /// ID of the Library to which this book belongs.
    /// Foreign key to the Library entity.
    /// </summary>
    [Required] // Book must belong to a library
    public Guid LibraryId { get; set; } // Foreign Key property

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Library entity.
    /// Represents the library that manages this book.
    /// Defines a many-to-one relationship between Book and Library.
    /// </summary>
    [ForeignKey(nameof(LibraryId))] // Foreign key attribute
    public required Library Library { get; set; } // Ensures Library navigation property is always populated
    
    /// <summary>
    /// Navigation property for BorrowRequests.
    /// Represents the borrow requests for this book.
    /// Defines a one-to-many relationship between Book and BorrowRequest.
    /// **THIS NAVIGATION PROPERTY WAS MISSING BEFORE AND IS NOW ADDED**
    /// </summary>
    public ICollection<BorrowRequest> BorrowRequests { get; set; }

    #endregion
}