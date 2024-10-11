
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models;


public class Book
{
    public int BookID { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string Author { get; set; }

    [Required]
    [StringLength(50)]
    public string Genre { get; set; }

    [StringLength(20)]
    public string? ISBN { get; set; }

    public int PublishedYear { get; set; }

    [Range(0, int.MaxValue)]
    public int CopiesAvailable { get; set; }

    [Range(0, int.MaxValue)]
    public int TotalCopies { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [StringLength(100)]
    public string? Publisher { get; set; }

    public String Image { get; set; }

    public DateTime DateAdded { get; set; }

    public bool IsAvailable { get; set; }

    //public int CategoryID { get; set; } // Foreign key for Category
   // public Category Category { get; set; } // Navigation property for Category

    public ICollection<Review> Reviews { get; set; } = new List<Review>(); // Initialize the collection
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>(); // Initialize the collection
    public ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>(); // Initialize the collection

    [Range(0, double.MaxValue)]
    public decimal PenaltyAmount { get; set; }

    public DateTime DueDate { get; set; }
}
