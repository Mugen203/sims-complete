using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a library within the educational institution.
/// Stores information about the library itself, such as name, location, and contact details.
/// In this basic structure, it mainly serves as a container for books and borrowing operations.
/// In a more detailed model, it could manage librarians, sections, resources etc.
/// </summary>
public class Library
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// </summary>
    public Library()
    {
        // Parameterless constructor for EF Core
    }

    /// <summary>
    /// Parameterized constructor to create a new Library instance with essential details.
    /// </summary>
    /// <param name="libraryName">Name of the library.</param>
    /// <param name="location">Physical location of the library (e.g., building, floor).</param>
    public Library(string libraryName, string location)
    {
        LibraryName = libraryName ?? throw new ArgumentNullException(nameof(libraryName));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the Library entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid LibraryId { get; set; }

    /// <summary>
    /// Name of the library (e.g., "Main Library", "Science Library").
    /// </summary>
    [Required(ErrorMessage = "Library name is required")]
    [MaxLength(100, ErrorMessage = "Library name cannot exceed 100 characters")]
    [Display(Name = "Library Name")] // For display in UI labels
    public required string LibraryName { get; set; } // Non-nullable

    /// <summary>
    /// Physical location of the library within the institution campus (e.g., "Building A, 3rd Floor", "Main Campus").
    /// </summary>
    [Required(ErrorMessage = "Location is required")]
    [MaxLength(150, ErrorMessage = "Location cannot exceed 150 characters")]
    public required string Location { get; set; } // Non-nullable

    // You can add more properties as needed, such as:
    // Address, Contact Phone, Contact Email, Website, Opening Hours, etc.

    #endregion

    #region Navigation Properties
       
    /// <summary>
    /// Navigation property to the collection of Book entities managed by this library.
    /// Defines a one-to-many relationship between Library and Book.
    /// </summary>
    public virtual ICollection<Book> Books { get; set; } // Collection of Books in this library, virtual for lazy loading
        
    #endregion
}