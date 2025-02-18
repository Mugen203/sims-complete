using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Entities;

public class Book
{
    [Key]
    [Required(ErrorMessage = "BookID is required")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(20, ErrorMessage = "BookID cannot exceed 20 characters")]
    public Guid BookID { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Author is required")]
    [MaxLength(150, ErrorMessage = "Author name cannot exceed 150 characters")]
    public string Author { get; set; } = null!;

    [Required(ErrorMessage = "ISBN is required")]
    [MaxLength(13, ErrorMessage = "ISBN cannot exceed 13 characters")]
    [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format (must be 10 or 13 digits)")]
    public string ISBN { get; set; } = null!;

    [MaxLength(150, ErrorMessage = "Publisher name cannot exceed 150 characters")]
    public string? Publisher { get; set; }

    [Required(ErrorMessage = "Category is required")]
    [EnumDataType(typeof(BookCategory))]
    public BookCategory Category { get; set; }

    [Required(ErrorMessage = "BookStatus is required")]
    [EnumDataType(typeof(BookStatus))]
    public BookStatus BookStatus { get; set; }

    [MaxLength(50, ErrorMessage = "Edition cannot exceed 50 characters")]
    public string? Edition { get; set; }
}
