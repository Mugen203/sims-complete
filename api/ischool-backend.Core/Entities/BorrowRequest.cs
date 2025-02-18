using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities
{
    public class BorrowRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BorrowRequestId { get; set; }

        [Required]
        public string StudentId { get; set; } = null!;

        [Required]
        public Guid BookId { get; set; }

        [Required]
        public DateTimeOffset BorrowDate { get; set; }

        [Required]
        public DateTimeOffset ReturnDate { get; set; }

        [Required]
        public bool IsReturned { get; set; }

        [Required]
        [EnumDataType(typeof(BookStatus))]
        public BookStatus BookStatus { get; set; }


        // Navigation properties
        public Student Student { get; set; } = null!;

        public Book Book { get; set; } = null!;
    }
}
