namespace ischool_backend.Core.Enums;

public enum BorrowRequestStatus
{
    Pending = 1, // Request submitted, awaiting approval
    Approved = 2, // Request approved, book can be picked up
    Rejected = 3, // Request rejected (book unavailable, student ineligible, etc.)
    Borrowed = 4, // Book has been borrowed (active loan)
    Returned = 5, // Book has been returned
    Overdue = 6, // Book is overdue for return
    Cancelled = 7 // Borrow request was cancelled
}