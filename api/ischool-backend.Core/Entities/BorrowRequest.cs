using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

/// <summary>
/// Represents a request by a student to borrow a book from the library.
/// Tracks details of the borrowing request, including student, book, borrow and return dates, and return status.
/// Now includes a BorrowRequestStatus to track the lifecycle of the request itself.
/// </summary>
public class BorrowRequest
{
    #region Constructors

    /// <summary>
    /// Parameterless constructor for Entity Framework Core.
    /// Required for EF Core to create proxies and database operations.
    /// Initializes default values for BorrowDate and sets the initial Status to Pending.
    /// </summary>
    public BorrowRequest()
    {
        BorrowDate = DateTimeOffset.UtcNow; // Default BorrowDate to current time
        Status = BorrowRequestStatus.Pending; // Default status for new requests
    }

    /// <summary>
    /// Parameterized constructor to create a new BorrowRequest instance with essential details.
    /// </summary>
    /// <param name="studentId">ID of the Student making the borrow request.</param>
    /// <param name="bookId">ID of the Book requested for borrowing.</param>
    /// <param name="returnDate">Expected return date for the borrowed book.</param>
    public BorrowRequest(string studentId, Guid bookId, DateTimeOffset returnDate)
    {
        StudentId = studentId ?? throw new ArgumentNullException(nameof(studentId));
        BookId = bookId;
        BorrowDate = DateTimeOffset.UtcNow; // Set BorrowDate to current time at creation
        ReturnDate = returnDate;
        IsReturned = false; // Default IsReturned to false when request is created
        Status = BorrowRequestStatus.Pending; // Default status for new requests
    }

    #endregion

    #region Properties

    /// <summary>
    /// Unique identifier for the BorrowRequest entity.
    /// Generated automatically by the database.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid BorrowRequestId { get; set; }

    /// <summary>
    /// ID of the Student who is making the borrow request.
    /// Foreign key to the Student entity.
    /// </summary>
    [Required]
    [ForeignKey("Student")]
    [MaxLength(13, ErrorMessage = "Student ID cannot be longer than 13 characters.")]
    public required string StudentId { get; set; } 

    /// <summary>
    /// ID of the Book requested for borrowing.
    /// Foreign key to the Book entity.
    /// </summary>
    [Required]
    public Guid BookId { get; set; }

    /// <summary>
    /// Date and time when the borrow request was made.
    /// Defaults to the time of creation of the BorrowRequest record.
    /// </summary>
    [Required]
    public DateTimeOffset BorrowDate { get; set; }

    /// <summary>
    /// Expected or agreed upon return date for the borrowed book.
    /// </summary>
    [Required]
    public DateTimeOffset ReturnDate { get; set; }

    /// <summary>
    /// Indicates whether the borrowed book has been physically returned to the library.
    /// Defaults to false when a borrow request is created.
    /// This is a boolean flag for simple return tracking.
    /// </summary>
    [Required]
    public bool IsReturned { get; set; } = false; // Default value - book is initially not returned

    /// <summary>
    /// Status of the borrow request itself (e.g., Pending, Approved, Borrowed, Returned).
    /// Uses the BorrowRequestStatus enum to track the lifecycle of the borrowing process.
    /// Defaults to 'Pending' for newly created requests.
    /// </summary>
    [Required]
    [EnumDataType(typeof(BorrowRequestStatus))]
    public BorrowRequestStatus Status { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// Navigation property to the Student entity.
    /// Represents the student who made this borrow request.
    /// Defines a many-to-one relationship between BorrowRequest and Student.
    /// </summary>
    [ForeignKey(nameof(StudentId))]
    public required Student Student { get; set; } // Ensures Student navigation property is always populated

    /// <summary>
    /// Navigation property to the Book entity.
    /// Represents the book requested for borrowing.
    /// Defines a many-to-one relationship between BorrowRequest and Book.
    /// </summary>
    [ForeignKey(nameof(BookId))]
    public required Book Book { get; set; } // Ensures Book navigation property is always populated

    #endregion
}